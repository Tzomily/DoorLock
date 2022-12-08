USE DoorLocks;

DROP TABLE IF EXISTS User;

CREATE TABLE User (
    Id varchar(36) NOT NULL,
    FirstName nvarchar(50) DEFAULT null,
    LastName varchar(50) DEFAULT null,
    Email varchar(50) DEFAULT NULL,
    Phone varchar(20) DEFAULT NULL,
    PRIMARY KEY (Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS Building;

CREATE TABLE Building(
    Id varchar(36) NOT NULL,
    Name varchar(50) DEFAULT null,
    PRIMARY KEY (Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS Door;

CREATE TABLE Door(
    Id varchar(36) NOT NULL,
    Name varchar(50) DEFAULT null,
    BuildingId varchar(36) NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY(BuildingId) REFERENCES Building(Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS Role;

CREATE TABLE Role(
    Id varchar(36) NOT NULL,
    Name varchar(36) NOT NULL,
    AccessLevel integer NOT NULL DEFAULT 0,
    BuildingId varchar(36) NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (BuildingId) REFERENCES Building(Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS UserRole;

CREATE TABLE UserRole(
    UserId varchar(36) NOT NULL,
    RoleId varchar(36) NOT NULL,
    PRIMARY KEY(RoleId, UserId),
    FOREIGN KEY (UserId) REFERENCES User(Id),
    FOREIGN KEY (RoleId) REFERENCES Role(Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS DoorRole;

CREATE TABLE DoorRole(
    DoorId varchar(36) NOT NULL,
    RoleId varchar(36) NOT NULL,
    PRIMARY KEY(DoorId, RoleId),
    FOREIGN KEY (DoorId) REFERENCES Door(Id),
    FOREIGN KEY (RoleId) REFERENCES Role(Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS History;

CREATE TABLE History(
    Id varchar(36) NOT NULL,
    BuildingId varchar(36) NOT NULL,
    DoorId varchar(36) NOT NULL,
    UserId varchar(36) NOT NULL,
    DateTime DATETIME NOT NULL,
    Status integer(50) NOT NULL,
    PRIMARY KEY (Id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;