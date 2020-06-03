
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

