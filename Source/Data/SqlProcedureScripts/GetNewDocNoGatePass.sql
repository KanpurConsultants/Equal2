CREATE Procedure [Web].[GetNewDocNoGatePass]
    @DocTypeId INT, @DocDate DATETIME, @GodownId INT
AS
BEGIN	
    DECLARE @GateId INT
    
    SET @GateId = ( SELECT GateId FROM WEb.Godowns G WITH (Nolock) WHERE G.GodownId = @GodownId )
    
	SELECT Convert(VARCHAR,IsNull(Max(Convert(NUMERIC,H.DocNo))+1,Replace(Convert(VARCHAR, @DocDate,2),'.','') + '0001'))  
	FROM Web.GatePassHeaders H
	LEFT JOIN web.Godowns G ON G.GodownId = H.GodownId
	WHERE H.DocDate =@DocDate AND H.DocTypeId = @DocTypeId AND G.GateId = @GateId	
END
