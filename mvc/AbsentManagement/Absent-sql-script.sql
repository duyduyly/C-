
use StudentAbsentLog;


create table Person(
	id bigint IDENTITY(1,1) PRIMARY KEY ,
	subject_name varchar(100),
	person_type int NOT NULL,
	created_at datetime ,
	created_by bigInt ,
	updated_at datetime,
	updated_by bigint
	--fk--
);

create table Information(
	first_name varchar(50),
	last_name varchar(50),
	birthday datetime,
	address varchar(200),
	avartar_url text,
	created_at datetime ,
	created_by bigInt ,
	updated_at datetime,
	updated_by bigint

	--fk--
);

create table DayOff(
	id bigInt IDENTITY(1,1) PRIMARY KEY,
	approve_status int NOT NULL,
	date_from datetime NOT NULL,
	date_to datetime NOT NULL,
	reason text NOT NULL,
	approve_person bigInt NOT NULL,
	created_at datetime ,
	created_by bigInt ,
	updated_at datetime,
	updated_by bigint

	--fk--
);

create table Account(
	id bigInt IDENTITY(1,1) PRIMARY KEY,
	username varchar(100) NOT NULL,
	password varchar(100) NOT NULL,
	email varchar(100) NOT NULL,
	phone_number varchar(15),
	account_role int NOT NULL,
	created_at datetime ,
	created_by bigInt ,
	updated_at datetime,
	updated_by bigint

	--fk--
);


--Person 1-1 Information--
ALTER table Information add person_id bigint primary key

ALTER TABLE Information
ADD CONSTRAINT FKInformationPerson
FOREIGN KEY (person_id) REFERENCES Person(id);


--person 1-n dayoff--
Alter table DayOff  add person_id bigInt NOT NULL

ALTER table DayOff 
ADD CONSTRAINT FKDayOffStudent
FOREIGN KEY (person_id) REFERENCES Person(id)


--account 1-n teacher--
alter table Person add account_id bigInt NOT NULL

ALTER TABLE Person
ADD CONSTRAINT FKPersonAccount
FOREIGN KEY (account_id) REFERENCES Account(id);


--Insert--
INSERT INTO Account(username, password, email, phone_number, account_role)
	VALUES('client', '123456', 'client@gmail.com','0931044546', 0),
	('admin', '123456', 'admin@gmail.com','0931044546', 1);


INSERT INTO Person(subject_name, person_type, account_id)
	VALUES('Math', 0, 1),
		  ('Math', 1, 2);

INSERT INTO Information(first_name, last_name, birthday, address, person_id)
	VALUES('Student', 'Ly', '5/21/2013 9:45:48 AM', 'Can Kho', 1),
	('Teacher', 'Ly', '5/21/2013 9:45:48 AM', 'Can Kho', 2)

INSERT INTO DayOff(approve_status, date_from, date_to, reason, approve_person, person_id)
	VALUES(0, '5/21/2013 9:45:48 AM', '5/21/2013 9:45:48 AM', 'I need visit my parent in Da Lat City', 2, 1);









