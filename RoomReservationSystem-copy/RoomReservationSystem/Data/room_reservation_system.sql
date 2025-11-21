BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "customer" (
	"customer_id"	INTEGER,
	"name"	TEXT NOT NULL,
	"email"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("customer_id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "reservation" (
	"reservation_id"	INTEGER,
	"customer_id"	INTEGER NOT NULL,
	"room_id"	INTEGER NOT NULL,
	"start_date"	DATE NOT NULL,
	"end_date"	DATE NOT NULL,
	PRIMARY KEY("reservation_id" AUTOINCREMENT),
	FOREIGN KEY("customer_id") REFERENCES "customer"("customer_id"),
	FOREIGN KEY("room_id") REFERENCES "room"("room_id")
);
CREATE TABLE IF NOT EXISTS "room" (
	"room_id"	INTEGER,
	"room_type"	INTEGER,
	"status"	INTEGER NOT NULL DEFAULT 0,
	"pets_allowed"	INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY("room_id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "user" (
	"username"	TEXT NOT NULL,
	"password"	TEXT NOT NULL,
	PRIMARY KEY("username")
);
INSERT INTO "customer" VALUES (1,'Alice Johnson','alice.johnson@example.com');
INSERT INTO "customer" VALUES (2,'Bob Smith','bob.smith@example.com');
INSERT INTO "customer" VALUES (3,'Charlie Brown','charlie.brown@example.com');
INSERT INTO "customer" VALUES (4,'Diana Prince','diana.prince@example.com');
INSERT INTO "customer" VALUES (5,'Ethan Hunt','ethan.hunt@example.com');
INSERT INTO "room" VALUES (1,1,0,0);
INSERT INTO "room" VALUES (2,1,0,0);
INSERT INTO "room" VALUES (3,2,0,0);
INSERT INTO "room" VALUES (4,2,0,0);
INSERT INTO "room" VALUES (5,3,0,0);
INSERT INTO "reservation" VALUES (1,1,1,'2025-10-10','2025-10-12');
INSERT INTO "reservation" VALUES (2,1,2,'2025-10-15','2025-10-20');
INSERT INTO "reservation" VALUES (3,5,3,'2025-10-18','2025-10-22');
INSERT INTO "reservation" VALUES (4,5,4,'2025-10-20','2025-10-25');
INSERT INTO "reservation" VALUES (5,1,5,'2025-10-22','2025-10-29');
INSERT INTO "reservation" VALUES (6,1,1,'2025-10-13','2025-10-15');
INSERT INTO "reservation" VALUES (7,1,5,'2025-10-30','2025-10-30');
CREATE TRIGGER prevent_overlapping_reservations
BEFORE INSERT ON reservation
FOR EACH ROW
WHEN EXISTS(
	SELECT 1 FROM reservation existing
	WHERE new.room_id = existing.room_id
	AND new.start_date <= existing.end_date
	AND new.end_date >= existing.start_date
	)
BEGIN
	SELECT RAISE(ABORT, 'No overlapping reservations');
END;
COMMIT;
