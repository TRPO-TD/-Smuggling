create table Users(
login nvarchar(15),
password nvarchar(31)
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
cl_surname var
)