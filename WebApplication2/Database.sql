Create database DataAddress;
go;
use DataAddress;
create Table Contact(
ContactId int PRIMARY KEY,
Name varchar(20)
);
create Table Phone(
PhoneId int PRIMARY KEY,
Phone varchar(20),
state bit,
ContactId int foreign key References  Contact(ContactId) NOT NULL
);
insert into Contact values (0,'test'),(1,'test'),(2,'test');
insert into Phone values (0,'+654364636345',1,0),(1,'+65436346',1,0),(2,'+653635',1,0),(3,'+654363463',1,0),(4,'+6543635654',1,0),(5,'+65463634',1,0),(6,'+3636534',1,0),(7,'+6354634',1,0),(8,'+3653365',1,0);
insert into Phone values (9,'+654364636345',1,1),(10,'+65436346',1,2);

CREATE PROCEDURE [dbo].[sp_GetData]
AS
select Contact.ContactId,Name,PhoneId,Phone,state from Contact
left join Phone on Phone.ContactId=Contact.ContactId
