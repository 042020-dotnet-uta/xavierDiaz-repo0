SELECT FirstName AS NonUSCustFirst, CustomerId, Country FROM Customer WHERE Country  <>  'USA';
SELECT FirstName AS BrazCustFirst, LastName, CustomerId FROM Customer WHERE Country = 'Brazil'; 
SELECT FirstName AS AgentFirst, LastName, EmployeeId FROM Employee WHERE Title = 'Sales Support Agent';
SELECT BillingAddress, BillingCountry From Invoice ORDER BY BillingAddress;
SELECT COUNT(InvoiceId) AS InvoiceNum09, SUM(Total) AS SalesTotal09 From Invoice WHERE YEAR(InvoiceDate) = '2009';
SELECT COUNT(InvoiceId) AS LineItems37 FROM InvoiceLine WHERE InvoiceID = 37;
SELECT COUNT(InvoiceId) AS InvoiceCount, BillingCountry FROM Invoice GROUP BY BillingCountry;
SELECT SUM(Total) AS Sales, BillingCountry FROM Invoice GROUP BY BillingCountry ORDER BY SUM(Total) DESC;