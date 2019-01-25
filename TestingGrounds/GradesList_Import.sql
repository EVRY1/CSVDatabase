BULK INSERT GradesList
FROM 'C:\Users\octav_000.TOSHIBA\source\repos\TestingGrounds\TestingGrounds\GradesList.csv' /*Modify with the right path.*/
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n'
);