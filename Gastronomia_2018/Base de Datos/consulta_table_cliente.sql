create table clientes(
nombre text,
apellido text,
numerocelular date,
fecharegistro text,
edad text,
cin text,
ventasrealizadas int
);
insert into clientes(nombre,apellido,numerocelular,fecharegistro,edad,cin,ventasrealizadas) values (
"Oscar","Gomez","0994996935",date("now"),"16","7228498",0)