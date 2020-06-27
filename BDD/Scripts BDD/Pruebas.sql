--Registro Comercio
SELECT Registro_Usuario(1, 1, 'CODE', current_date, 26466404, 'pjfariakiddo@gmail.com', '04123746609', 'CARACAS', 1, 'C', 'Pedro', 'faria', 'contraseña', 'Comercio CC', 1, date '1998-05-30');
--Registro Persona
SELECT Registro_Usuario(1, 1, 'CODE2', current_date, 26466404, 'pjfariakiddo2@gmail.com', '04123746609', 'CARACAS', 1, 'P', 'Pedro', 'faria', 'contraseña', 'Comercio CC', 1, date '1998-05-30');
--Registro Tarjeta 
SELECT Registro_Tarjeta(1, 2, 2, 2345234, date '2022-05-19', 305, 1);
SELECT Registro_Tarjeta(2, 2, 2, 2345233, date '2022-05-19', 306, 1);
--Solicita Cobro
SELECT Cobro(2, 'pjfariakiddo7@gmail.com', 100);
SELECT Pago_Tarjeta(1, 2, 100, 1);
SELECT * FROM PAGO; --De acá obtienes la referencia del pago;
SELECT Reintegro(1, 'pjfariakiddo@gmail.com', --Debes colocar la referencia acá
				'12020-06-2218:53:42.045715-042');
				SELECT * FROM Reintegros_Activos(1, 1)
SELECT * FROM REINTEGRO;
SELECT Reintegro_Tarjeta(1, 1, 100, --Debes colocar el id del reintegro acá
						 3);
