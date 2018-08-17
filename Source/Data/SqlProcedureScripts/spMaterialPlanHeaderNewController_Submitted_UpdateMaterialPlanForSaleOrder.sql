CREATE PROCEDURE Web.spMaterialPlanHeaderNewController_Submitted_UpdateMaterialPlanForSaleOrder(@MaterialPlanHeaderId INT)
AS 
BEGIN
UPDATE Web.MaterialPlanForSaleOrders
SET Web.MaterialPlanForSaleOrders.MaterialPlanLineId = V1.MaterialPlanLineId
FROM (
	SELECT Mpfs.MaterialPlanForSaleOrderId, L.MaterialPlanLineId
	FROM Web.MaterialPlanHeaders H 
	LEFT JOIN Web.MaterialPlanForSaleOrders Mpfs ON H.MaterialPlanHeaderId = Mpfs.MaterialPlanHeaderId
	LEFT JOIN Web.SaleOrderLines Sol ON Mpfs.SaleOrderLineId = Sol.SaleOrderLineId
	LEFT JOIN Web.MaterialPlanLines L ON H.MaterialPlanHeaderId = L.MaterialPlanHeaderId
		AND IsNull(L.ProductId,0) = IsNull(Sol.ProductId,0)
		AND IsNull(L.Dimension1Id,0) = IsNull(Sol.Dimension1Id,0)
		AND IsNull(L.Dimension2Id,0) = IsNull(Sol.Dimension2Id,0)
	WHERE H.MaterialPlanHeaderId = @MaterialPlanHeaderId
	AND Mpfs.MaterialPlanLineId IS NULL
) AS V1 WHERE Web.MaterialPlanForSaleOrders.MaterialPlanForSaleOrderId = V1.MaterialPlanForSaleOrderId



UPDATE Web.MaterialPlanForSaleOrders
SET Web.MaterialPlanForSaleOrders.MaterialPlanLineId = V1.MaterialPlanLineId
FROM (
	SELECT Mpfs.MaterialPlanForSaleOrderId, L.MaterialPlanLineId
	FROM Web.MaterialPlanHeaders H 
	LEFT JOIN Web.MaterialPlanForSaleOrders Mpfs ON H.MaterialPlanHeaderId = Mpfs.MaterialPlanHeaderId
	LEFT JOIN Web.SaleOrderLines Sol ON Mpfs.SaleOrderLineId = Sol.SaleOrderLineId
	LEFT JOIN Web.MaterialPlanLines L ON H.MaterialPlanHeaderId = L.MaterialPlanHeaderId
		AND IsNull(L.ProductId,0) = IsNull(Sol.ProductId,0)
		AND IsNull(L.Dimension1Id,0) = IsNull(Sol.Dimension1Id,0)
	WHERE H.MaterialPlanHeaderId = @MaterialPlanHeaderId
	AND Mpfs.MaterialPlanLineId IS NULL
) AS V1 WHERE Web.MaterialPlanForSaleOrders.MaterialPlanForSaleOrderId = V1.MaterialPlanForSaleOrderId



UPDATE Web.MaterialPlanForSaleOrders
SET Web.MaterialPlanForSaleOrders.MaterialPlanLineId = V1.MaterialPlanLineId
FROM (
	SELECT Mpfs.MaterialPlanForSaleOrderId, L.MaterialPlanLineId
	FROM Web.MaterialPlanHeaders H 
	LEFT JOIN Web.MaterialPlanForSaleOrders Mpfs ON H.MaterialPlanHeaderId = Mpfs.MaterialPlanHeaderId
	LEFT JOIN Web.SaleOrderLines Sol ON Mpfs.SaleOrderLineId = Sol.SaleOrderLineId
	LEFT JOIN Web.MaterialPlanLines L ON H.MaterialPlanHeaderId = L.MaterialPlanHeaderId
		AND IsNull(L.Dimension1Id,0) = IsNull(Sol.Dimension1Id,0)
		AND IsNull(L.Dimension2Id,0) = IsNull(Sol.Dimension2Id,0)
	WHERE H.MaterialPlanHeaderId = @MaterialPlanHeaderId
	AND Mpfs.MaterialPlanLineId IS NULL
) AS V1 WHERE Web.MaterialPlanForSaleOrders.MaterialPlanForSaleOrderId = V1.MaterialPlanForSaleOrderId


UPDATE Web.MaterialPlanForSaleOrders
SET Web.MaterialPlanForSaleOrders.MaterialPlanLineId = V1.MaterialPlanLineId
FROM (
	SELECT Mpfs.MaterialPlanForSaleOrderId, L.MaterialPlanLineId
	FROM Web.MaterialPlanHeaders H 
	LEFT JOIN Web.MaterialPlanForSaleOrders Mpfs ON H.MaterialPlanHeaderId = Mpfs.MaterialPlanHeaderId
	LEFT JOIN Web.SaleOrderLines Sol ON Mpfs.SaleOrderLineId = Sol.SaleOrderLineId
	LEFT JOIN Web.MaterialPlanLines L ON H.MaterialPlanHeaderId = L.MaterialPlanHeaderId
		AND IsNull(L.ProductId,0) = IsNull(Sol.ProductId,0)
	WHERE H.MaterialPlanHeaderId = @MaterialPlanHeaderId
	AND Mpfs.MaterialPlanLineId IS NULL
) AS V1 WHERE Web.MaterialPlanForSaleOrders.MaterialPlanForSaleOrderId = V1.MaterialPlanForSaleOrderId

SELECT 0
END

