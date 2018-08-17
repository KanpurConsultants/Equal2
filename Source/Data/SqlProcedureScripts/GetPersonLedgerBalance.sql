CREATE Procedure [Web].[GetPersonLedgerBalance] (@PersonId INT)
AS
BEGIN
	SELECT Round(IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0),2) AS Balance
	FROM Web.LedgerAccounts A 
	LEFT JOIN Web.Ledgers L ON A.LedgerAccountId = L.LedgerAccountId
	WHERE A.PersonId = @PersonId
END
