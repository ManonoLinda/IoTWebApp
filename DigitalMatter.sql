CREATE DATABASE IoTDevicesTracking;
GO

USE IoTDevicesTracking;
GO

CREATE TABLE Firmware (
    FirmwareID INT IDENTITY(1,1) PRIMARY KEY,
    [Version] NVARCHAR(50) NOT NULL,
    ReleaseDate DATETIME NOT NULL
);

CREATE TABLE Devices (
    DeviceID INT IDENTITY(1,1) PRIMARY KEY,
    DeviceName NVARCHAR(100) NOT NULL,
    FirmwareID INT NOT NULL,
    FOREIGN KEY (FirmwareID) REFERENCES Firmware(FirmwareID)
);


CREATE TABLE Groups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(100) NOT NULL,
    ParentGroupID INT NULL,
    FOREIGN KEY (ParentGroupID) REFERENCES Groups(GroupID)
);

CREATE TABLE GroupDevices (
    GroupDeviceID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    DeviceID INT NOT NULL,
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (DeviceID) REFERENCES Devices(DeviceID)
);

INSERT INTO Firmware ([Version], ReleaseDate) VALUES 
('1.0.4', '2021-01-01'),
('1.1.4', '2022-01-01'),
('2.1.0', '2022-01-01'),
('2.0.5', '2023-01-01');

INSERT INTO Devices (DeviceName, FirmwareID) VALUES 
('Sensor A', 1),
('Sensor B', 2),
('Tracker A', 3),
('Tracker B', 4);


INSERT INTO Groups (GroupName, ParentGroupID)
VALUES
('Company Headquarters', NULL),
('IT Department', 1),
('Sales Department', 1),
('Field Operations', NULL),
('Regional Office A', 4),
('Regional Office B', 4);   

INSERT INTO GroupDevices (GroupID, DeviceID) VALUES 
(1, 1),
(2, 2),
(3, 3);
