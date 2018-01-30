ALTER PROCEDURE USP_DeleteRegion
(
	@ID int
)
AS
BEGIN
	BEGIN TRY
		DELETE Region WHERE RegionID= @ID
		SELECT
		RegionID , RegionDescription
		FROM Region
	END TRY
	BEGIN CATCH
		PRINT 'DELETION FAILED'
	END CATCH	
END
GO

ALTER PROCEDURE USP_UpdateRegion
(
	@ID int,
	@Description nchar(50)
)
AS
BEGIN
	BEGIN TRY
		UPDATE Region SET
		RegionDescription= ISNULL(@Description,RegionDescription )
		WHERE RegionID = @ID
		SELECT
		RegionID , RegionDescription
		FROM Region
	END TRY
	BEGIN CATCH
		PRINT 'UPDATION FAILED'
	END CATCH	
END
GO

ALTER PROCEDURE USP_ViewRegion
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON
		SELECT
			RegionID , RegionDescription
			FROM Region
	END TRY
	BEGIN CATCH
		PRINT 'SELECTION FAILED'
	END CATCH
END

ALTER PROCEDURE USP_InsertRegion
(
	@RegionID int,
	@RegionDescription nchar(50) 
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO Region(RegionID,RegionDescription)  
		VALUES (@RegionID,@RegionDescription)
		SELECT
		RegionID , RegionDescription
		FROM Region
	END TRY
	BEGIN CATCH
		PRINT 'INSERTION FAILED'
	END CATCH
END
