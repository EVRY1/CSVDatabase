BULK INSERT GradesList
FROM 'C:\Users\octav_000.TOSHIBA\source\repos\TestingGrounds\TestingGrounds\GradesList.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n'
);