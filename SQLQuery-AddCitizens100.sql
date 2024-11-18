USE nobatdehi;

DECLARE @FirstNames TABLE (Name NVARCHAR(50));
DECLARE @LastNames TABLE (Name NVARCHAR(50));

-- اضافه کردن اسامی افغانستانی به جداول موقت
INSERT INTO @FirstNames VALUES 
(N'احمد'), (N'محمد'), (N'علی'), (N'نور'), (N'حسین'), (N'کریم'), (N'جعفر'), (N'عباس'), (N'سلیم'), (N'منصور');
INSERT INTO @LastNames VALUES 
(N'احمدی'), (N'محمدی'), (N'علی‌زاده'), (N'نورزاد'), (N'حسینی'), (N'کریمی'), (N'جعفری'), (N'عباسی'), (N'سلیمی'), (N'منصوری');

-- ایجاد 50 رکورد
INSERT INTO [member].citizens (FirstName, LastName, Nationality, Passport, ExclusiveCode, HouseholdCode, UniqCode)
SELECT 
    f.Name AS FirstName,
    l.Name AS LastName,
    N'افغانستان' AS Nationality,
    CHAR((ABS(CHECKSUM(NEWID())) % 26) + 65) + CHAR((ABS(CHECKSUM(NEWID())) % 26) + 65) + 
    CAST(ABS(CHECKSUM(NEWID())) % 9000000 + 100000 AS NVARCHAR(7)) AS Passport,
    RIGHT('0000000000' + CAST(ABS(CHECKSUM(NEWID())) % 100000000000 AS NVARCHAR(12)), 12) AS ExclusiveCode,
    RIGHT('000000000' + CAST(ABS(CHECKSUM(NEWID())) % 1000000000 AS NVARCHAR(10)), 10) AS HouseholdCode,
    '9' + RIGHT('000000000' + CAST(ABS(CHECKSUM(NEWID())) % 1000000000 AS NVARCHAR(10)), 9) AS UniqCode
FROM 
    (SELECT TOP 50 Name FROM @FirstNames ORDER BY NEWID()) f
    CROSS JOIN 
    (SELECT TOP 50 Name FROM @LastNames ORDER BY NEWID()) l;
