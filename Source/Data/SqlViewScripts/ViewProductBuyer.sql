CREATE VIEW Web.ViewProductBuyer
AS 
SELECT Pb.ProductId, IsNull(Pb.BuyerSku, P.ProductName) AS ProductName, Pb.BuyerSku, Pb.BuyerSpecification, 
Pb.BuyerSpecification1,
Pb.BuyerSpecification2, Pb.BuyerSpecification3, Pb.BuyerId
FROM Web.ProductBuyers Pb 
LEFT JOIN Web.Products P ON Pb.ProductId = P.ProductId