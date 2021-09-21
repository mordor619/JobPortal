# JobPortal


this project contains both admin and user sides.

user can apply for jobs and view his applied jobs and cancel their application.
filter option also available.

admin can create new job postings, edit and delete.


it contains logging features, dependency injection.



sql code


create database JobportalDI;

use JobportalDI;



create table logintbl(userid int primary key identity(1,1), fullname varchar(50), username varchar(30) unique, userpass varchar(20), usertype varchar(5));

insert into logintbl(fullname, username, userpass, usertype) values('Adam Worth', 'adam', 'abc123', 'Admin');
insert into logintbl(fullname, username, userpass, usertype) values('Matt Kramer', 'matt', 'xyz123', 'User');


select * from logintbl;






create table categories(id int primary key identity(1,1), name varchar(200));

insert into categories(name) values('business'), ('retail'), ('technology'), ('construction');

select * from categories;






create table jobs(id int primary key identity(1,1), userid int, cid int, company varchar(200), job_title varchar(200), description varchar(200),
salary int, location varchar(200), contact_user varchar(200), contact_email varchar(200));

insert into jobs(userid, cid, company, job_title, description, salary, location, contact_user, contact_email)
values(1, 4, 'Google', 'Senior Programmer', 'Lorem ipsum', 10000, 'Mumbai', 'anwar', 'anwar@gmail.com');

select * from jobs;





create table myjobs(id int primary key identity(1,1), userid int, cid int, company varchar(200), job_title varchar(200), description varchar(200),
salary int, location varchar(200), contact_user varchar(200), contact_email varchar(200));

select * from myjobs;






insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Vinder', 'Help Desk Operator', 'User-centric 24/7 complexity', 55708, 'Ruihong', 'Jacky Chastel', 'jchastel0@edublogs.org');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 1, 'Voomm', 'VP Sales', 'Grass-roots 4th generation challenge', 85988, 'Lianyuan', 'Theo Strangwood', 'tstrangwood1@google.nl');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Skiptube', 'Office Assistant IV', 'Triple-buffered eco-centric implementation', 39500, 'Portachuelo', 'Brocky Acland', 'bacland2@buzzfeed.com');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (2, 3, 'Shufflebeat', 'Community Outreach Specialist', 'Multi-layered 3rd generation info-mediaries', 45603, 'Cuenca', 'Joseito Skitch', 'jskitch3@php.net');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Linkbuzz', 'Paralegal', 'Ergonomic hybrid complexity', 73945, 'Yizhivtsi', 'Brigit Loughlin', 'bloughlin4@cyberchimps.com');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (2, 2, 'Mydeo', 'Account Representative III', 'Object-based homogeneous standardization', 37942, 'Sumurwaru', 'Ardene McLeary', 'amcleary5@ucsd.edu');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Kwilith', 'Operator', 'De-engineered multimedia structure', 72316, 'Hirakata', 'Emalia Scotti', 'escotti6@hexun.com');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Zoomcast', 'Product Engineer', 'Multi-tiered zero administration interface', 41264, 'Starobaltachevo', 'Ryon Fosse', 'rfosse7@infoseek.co.jp');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (2, 3, 'Youbridge', 'Software Consultant', 'Future-proofed interactive model', 52976, 'Mamurras', 'Calypso Lidyard', 'clidyard8@instagram.com');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 1, 'Skippad', 'Web Developer I', 'Team-oriented system-worthy portal', 80575, 'Okpoma', 'Kirbie Iwaszkiewicz', 'kiwaszkiewicz9@nih.gov');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Wordify', 'Registered Nurse', 'Synergized explicit archive', 46997, 'Sembakung', 'Cammi Rosenfelt', 'crosenfelta@psu.edu');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 1, 'Skimia', 'Staff Scientist', 'Grass-roots zero administration secured line', 32751, 'Lüjiabao', 'Mikkel Binestead', 'mbinesteadb@t-online.de');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 3, 'Vipe', 'Statistician IV', 'Virtual 3rd generation project', 46292, 'Ivot', 'Erroll Corston', 'ecorstonc@gmpg.org');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 2, 'Wikido', 'VP Sales', 'Progressive leading edge capability', 36803, 'Gonghe', 'Bridget Rubenchik', 'brubenchikd@nba.com');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 3, 'Zooxo', 'Computer Systems Analyst IV', 'Inverse logistical contingency', 53481, 'Plateliai', 'Eden LAbbet', 'elabbete@illinois.edu');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 4, 'Browsedrive', 'Quality Engineer', 'Innovative foreground local area network', 63769, 'Tessaoua', 'Clarke Kesterton', 'ckestertonf@theguardian.com');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 3, 'Twimbo', 'Human Resources Assistant IV', 'Configurable intangible collaboration', 36339, 'Jiujianfang', 'Simonne Westman', 'swestmang@pbs.org');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (1, 4, 'Miboo', 'Senior Editor', 'Versatile next generation architecture', 48306, 'Clermont-Ferrand', 'Sancho Flowerden', 'sflowerdenh@amazon.co.jp');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (2, 3, 'Jayo', 'Account Representative II', 'Cross-group zero tolerance info-mediaries', 38364, 'Zábřeh', 'Moyna Finney', 'mfinneyi@amazon.co.uk');
insert into jobs (userid, cid, company, job_title, description, salary, location, contact_user, contact_email) values (2, 4, 'Wikizz', 'Quality Control Specialist', 'Object-based high-level open architecture', 85675, 'Disūq', 'Dyna Dennington', 'ddenningtonj@spotify.com');
