CREATE FUNCTION [Web].[FGenerateBarcodeList]
(
@GenDocTypeId INT, 
@ProductQty INT
)  
RETURNS @Results TABLE 
( 
	ProductUidName           NVARCHAR (50) NOT NULL
)  
AS  
BEGIN  

DECLARE @ProductCategories NVARCHAR (100) 
DECLARE @DocTypyeIdWeavingReceive INT = 448





DECLARE @bItem_UidGenStartNo BIGINT 
DECLARE @bItem_UidGenEndNo BIGINT
DECLARE @bMaxItemUid BIGINT
DECLARE @bItemUid NVARCHAR (100) 



DECLARE @I INT 


 SET @bItem_UidGenStartNo  = NULL 
 SET @bItem_UidGenEndNo  = NULL



IF @bItem_UidGenStartNo IS NOT NULL AND @bItem_UidGenEndNo IS NULL 
BEGIN
   SET @bMaxItemUid=
	(
	SELECT IsNull(Max(Convert(BIGINT,I.ProductUidName)),@bItem_UidGenStartNo) FROM Web.ProductUids I  With (NoLock)  
	WHERE I.ProductUidHeaderId IS NOT NULL 
	AND Convert(BIGINT,I.ProductUidName) > @bItem_UidGenStartNo 
	)   
END 
ELSE IF  @bItem_UidGenStartNo IS NULL AND @bItem_UidGenEndNo IS NOT NULL 
BEGIN
   SET @bMaxItemUid=
	(
	SELECT IsNull(Max(Convert(BIGINT,I.ProductUidName)),@bItem_UidGenStartNo) FROM Web.ProductUids I  With (NoLock)  
	WHERE I.ProductUidHeaderId IS NOT NULL 
	And Convert(BIGINT,I.ProductUidName) < @bItem_UidGenEndNo
	)   
END 
ELSE IF  @bItem_UidGenStartNo IS NOT NULL AND @bItem_UidGenEndNo IS NOT NULL 
BEGIN
   SET @bMaxItemUid=
	(
	SELECT IsNull(Max(Convert(BIGINT,I.ProductUidName)),@bItem_UidGenStartNo) FROM Web.ProductUids I  With (NoLock)  
	WHERE I.ProductUidHeaderId IS NOT NULL 
	AND Convert(BIGINT,I.ProductUidName) > @bItem_UidGenStartNo And Convert(BIGINT,I.ProductUidName) < @bItem_UidGenEndNo
	)  
END 
ELSE
BEGIN
    SET @bMaxItemUid=
	(
	SELECT IsNull(Max(Convert(BIGINT,I.ProductUidName)),@bItem_UidGenStartNo) FROM Web.ProductUids I  With (NoLock)  
	WHERE I.ProductUidHeaderId IS NOT NULL 	
	)  
END 


SET @I = 0
 
WHILE (@I < @ProductQty)
BEGIN

   SET   @bItemUid = (isnull(@bMaxItemUid,0) + 1)
                                
   INSERT INTO @Results(ProductUidName) 
   VALUES(@bItemUid)  
 
 
    SET @bMaxItemUid = isnull(@bMaxItemUid,0) + 1
    Set @I = @I + 1
END 
                 
RETURN  
END


