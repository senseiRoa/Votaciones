


ALTER TABLE control_voto_votante DROP CONSTRAINT "FK_control_voto_votante_votacion_votante_IdVotacionVotante";

DROP INDEX "IX_control_voto_votante_IdVotacionVotante";

ALTER TABLE control_voto_votante DROP COLUMN "IdVotacionVotante";

ALTER TABLE control_voto_votante ADD "IdRondaVotante" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE candidato ADD "urlImage" text NULL;

CREATE INDEX "IX_control_voto_votante_IdRondaVotante" ON control_voto_votante ("IdRondaVotante");

ALTER TABLE control_voto_votante ADD CONSTRAINT "FK_control_voto_votante_ronda_votante_IdRondaVotante" FOREIGN KEY ("IdRondaVotante") REFERENCES ronda_votante (id) ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200604032506_migracion03062020cambioEsquema', '3.1.3');

