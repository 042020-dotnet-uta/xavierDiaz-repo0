-- make database and tables

/*CREATE DATABASE newDb;
CREATE TABLE Employee (
    ID int,
    FirstName varchar(255),
	LastName varchar(255),
    SSN int,
    DeptID int
);
CREATE TABLE EmpDetails (
    EmployeeID int,
	Salary int,
    Address1 varchar(255),
	Address2 varchar(255),
    City varchar(255),
	EmpState varchar(255),
    Country varchar(255)
);
CREATE TABLE Department (
    ID int,
    DepName varchar(255),
    DepLocation varchar(255)
);*/

-- insert statements

/*INSERT INTO Employee (ID, FirstName, LastName, SSN, DeptID)
VALUES(1, 'Tina', 'Smith', 12345678, 1);
INSERT INTO Employee (ID, FirstName, LastName, SSN, DeptID)
VALUES(2, 'Tin', 'Smyth', 12345678, 2);
INSERT INTO Employee (ID, FirstName, LastName, SSN, DeptID)
VALUES(3, 'Tam', 'Smoth', 55555678, 3);
INSERT INTO Department (ID, DepName, DepLocation)
VALUES(1, 'Marketing', 'The Moon');
INSERT INTO Department (ID, DepName, DepLocation)
VALUES(2, 'Research', 'Right behind you');
INSERT INTO Department (ID, DepName, DepLocation)
VALUES(3, 'Slackers', 'The Couch');
INSERT INTO EMPDetails (EmployeeID, Salary, Address1, Address2, City, EmpState, Country)
VALUES(1,50, '10 her house way', null, 'her city', 'FD', 'USSRA');
INSERT INTO EMPDetails (EmployeeID, Salary, Address1, Address2, City, EmpState, Country)
VALUES(2,500, '15 home rd', '56 Gotham cr', 'a city', 'RX', 'The Shire');
INSERT INTO EMPDetails (EmployeeID, Salary, Address1, Address2, City, EmpState, Country)
VALUES(3,5000, '10 somewhere dr', null, 'kindof a city', 'PR', 'ASU');*/

-- Queries
SELECT a.FirstName FROM Employee a, Department b WHERE b.DepName = 'Marketing' AND a.DeptID = b.ID;
SELECT SUM(c.Salary) AS MarketingSalary FROM Employee a, Department b, EmpDetails c WHERE b.DepName = 'Marketing' AND c.EmployeeID = a.ID AND a.DeptID = b.ID;
SELECT Count(a.DeptID), b.DepName FROM Employee a, Department b WHERE a.DeptID = b.ID GROUP BY b.DepName;
UPDATE EmpDetails SET Salary = 90000 FROM EMPDetails a, Employee b WHERE b.FirstName = 'Tina' AND b.LastName = 'Smith' AND a.EmployeeID = b.ID;
SELECT * FROM EmpDetails;