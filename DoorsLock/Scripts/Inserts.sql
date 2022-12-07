insert into Building(Id,Name) values ('cf5a6ebf-aa5e-4b0a-bae5-74c99fbd458d', 'Building1');

insert into Door(Id,Name,BuildingId) values('7a1b2fb1-329b-4f25-a4d5-153c56dc48d7', 'Door1','cf5a6ebf-aa5e-4b0a-bae5-74c99fbd458d');

INSERT INTO `DoorLocks`.`User`
(`Id`,
`FirstName`,
`LastName`,
`Email`,
`Phone`)
VALUES
('9f55bac2-cc9d-453b-867b-a05792e907b0',
'user1',
'surname',
'user1@mail.com',
'6998989898');

INSERT INTO `DoorLocks`.`Role`
(`Id`,
`AccessLevel`,
`BuildingId`)
VALUES
('f6b1b3d9-5ec1-4b5e-a710-336322ca1ba5',
0,
'cf5a6ebf-aa5e-4b0a-bae5-74c99fbd458d');

INSERT INTO `DoorLocks`.`UserRole`
(`UserId`,
`RoleId`)
VALUES
('9f55bac2-cc9d-453b-867b-a05792e907b0',
'f6b1b3d9-5ec1-4b5e-a710-336322ca1ba5');

INSERT INTO `DoorLocks`.`DoorRole`
(`DoorId`,
`RoleId`)
VALUES
('7a1b2fb1-329b-4f25-a4d5-153c56dc48d7',
'f6b1b3d9-5ec1-4b5e-a710-336322ca1ba5');

INSERT INTO `DoorLocks`.`Role`
(`Id`,
`AccessLevel`,
`BuildingId`)
VALUES
('824bf376-dd7f-4793-9cf3-9e3fc90de532',
1,
'cf5a6ebf-aa5e-4b0a-bae5-74c99fbd458d');


