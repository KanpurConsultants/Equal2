CREATE Procedure [Web].spJobOrderLineService_GetJobRate_GetJobOrderRate 
(@JobOrderHeaderId INT, @ProductId INT)
AS
BEGIN

DECLARE @ProcessId INT;
DECLARE @DivisionId INT;
DECLARE @SiteId INT;
DECLARE @PersonRateGroupId INT;
DECLARE @DocDate SMALLDATETIME;


SELECT @ProcessId = H.ProcessId, @DivisionId = H.DivisionId, @SiteId = H.SiteId, 
@PersonRateGroupId = IsNull(Be.PersonRateGroupId,''), @DocDate = H.DocDate
FROM Web.JobOrderHeaders H 
--LEFT JOIN Web.BusinessEntities Be ON H.JobWorkerId = Be.PersonID
LEFT JOIN Web.PersonProcesses Be ON H.JobWorkerId = Be.PersonID AND H.ProcessId = Be.ProcessId
WHERE H.JobOrderHeaderId = @JobOrderHeaderid

DECLARE @TempTable TABLE (ProductId INT , Rate DECIMAL (18,4), Incentive DECIMAL (18,4), WEF SMALLDATETIME, WeightageGreaterOrEqual DECIMAL(18,4) )

INSERT INTO @TempTable (ProductId, Rate, Incentive, WEF, WeightageGreaterOrEqual)
SELECT P.ProductId,
CASE WHEN Rl1.Rate IS NOT NULL THEN Rl1.Rate
	 WHEN Rl2.Rate IS NOT NULL THEN Rl2.Rate
	 WHEN Rl3.Rate IS NOT NULL THEN Rl3.Rate 
	 WHEN Rl4.Rate IS NOT NULL THEN Rl4.Rate 
	 WHEN Rl5.Rate IS NOT NULL THEN Rl5.Rate 
	 WHEN Rl6.Rate IS NOT NULL THEN Rl6.Rate 
	 ELSE 0 END AS Rate,
CASE WHEN Rl1.Incentive IS NOT NULL THEN Rl1.Incentive
	 WHEN Rl2.Incentive IS NOT NULL THEN Rl2.Incentive
	 WHEN Rl3.Incentive IS NOT NULL THEN Rl3.Incentive 
	 WHEN Rl4.Incentive IS NOT NULL THEN Rl4.Incentive 
	 WHEN Rl5.Incentive IS NOT NULL THEN Rl5.Incentive
	 WHEN Rl6.Incentive IS NOT NULL THEN Rl6.Incentive
	 ELSE 0 END AS Incentive,
CASE WHEN Rl1.Rate IS NOT NULL THEN Rl1.EffectiveDate
	 WHEN Rl2.Rate IS NOT NULL THEN Rl2.EffectiveDate
	 WHEN Rl3.Rate IS NOT NULL THEN Rl3.EffectiveDate 
	 WHEN Rl4.Rate IS NOT NULL THEN Rl4.EffectiveDate 
	 WHEN Rl5.Rate IS NOT NULL THEN Rl5.EffectiveDate 
	 WHEN Rl6.Rate IS NOT NULL THEN Rl6.EffectiveDate 
	 ELSE getdate() END AS WEF,
CASE WHEN Rl1.WeightageGreaterOrEqual IS NOT NULL THEN Rl1.WeightageGreaterOrEqual
	 WHEN Rl2.WeightageGreaterOrEqual IS NOT NULL THEN Rl2.WeightageGreaterOrEqual
	 WHEN Rl3.WeightageGreaterOrEqual IS NOT NULL THEN Rl3.WeightageGreaterOrEqual 
	 WHEN Rl4.WeightageGreaterOrEqual IS NOT NULL THEN Rl4.WeightageGreaterOrEqual 
	 WHEN Rl5.WeightageGreaterOrEqual IS NOT NULL THEN Rl5.WeightageGreaterOrEqual 
	 WHEN Rl6.WeightageGreaterOrEqual IS NOT NULL THEN Rl6.WeightageGreaterOrEqual 
	 ELSE 0 END AS WeightageGreaterOrEqual
FROM (SELECT * FROM Web.Products WHERE ProductId = @ProductId) AS P 
LEFT JOIN Web.ViewProductSize Vrs ON P.ProductId = Vrs.ProductId
LEFT JOIN (SELECT * FROM Web.ProductProcesses WHERE ProcessId = @ProcessId) AS Pp ON P.ProductId = Pp.ProductId
LEFT JOIN (
		SELECT H.EffectiveDate, H.WeightageGreaterOrEqual, L.*
		FROM Web.RateListHeaders H 
		LEFT JOIN Web.RateListLines L ON H.RateListHeaderId = L.RateListHeaderId
		WHERE H.DivisionId = @DivisionId AND H.SiteId = @SiteId AND H.ProcessId = @ProcessId) AS Rl1 
	ON IsNull(Rl1.PersonRateGroupId,'') = @PersonRateGroupId
	AND Rl1.WeightageGreaterOrEqual <= Web.FConvertSqFeetToSqYard(Vrs.FinishingSizeArea) 
	AND Rl1.ProductId  = P.ProductId
	AND Rl1.EffectiveDate <= @DocDate
LEFT JOIN (
		SELECT H.EffectiveDate, H.WeightageGreaterOrEqual, L.*
		FROM Web.RateListHeaders H 
		LEFT JOIN Web.RateListLines L ON H.RateListHeaderId = L.RateListHeaderId
		WHERE H.DivisionId = @DivisionId AND H.SiteId = @SiteId AND H.ProcessId = @ProcessId) AS Rl2 
	ON Rl1.Rate IS NULL 
	AND IsNull(Rl2.PersonRateGroupId,'') = @PersonRateGroupId
	AND Rl2.WeightageGreaterOrEqual <= Web.FConvertSqFeetToSqYard(Vrs.FinishingSizeArea) 
	AND Rl2.ProductRateGroupId = Pp.ProductRateGroupId
	AND Rl2.EffectiveDate <= @DocDate
LEFT JOIN (
		SELECT H.EffectiveDate, H.WeightageGreaterOrEqual, L.*
		FROM Web.RateListHeaders H 
		LEFT JOIN Web.RateListLines L ON H.RateListHeaderId = L.RateListHeaderId
		WHERE H.DivisionId = @DivisionId AND H.SiteId = @SiteId AND H.ProcessId = @ProcessId) AS Rl3 
	ON Rl2.Rate IS NULL 
	AND Rl3.ProductId IS NULL
	AND Rl3.ProductRateGroupId IS NULL
	AND IsNull(Rl3.PersonRateGroupId,'') = @PersonRateGroupId
	AND Rl3.WeightageGreaterOrEqual <= Web.FConvertSqFeetToSqYard(Vrs.FinishingSizeArea) 
	AND Rl3.EffectiveDate <= @DocDate
LEFT JOIN (
		SELECT H.EffectiveDate, H.WeightageGreaterOrEqual, L.*
		FROM Web.RateListHeaders H 
		LEFT JOIN Web.RateListLines L ON H.RateListHeaderId = L.RateListHeaderId
		WHERE H.DivisionId = @DivisionId AND H.SiteId = @SiteId AND H.ProcessId = @ProcessId) AS Rl4 
	ON Rl3.Rate IS NULL 
	AND Rl4.PersonRateGroupId IS NULL
	AND Rl4.WeightageGreaterOrEqual <= Web.FConvertSqFeetToSqYard(Vrs.FinishingSizeArea) 
	AND Rl4.ProductId = P.ProductId 
	AND Rl4.EffectiveDate <= @DocDate
LEFT JOIN (
		SELECT H.EffectiveDate, H.WeightageGreaterOrEqual, L.*
		FROM Web.RateListHeaders H 
		LEFT JOIN Web.RateListLines L ON H.RateListHeaderId = L.RateListHeaderId
		WHERE H.DivisionId = @DivisionId AND H.SiteId = @SiteId AND H.ProcessId = @ProcessId) AS Rl5
	ON Rl4.Rate IS NULL 
	AND Rl5.PersonRateGroupId IS NULL
	AND Rl5.WeightageGreaterOrEqual <= Web.FConvertSqFeetToSqYard(Vrs.FinishingSizeArea) 
	AND Rl5.ProductRateGroupId = Pp.ProductRateGroupId
	AND Rl5.EffectiveDate <= @DocDate
LEFT JOIN (
		SELECT H.EffectiveDate, H.WeightageGreaterOrEqual, L.*
		FROM Web.RateListHeaders H 
		LEFT JOIN Web.RateListLines L ON H.RateListHeaderId = L.RateListHeaderId
		WHERE H.DivisionId = @DivisionId AND H.SiteId = @SiteId AND H.ProcessId = @ProcessId) AS Rl6
	ON Rl5.Rate IS NULL 
	AND Rl6.ProductId IS NULL
	AND Rl6.ProductRateGroupId IS NULL
	AND Rl6.PersonRateGroupId IS NULL
	AND Rl6.WeightageGreaterOrEqual <= Web.FConvertSqFeetToSqYard(Vrs.FinishingSizeArea) 
	AND Rl6.EffectiveDate <= @DocDate




SELECT V1.ProductId, VJLR.Rate, VJLR.Incentive AS IncentiveRate
FROM (
	SELECT ProductId, Max(WEF) AS WEF, Max(IsNull(WeightageGreaterOrEqual,0)) AS WeightageGreaterOrEqual
	FROM @TempTable L 
	GROUP BY ProductId
) AS V1 
LEFT JOIN @TempTable VJLR ON V1.ProductId = VJLR.ProductId AND V1.WEF = VJLR.WEF
		AND IsNull(V1.WeightageGreaterOrEqual,0) = IsNull(VJLR.WeightageGreaterOrEqual,0)

END


