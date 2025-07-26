CREATE DATABASE BANCO;
GO
USE BANCO;
GO


CREATE TABLE User_Type(
	[user_type] VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE UserAccount (
    [id] BIGINT PRIMARY KEY IDENTITY(1000,1),
    [username] VARCHAR(50) UNIQUE NOT NULL,
    [password] VARCHAR(100) NOT NULL,
    [user_type] VARCHAR(50),
    [status] BIT NOT NULL DEFAULT 1

	FOREIGN KEY (user_type) references User_type(user_type)
);
GO

INSERT INTO User_Type (user_type) VALUES ('Cliente'),('Empleado'),('Admin')


INSERT INTO UserAccount (username,password,user_type)
VALUES ('ADMIN1','ADMINPASS','Admin'), ('USER1','USERPASS','Empleado')
