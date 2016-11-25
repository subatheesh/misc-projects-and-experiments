REM Drop table 

drop table O_status;
drop table s_item;
drop table orders;
drop table customers;
drop table suppliers;
drop table item_list;


REM Table Creation


REM Customer details table 

create table customers
(
cid varchar2(10)
constraint cid_pk Primary Key,
cname char(20),
caddr varchar2(40),
cemail varchar2(25)
constraint cemail_check check (cemail like '%@%.%'),
pswd varchar2(20)
);
 

REM Supplier details table

create table suppliers
(
sid varchar2(10)
constraint sid_pk Primary Key,
sname char(20),
office_addr varchar2(40),
semail varchar2(25)
constraint semail_check check (semail like '%@%.%'),
pswd varchar2(20)
);

REM item list table

create table item_list
(
itemid varchar2(10)
constraint itid_pk Primary Key,
item_type char(10)
constraint it_type_check check (item_type IN ('Mobile','Tablet','Laptop','Camera','Other..')),
item_name char(20),
item_price number(*,2),
img_loc blob
);

--insert into item_list values('af','Mobile','fsdf',3432.00,bfilename('GIF_FILES','C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Sunset.jpg'));

REM orders table

create table orders 
(
orderid varchar2(10)
constraint oid_pk Primary Key,
itemid varchar2(10)
constraint itid_fk references item_list(itemid),
cid varchar2(10)
constraint cid_fk references customers(cid),
qty number(4) 
constraint Quantity_NULL NOT NULL
);


--REM order status table

--create table O_status
--(
--orderid varchar2(10)
--constraint oid_fk references orders(orderid),
--constraint status_check check (status IN ('delivered','pending'))
--);


REM supplied item table

create table s_item
(
sid varchar2(10)
constraint sid_fk references suppliers(sid),
itemid varchar2(10)
constraint sitid_fk references item_list(itemid),
constraint sitem_ck Primary Key(sid,itemid)
);

