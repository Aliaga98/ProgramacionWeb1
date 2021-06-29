create database Voluntariado_Santa_cruz;







create table organizacion(
id int primary key identity(1,1),
nombre varchar(200)not null,
usuario varchar(100)not null,
clave varchar (100)not null,
rol varchar (100)not null,
telefono int not null,
descripcion varchar(200),
socios int not null,
departamento varchar(200),
sede varchar (200));




select  from organizacion
select  from voluntario

------------------------------------------------------
create table voluntariado(
id int primary key identity(1,1),
descripcion varchar(200),
fecha date not null,
lugar varchar(20),
cupos int not null,
foto varchar(200),

idOrganizacion int,
foreign key (idOrganizacion) references organizacion(id)
);

create table detalle_voluntarios(
id int primary key identity(1,1),
descripcion varchar(200),
idActi int,
idVolun int,

foreign key (idActi) references voluntariado(id),
foreign key (idVolun) references voluntario(id)
);

create table voluntario(
id int primary key identity(1,1),
ci int not null,
nombre varchar(200)not null,
apellido varchar(200)not null,
usuario varchar(100)not null,
clave varchar (100)not null,
rol varchar (100)not null,
telefono int not null,
departamento varchar(200)not null,
direccion varchar(200),
telefonoEmergencia int not null);


------------------------------------------





-------------------------------------------------

create table donadores(
id int primary key identity(1,1),
nombre varchar(200)not null,
telefono int,
ciudad varchar(200),
);

create table detalle_donacion(
id int primary key identity(1,1),
descripcion varchar(200),
fecha date,
idDonador int,
idRecoleccion int,

foreign key (idDonador)references donadores(id),
foreign key (idRecoleccion)references recolecion(id)
);

create table recolecion(
id int primary key identity(1,1),
descripcion varchar(200),
fechaInicio date not null,
fechaFin date not null,
lugar varchar(20),
necesidaes varchar(200),
beneficiarios varchar(200),

idOrga int ,
foreign key (idOrga) references organizacion(id)
);


