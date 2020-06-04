﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256) NULL,
    "NormalizedName" character varying(256) NULL,
    "ConcurrencyStamp" text NULL,
    CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
);

CREATE TABLE "AspNetUsers" (
    "Id" text NOT NULL,
    "UserName" character varying(256) NULL,
    "NormalizedUserName" character varying(256) NULL,
    "Email" character varying(256) NULL,
    "NormalizedEmail" character varying(256) NULL,
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text NULL,
    "SecurityStamp" text NULL,
    "ConcurrencyStamp" text NULL,
    "PhoneNumber" text NULL,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone NULL,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL,
    CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
);

CREATE TABLE "DeviceCodes" (
    "UserCode" character varying(200) NOT NULL,
    "DeviceCode" character varying(200) NOT NULL,
    "SubjectId" character varying(200) NULL,
    "ClientId" character varying(200) NOT NULL,
    "CreationTime" timestamp without time zone NOT NULL,
    "Expiration" timestamp without time zone NOT NULL,
    "Data" character varying(50000) NOT NULL,
    CONSTRAINT "PK_DeviceCodes" PRIMARY KEY ("UserCode")
);

CREATE TABLE "PersistedGrants" (
    "Key" character varying(200) NOT NULL,
    "Type" character varying(50) NOT NULL,
    "SubjectId" character varying(200) NULL,
    "ClientId" character varying(200) NOT NULL,
    "CreationTime" timestamp without time zone NOT NULL,
    "Expiration" timestamp without time zone NULL,
    "Data" character varying(50000) NOT NULL,
    CONSTRAINT "PK_PersistedGrants" PRIMARY KEY ("Key")
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "RoleId" text NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "UserId" text NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" character varying(128) NOT NULL,
    "ProviderKey" character varying(128) NOT NULL,
    "ProviderDisplayName" text NULL,
    "UserId" text NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" character varying(128) NOT NULL,
    "Name" character varying(128) NOT NULL,
    "Value" text NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

CREATE UNIQUE INDEX "IX_DeviceCodes_DeviceCode" ON "DeviceCodes" ("DeviceCode");

CREATE INDEX "IX_DeviceCodes_Expiration" ON "DeviceCodes" ("Expiration");

CREATE INDEX "IX_PersistedGrants_Expiration" ON "PersistedGrants" ("Expiration");

CREATE INDEX "IX_PersistedGrants_SubjectId_ClientId_Type" ON "PersistedGrants" ("SubjectId", "ClientId", "Type");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200509032016_configuracionSchemaInicial', '3.1.3');

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE votacion (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "Nombre" text NULL,
    CONSTRAINT "PK_votacion" PRIMARY KEY (id)
);

CREATE TABLE ronda_votacion (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "Nombre" text NULL,
    "IdVotacion" uuid NOT NULL,
    CONSTRAINT "PK_ronda_votacion" PRIMARY KEY (id),
    CONSTRAINT "FK_ronda_votacion_votacion_IdVotacion" FOREIGN KEY ("IdVotacion") REFERENCES votacion (id) ON DELETE CASCADE
);

CREATE INDEX "IX_ronda_votacion_IdVotacion" ON ronda_votacion ("IdVotacion");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200509043043_addSchema', '3.1.3');

ALTER TABLE ronda_votacion DROP COLUMN "Nombre";

ALTER TABLE votacion ADD "Descripcion" text NULL;

ALTER TABLE votacion ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE votacion ADD "fechaFinal" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion ADD "fechaInicial" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE ronda_votacion ADD "Descripcion" text NULL;

ALTER TABLE ronda_votacion ADD "Estado" integer NOT NULL DEFAULT 0;

CREATE TABLE candidato (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "Nombre" text NULL,
    "Descripcion" text NULL,
    CONSTRAINT "PK_candidato" PRIMARY KEY (id)
);

CREATE TABLE votante (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "Nombre" text NULL,
    "Correo" text NULL,
    CONSTRAINT "PK_votante" PRIMARY KEY (id)
);

CREATE TABLE votacion_candidato (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "IdVotacion" uuid NOT NULL,
    "IdCandidato" uuid NOT NULL,
    "VotanteId" uuid NULL,
    CONSTRAINT "PK_votacion_candidato" PRIMARY KEY (id),
    CONSTRAINT "FK_votacion_candidato_votacion_IdVotacion" FOREIGN KEY ("IdVotacion") REFERENCES votacion (id) ON DELETE CASCADE,
    CONSTRAINT "FK_votacion_candidato_candidato_VotanteId" FOREIGN KEY ("VotanteId") REFERENCES candidato (id) ON DELETE RESTRICT
);

CREATE TABLE votacion_votante (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "IdVotacion" uuid NOT NULL,
    "IdVotante" uuid NOT NULL,
    CONSTRAINT "PK_votacion_votante" PRIMARY KEY (id),
    CONSTRAINT "FK_votacion_votante_votacion_IdVotacion" FOREIGN KEY ("IdVotacion") REFERENCES votacion (id) ON DELETE CASCADE,
    CONSTRAINT "FK_votacion_votante_votante_IdVotante" FOREIGN KEY ("IdVotante") REFERENCES votante (id) ON DELETE CASCADE
);

CREATE TABLE ronda_candidato (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "IdRondaVotacion" uuid NOT NULL,
    "IdVotacionCandidato" uuid NOT NULL,
    CONSTRAINT "PK_ronda_candidato" PRIMARY KEY (id),
    CONSTRAINT "FK_ronda_candidato_ronda_votacion_IdRondaVotacion" FOREIGN KEY ("IdRondaVotacion") REFERENCES ronda_votacion (id) ON DELETE CASCADE,
    CONSTRAINT "FK_ronda_candidato_votacion_candidato_IdVotacionCandidato" FOREIGN KEY ("IdVotacionCandidato") REFERENCES votacion_candidato (id) ON DELETE CASCADE
);

CREATE TABLE control_voto_votante (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "IdRondaVotacion" uuid NOT NULL,
    "IdVotacionVotante" uuid NOT NULL,
    CONSTRAINT "PK_control_voto_votante" PRIMARY KEY (id),
    CONSTRAINT "FK_control_voto_votante_ronda_votacion_IdRondaVotacion" FOREIGN KEY ("IdRondaVotacion") REFERENCES ronda_votacion (id) ON DELETE CASCADE,
    CONSTRAINT "FK_control_voto_votante_votacion_votante_IdVotacionVotante" FOREIGN KEY ("IdVotacionVotante") REFERENCES votacion_votante (id) ON DELETE CASCADE
);

CREATE TABLE voto_ronda (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    _hash text NULL,
    "idRondaCandidato" uuid NOT NULL,
    CONSTRAINT "PK_voto_ronda" PRIMARY KEY (id),
    CONSTRAINT "FK_voto_ronda_ronda_candidato_idRondaCandidato" FOREIGN KEY ("idRondaCandidato") REFERENCES ronda_candidato (id) ON DELETE CASCADE
);

CREATE INDEX "IX_control_voto_votante_IdRondaVotacion" ON control_voto_votante ("IdRondaVotacion");

CREATE INDEX "IX_control_voto_votante_IdVotacionVotante" ON control_voto_votante ("IdVotacionVotante");

CREATE INDEX "IX_ronda_candidato_IdRondaVotacion" ON ronda_candidato ("IdRondaVotacion");

CREATE INDEX "IX_ronda_candidato_IdVotacionCandidato" ON ronda_candidato ("IdVotacionCandidato");

CREATE INDEX "IX_votacion_candidato_IdVotacion" ON votacion_candidato ("IdVotacion");

CREATE INDEX "IX_votacion_candidato_VotanteId" ON votacion_candidato ("VotanteId");

CREATE INDEX "IX_votacion_votante_IdVotacion" ON votacion_votante ("IdVotacion");

CREATE INDEX "IX_votacion_votante_IdVotante" ON votacion_votante ("IdVotante");

CREATE INDEX "IX_voto_ronda_idRondaCandidato" ON voto_ronda ("idRondaCandidato");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200509052430_addSchemaCompleta', '3.1.3');

ALTER TABLE votante ADD "RolId" text NULL;

ALTER TABLE votante ADD "UserId" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200509181136_actualizacionVotante', '3.1.3');

ALTER TABLE voto_ronda ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE voto_ronda ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE voto_ronda ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE voto_ronda ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE votante ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE votante ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votante ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votante ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE votacion_votante ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE votacion_votante ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion_votante ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion_votante ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE votacion_candidato ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE votacion_candidato ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion_candidato ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion_candidato ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE votacion ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE votacion ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE ronda_votacion ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE ronda_votacion ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE ronda_votacion ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE ronda_candidato ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE ronda_candidato ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE ronda_candidato ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE ronda_candidato ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE control_voto_votante ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE control_voto_votante ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE control_voto_votante ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE control_voto_votante ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE candidato ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE candidato ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE candidato ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE candidato ADD "fechaEliminacion" timestamp without time zone NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200510232937_addTrazabilidad', '3.1.3');

ALTER TABLE voto_ronda DROP COLUMN "Estado";

ALTER TABLE votante DROP COLUMN "Estado";

ALTER TABLE votacion_votante DROP COLUMN "Estado";

ALTER TABLE votacion_candidato DROP COLUMN "Estado";

ALTER TABLE ronda_candidato DROP COLUMN "Estado";

ALTER TABLE control_voto_votante DROP COLUMN "Estado";

ALTER TABLE candidato DROP COLUMN "Estado";

ALTER TABLE voto_ronda ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE votante ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE votacion_votante ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE votacion_candidato ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE votacion ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE ronda_votacion ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE ronda_candidato ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE control_voto_votante ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

ALTER TABLE candidato ADD "EstadoRegistro" integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200510233208_addTrazabilidad2', '3.1.3');

ALTER TABLE votacion_candidato DROP CONSTRAINT "FK_votacion_candidato_candidato_VotanteId";

ALTER TABLE voto_ronda DROP CONSTRAINT "FK_voto_ronda_ronda_candidato_idRondaCandidato";

DROP INDEX "IX_votacion_candidato_VotanteId";

ALTER TABLE votacion_candidato DROP COLUMN "VotanteId";

ALTER TABLE voto_ronda ALTER COLUMN "idRondaCandidato" TYPE uuid;
ALTER TABLE voto_ronda ALTER COLUMN "idRondaCandidato" DROP NOT NULL;
ALTER TABLE voto_ronda ALTER COLUMN "idRondaCandidato" DROP DEFAULT;

ALTER TABLE voto_ronda ADD "IdRondaVotacion" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

CREATE INDEX "IX_voto_ronda_IdRondaVotacion" ON voto_ronda ("IdRondaVotacion");

CREATE INDEX "IX_votacion_candidato_IdCandidato" ON votacion_candidato ("IdCandidato");

ALTER TABLE votacion_candidato ADD CONSTRAINT "FK_votacion_candidato_candidato_IdCandidato" FOREIGN KEY ("IdCandidato") REFERENCES candidato (id) ON DELETE CASCADE;

ALTER TABLE voto_ronda ADD CONSTRAINT "FK_voto_ronda_ronda_votacion_IdRondaVotacion" FOREIGN KEY ("IdRondaVotacion") REFERENCES ronda_votacion (id) ON DELETE CASCADE;

ALTER TABLE voto_ronda ADD CONSTRAINT "FK_voto_ronda_ronda_candidato_idRondaCandidato" FOREIGN KEY ("idRondaCandidato") REFERENCES ronda_candidato (id) ON DELETE RESTRICT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200512130224_actualizacion12052020', '3.1.3');

CREATE TABLE ronda_votante (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "EstadoRegistro" integer NOT NULL,
    "fechaCreacion" timestamp without time zone NOT NULL,
    "fechaEdicion" timestamp without time zone NOT NULL,
    "fechaEliminacion" timestamp without time zone NULL,
    "IdRondaVotacion" uuid NOT NULL,
    "IdVotacionVotante" uuid NOT NULL,
    CONSTRAINT "PK_ronda_votante" PRIMARY KEY (id),
    CONSTRAINT "FK_ronda_votante_ronda_votacion_IdRondaVotacion" FOREIGN KEY ("IdRondaVotacion") REFERENCES ronda_votacion (id) ON DELETE CASCADE,
    CONSTRAINT "FK_ronda_votante_votacion_votante_IdVotacionVotante" FOREIGN KEY ("IdVotacionVotante") REFERENCES votacion_votante (id) ON DELETE CASCADE
);

CREATE INDEX "IX_ronda_votante_IdRondaVotacion" ON ronda_votante ("IdRondaVotacion");

CREATE INDEX "IX_ronda_votante_IdVotacionVotante" ON ronda_votante ("IdVotacionVotante");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200603202520_migracion03062020', '3.1.3');

ALTER TABLE control_voto_votante DROP CONSTRAINT "FK_control_voto_votante_votacion_votante_IdVotacionVotante";

DROP INDEX "IX_control_voto_votante_IdVotacionVotante";

ALTER TABLE control_voto_votante DROP COLUMN "IdVotacionVotante";

ALTER TABLE control_voto_votante ADD "IdRondaVotante" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE candidato ADD "urlImage" text NULL;

CREATE INDEX "IX_control_voto_votante_IdRondaVotante" ON control_voto_votante ("IdRondaVotante");

ALTER TABLE control_voto_votante ADD CONSTRAINT "FK_control_voto_votante_ronda_votante_IdRondaVotante" FOREIGN KEY ("IdRondaVotante") REFERENCES ronda_votante (id) ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200604032506_migracion03062020cambioEsquema', '3.1.3');

