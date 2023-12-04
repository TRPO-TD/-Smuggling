create table Users(
ulogin nvarchar(15),
upassword nvarchar(31)
)

create table Video_media(
vm_id int,
c_id int,
vmo_id int,
vmt_id int,
vm_dailyRentPrice float,
vm_durability tinyint,
vm_price float

-- ограничения и ключи потом
)

create table Video_media_type(
vmt_id int,
vmt_name nvarchar(10),
vmt_description nvarchar(100)


)

create table Cinema(
c_id int,
c_name nvarchar(130),
c_description nvarchar(500)

)

create table Genre(
g_id int,
g_name nvarchar(15),
g_description nvarchar(500)

)

create table Cinema_Genre(
c_id int,
g_id int

)

create table Deal(
d_id int,
e_id int,
cl_id int,
d_tDate date,
d_tCompletionDate date,
d_actualCompletionDate date

)

create table Deal_Video_media(
vm_id int,
d_id int

)

create table Penalty(
pen_id int,
d_id int,
pen_description nvarchar(400),
pen_ammount float

)

create table Client(
cl_id int,
cl_surname varchar(50),
cl_name varchar(50),
cl_patronymic varchar(50),
a_id int,
cl_telNum varchar(16),
cs_id int,

)

create table Status_of_clients(
cs_id int,
cs_name varchar(40)

)

create table Address_(
a_id int,
a_country varchar(50),
a_locality varchar(50),
a_street varchar(50),
a_building varchar(25),

)

create table Employee(
e_id int,
e_surname varchar(50),
e_name varchar(50),
e_patronymic varchar(50),
a_id int,
e_telNum varchar(16),
e_position varchar(50),
e_salary float,

)

create table Provider_(
p_id int,
p_title nvarchar(100),
a_id int,
p_telNum varchar(16),
p_surname varchar(50),
p_name varchar(50),
p_patronymic varchar(50),

)

create table Video_media_order(
vmo_id int,
vmo_tData date,
vmo_tCompletionDate date,
vmo_actualCompletionDate date,
p_id int,
e_id int

)