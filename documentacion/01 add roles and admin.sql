insert into "AspNetRoles" values ('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11','Votante','','');
insert into "AspNetRoles" values ('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a12','Moderador','1','1');
insert into "AspNetRoles" values ('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13','Admin','2','2');


INSERT INTO "AspNetUsers" ("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") VALUES('4c7a74f4-fde0-428b-968f-1d19a2d09be6', 'Administrador  ', 'ADMIN@MAILINATOR.COM', 'admin@mailinator.com', 'ADMIN@MAILINATOR.COM', true, 'AQAAAAEAACcQAAAAEINQhuxXWIyZegMKOOS/gb/jBUCeN0XLNdILaCUZ0r2vChNporDUdnW58EESEkFkgQ==', 'ZQEQL24ONEDKMY6JCNIIDMXCJDJCNJCU', '134a2876-e2cf-44b6-a622-f5ad86909a31', NULL, false, false, NULL, true, 0);


insert into "AspNetUserRoles" values ('4c7a74f4-fde0-428b-968f-1d19a2d09be6','a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13');