### 1. Show the Top 10 Customers by Number of Orders

```sql
SELECT TOP 10 c.Id, c.FirstName, c.LastName, COUNT(o.Id) AS OrderCount
FROM Customers c
JOIN Orders o ON c.Id = o.CustomerId
GROUP BY c.Id, c.FirstName, c.LastName
ORDER BY COUNT(o.Id) DESC;
```

### 2. Show the Top 10 Products Ordered by Number of Orders and Display Product Information

```sql
SELECT TOP 10 p.Id, p.Name, p.Description, p.CurrentPrice, COUNT(oi.Id) AS OrderCount
FROM Products p
JOIN OrderItems oi ON p.Id = oi.ProductId
GROUP BY p.Id, p.Name, p.Description, p.CurrentPrice
ORDER BY COUNT(oi.Id) DESC;
```

### 3. Show the Top 10 Products Ordered by Number of Orders Using a Subquery

```sql
SELECT TOP 10 p.Id, p.Name, p.Description, p.CurrentPrice, q.OrderCount
FROM Products p
JOIN (
    SELECT ProductId, COUNT(*) AS OrderCount
    FROM OrderItems
    GROUP BY ProductId
) q ON p.Id = q.ProductId
ORDER BY q.OrderCount DESC;
```

### 4. Add a View to See the Top 5 Products Ordered in the Last 2 Years

```sql
CREATE VIEW ViewTop5ProductsLast2Years AS
SELECT TOP 5 p.Id, p.Name, COUNT(oi.Id) AS OrderCount
FROM Products p
JOIN OrderItems oi ON p.Id = oi.ProductId
JOIN Orders o ON oi.OrderId = o.Id
WHERE o.Date >= DATEADD(YEAR, -2, GETDATE())
GROUP BY p.Id, p.Name
ORDER BY COUNT(oi.Id) DESC;
```

### 5. Add a Stored Procedure to Update All Product Prices by 10 Percent in December, January, or February

```sql
CREATE PROCEDURE UpdateProductPricesInWinter
AS
BEGIN
    IF MONTH(GETDATE()) IN (12, 1, 2)
    BEGIN
        UPDATE Products
        SET CurrentPrice = CurrentPrice * 1.10;
    END
END;
```

### 6. Add a Trigger to Update Product Price When a New Order is Created

```sql
CREATE TRIGGER TriggerUpdateProductPriceOnNewOrder
ON Orders
AFTER INSERT
AS
BEGIN
    UPDATE Products
    SET CurrentPrice = CurrentPrice * 1.05
    WHERE Id IN (SELECT ProductId FROM Inserted i JOIN OrderItems oi ON i.Id = oi.OrderId);
END;
```

### 7. Add an Index on the Customers Table for the `Email` Column

```sql
CREATE NONCLUSTERED INDEX IDX_Customers_Email ON Customers(Email);
```
