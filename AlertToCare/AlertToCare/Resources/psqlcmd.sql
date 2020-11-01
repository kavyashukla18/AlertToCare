create database "AlertToCare";
\c "AlertToCare"
CREATE TABLE "PatientInfo"(
   "PatientId" SERIAL PRIMARY KEY,
   "PatientName" TEXT NOT NULL, 
   "Email" TEXT NOT NULL,
   "Address" TEXT,
   "Mobile" char(10) NOT NULL
);


create table "MedicalDevice"("DeviceName" text primary key, "MinValue" int not null, "MaxValue" int not null);

CREATE TABLE "BedInformation"("BedId" TEXT PRIMARY KEY,"WardNumber" TEXT NOT NULL, "PatientId" INT DEFAULT NULL, "BedInRow" INT NOT NULL,"BedInColumn" INT NOT NULL, UNIQUE ("PatientId"), CONSTRAINT "FkPerson" FOREIGN KEY("PatientId") REFERENCES "PatientInfo"("PatientId"));



create table "BedOnAlert"("BedId" text, "DeviceName" text, "Value" int, CONSTRAINT "FkBed"
      FOREIGN KEY("BedId") 
	  REFERENCES "BedInformation"("BedId"),CONSTRAINT "FkDevice"
      FOREIGN KEY("DeviceName") 
	  REFERENCES "MedicalDevice"("DeviceName"),
	  PRIMARY KEY("BedId", "DeviceName"));


CREATE TABLE "IcuWardInformation"("WardNumber" TEXT PRIMARY KEY, "TotalBed" INT NOT NULL, 
"Department" TEXT NOT NULL);


