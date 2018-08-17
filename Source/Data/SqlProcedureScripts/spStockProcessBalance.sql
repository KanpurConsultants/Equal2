CREATE Procedure Web.spStockProcessBalance (@UptoDate SMALLDATETIME, @SiteId INT, @DivisionId INT , @PersonId INT=Null, @ProcessId INT=NULL, @CostCenterId INT=NULL, @ProductId INT=NULL)
AS
BEGIN
/*
DECLARE @UptoDate SMALLDATETIME 
DECLARE @SiteId INT
DECLARE @DivisionId INT
DECLARE @ProcessId INT
DECLARE @PersonId INT
DECLARE @CostCenterId INT

SET @UptoDate='31-Oct-15';
SET @SiteId=17;
SET @DivisionId=6;
SET @PersonId=546;
SET @ProcessId=43 ;
SET @CostCenterId =NULL;
*/

IF @CostCenterId =-1 SET @CostCenterId = NULL 

SELECT H.PersonId, H.ProcessId, L.CostCenterId, L.ProductId, L.Dimension1Id, 
L.Dimension2Id, L.LotNo, L.Specification, IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0) AS BalanceQty, 
Max(P.ProductName) ProductName, Max(D1.Dimension1Name) Dimension1Name, Max(D2.Dimension2Name) Dimension2Name,
Max(P.ProductGroupId)  AS ProductGroupId, Max(U.UnitName) AS UnitName, Max(U.DecimalPlaces) AS UnitDecimalPlaces, Max(C.CostCenterName) CostCenterName
FROM Web.StockProcesses L WITH (nolock)
LEFT JOIN web.StockHeaders H ON L.StockHeaderId = H.StockHeaderId 
LEFT JOIN Web.products P ON L.ProductId = P.ProductId 
LEFT JOIN Web.Dimension1 D1 ON L.Dimension1Id = D1.Dimension1Id 
LEFT JOIN Web.Dimension2 D2 ON L.Dimension2Id = D2.Dimension2Id 
LEFT JOIN Web.CostCenters C ON L.CostCenterId = C.CostCenterId 
LEFT JOIN Web.Units U ON P.UnitId = U.UnitId 
WHERE H.DocDate <= @UptoDate
AND H.DivisionId =@DivisionId
AND H.SiteId =@SiteId
AND ( @PersonId IS NULL OR H.PersonId =@PersonId) 
AND ( @ProcessId IS NULL OR H.ProcessId=@ProcessId) 
AND ( @CostCenterId IS NULL OR L.CostCenterId=@CostCenterId) 
AND ( @ProductId IS NULL OR L.ProductId  =@ProductId) 
GROUP BY H.PersonId, H.ProcessId, L.CostCenterId, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.LotNo, L.Specification  
HAVING IsNull(Sum(L.Qty_Rec -L.Qty_Iss),0) <> 0
End


