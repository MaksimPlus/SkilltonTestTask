Для корректной работы проекта требуется создать базу данных EmployeeDB. В свойствах этого файла установить "Копировать в выходной каталог" - Всегда копировать. Запустить данный скрипт, который инициализирует таблицу, для созданной базы данных:
CREATE TABLE [dbo].[Employees] (
    [EmployeeID]  INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NOT NULL,
    [Email]       NVARCHAR (100) NOT NULL,
    [DateOfBirth] DATE           NOT NULL,
    [Salary]      DECIMAL (18)   NOT NULL,
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

