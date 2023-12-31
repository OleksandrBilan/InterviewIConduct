USE [Employees]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetEmployeeByID] @EmployeeID int
AS
BEGIN
	SET NOCOUNT ON;

    WITH RecursiveEmployee (ID, Name, ManagerID, Enable) AS (
	SELECT ID, Name, ManagerID, Enable
	FROM Employee
	WHERE ID = @EmployeeID

	UNION ALL

	SELECT e.ID, e.Name, e.ManagerID, e.Enable
	FROM Employee e
	INNER JOIN RecursiveEmployee re ON e.ManagerID = re.ID
	)
	SELECT ID, Name, ManagerID, Enable FROM RecursiveEmployee;
END
