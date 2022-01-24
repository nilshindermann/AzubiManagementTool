USE atm;

INSERT INTO lehrfirma VALUES (null, 'Uster Technologies', 'Sonnenbergstrasse 10', 'Uster', '8610');
INSERT INTO lehrfirma VALUES (null, 'libs', null, null, null);
INSERT INTO kontaktperson VALUES (null, (SELECT id FROM lehrfirma WHERE name = 'Uster Technologies' LIMIT 1), 'Koller' , 'Beat', 'beat.koller@uster.com', '+41 43 366 36 87');
INSERT INTO kontaktperson VALUES (null, (SELECT id FROM lehrfirma WHERE name = 'libs' LIMIT 1), 'Mitsche' , 'Albin', 'albin.mitsche@libs.ch', null);

INSERT INTO lernende VALUES (null, 'Hindermann', 'Nils', 'nils.hindermann@i-azo.ch', '2004-07-14', 'm', 'API', '2020/2021', 'TBZ', 'AP20c', 0, (SELECT id FROM lehrfirma WHERE name = 'Uster Technologies' LIMIT 1), '2020-08-17', '2022-01-26');
INSERT INTO lernende VALUES (null, 'Schiavone', 'Michele', 'michele.schiavone@i-azo.ch', '2004-06-18', 'm', 'BET', '2021/2022', 'TBZ', 'AP21b', 0, (SELECT id FROM lehrfirma WHERE name = 'libs' LIMIT 1), '2020-08-17', '2022-01-26');
INSERT INTO lernende VALUES (null, 'Samma', 'Zakria', 'zakria.samma@i-azo.ch', '2005-11-30', 'm', 'API', '2021/2022', 'TBZ', '?????', 0, (SELECT id FROM lehrfirma WHERE name = 'libs' LIMIT 1), '2020-08-17', '2022-01-26');

UPDATE lernende SET Geburtsdatum = '2005-11-30' WHERE Id = 3;
UPDATE lehrfirma SET Name = 'Zellweger' WHERE Name = 'Uster Technologies';

SELECT * FROM lehrfirma;
SELECT * FROM kontaktperson;
SELECT * FROM lernende;

SELECT DISTINCT f.Name AS Firma FROM lehrfirma f RIGHT JOIN lernende l ON l.IdLehrfirma = f.Id;
SELECT l.Name, f.Name AS Firma FROM lehrfirma f RIGHT JOIN lernende l ON l.IdLehrfirma = f.Id;

DELETE FROM lernende WHERE id >= 0;
DELETE FROM kontaktperson WHERE id >= 0;
DELETE FROM lehrfirma WHERE id >= 0;