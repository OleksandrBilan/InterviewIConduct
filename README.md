# InterviewIConduct

The task is:
Implement 2  REST API functions.
1.	GetEmplyeeByID – should return an Employee in a tree structure, like on a picture in archive.
2.	EnableEmployee – should change ‘Enable’ flag for the Employee.

Requirement: not to use EntityFramework, only ADO.NET
 
In the database ‘Employee’ table has the following structure:
 
ID (int)	Name(varchar)	ManagerID (int)	Enable (bit)
  1	          Andrey	      NULL	            1
  2	          Alexey	        2	              1
  3	          Roman	          2	              1
..	…	…	   
