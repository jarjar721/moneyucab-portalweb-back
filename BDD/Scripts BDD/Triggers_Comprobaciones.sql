--Procedimientos de acciones principales
--A continuación se realizará la jerarquía de procedimientos o funciones.
--.................--
---.Registro Usuario
-----.Trigger validacion de registro
-----.Registro Comercio
-----.Registro Persona
-----.Registro de contacto dentro del comercio

--Validación de registro de comercio
DROP TRIGGER IF EXISTS validar_comercioT ON Comercio CASCADE;
CREATE OR REPLACE FUNCTION validar_comercio()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF NOT EXISTS (SELECT * FROM Persona WHERE idUsuario = new.idUsuario) THEN
		RAISE EXCEPTION 'El usuario no está registrado como persona para poder realizar el registro';
	END IF;
	IF EXISTS (SELECT * FROM Comercio WHERE razon_social = new.razon_social) THEN
		RAISE EXCEPTION 'Ya hay un comercio con la misma razón social';
	END IF;
	IF EXISTS (SELECT * FROM Comercio WHERE idUsuario = new.idUsuario) THEN
		RAISE EXCEPTION 'Ya hay un registro de comercio para el usuario';
	END IF;
END;
$BODY$;

CREATE TRIGGER validar_comercioT
BEFORE INSERT
   ON Comercio
       EXECUTE PROCEDURE validar_comercio();
	   
--Validación de registro de persona
DROP TRIGGER IF EXISTS validar_personaT ON Persona CASCADE;
CREATE OR REPLACE FUNCTION validar_persona()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM Persona WHERE idUsuario = new.idUsuario) THEN
		RAISE EXCEPTION 'Ya hay un registro de persona asignado al usuario';
	END IF;
END;
$BODY$;

CREATE TRIGGER validar_personaT
BEFORE INSERT
   ON Persona
       EXECUTE PROCEDURE validar_persona();
	   
--Validación de registro de Tarjeta
DROP TRIGGER IF EXISTS validar_tarjetaT ON tarjeta CASCADE;
CREATE OR REPLACE FUNCTION validar_tarjeta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM tarjeta WHERE numero = new.numero and idBanco = new.idBanco and idTipoTarjeta = new.idTipoTarjeta and idUsuario = new.idUsuario) THEN
		RAISE EXCEPTION 'No puede registrar una tarjeta duplicada';
	END IF;
	IF current_date <= new.fecha_vencimiento THEN
		RAISE EXCEPTION 'No puede registrar una tarjeta vencida';
	END IF;
	IF EXISTS (SELECT * FROM Banco WHERE new.idBanco = Banco.idBanco and Banco.estatus > 1) THEN
		RAISE EXCEPTION 'No puede registrar una tarjeta duplicada';
	END IF;
END;
$BODY$;

CREATE TRIGGER validar_tarjetaT
BEFORE INSERT
   ON tarjeta
       EXECUTE PROCEDURE validar_tarjeta();
	   
--Validación de registro de Cuenta
DROP TRIGGER IF EXISTS validar_cuentaT ON cuenta CASCADE;
CREATE OR REPLACE FUNCTION validar_cuenta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM cuenta WHERE numero = new.numero and idBanco = new.idBanco and idTipoCuenta = new.idTipoCuenta and idUsuario = new.idUsuario) THEN
		RAISE EXCEPTION 'No puede registrar una cuenta duplicada';
	END IF;
	IF EXISTS (SELECT * FROM Banco WHERE new.idBanco = Banco.idBanco and Banco.estatus > 1) THEN
		RAISE EXCEPTION 'No puede registrar una tarjeta duplicada';
	END IF;
END;
$BODY$;

CREATE TRIGGER validar_cuentaT
BEFORE INSERT
   ON cuenta
       EXECUTE PROCEDURE validar_cuenta();

--//////////////////////////////////////////////////////////////////////////////
--Validación de transaccion Tarjeta
DROP TRIGGER IF EXISTS validar_transaccionTarjetaT ON OperacionTarjeta CASCADE;
CREATE OR REPLACE FUNCTION validar_transaccionTarjeta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	fecha_límite DATE;
	cantidad int;
	monto_acum DECIMAL;
	parametros CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = Usuario_Parametro.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta AND A.idUsuario = Tarjeta.idUsuario;
	parametros_destino CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = Usuario_Parametro.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						WHERE A.idUsuario = new.idUsuarioReceptor;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE idUsuario = new.idUsuarioReceptor) THEN
		RAISE EXCEPTION 'No hay un registro de usuario destino';
	END IF;
	IF NOT EXISTS (SELECT * FROM Tarjeta WHERE idTarjeta = new.idTarjeta) THEN
		RAISE EXCEPTION 'No hay un registro de tarjeta origen';
	END IF;
	IF NOT EXISTS (SELECT * FROM Tarjeta WHERE idTarjeta = new.idTarjeta and (estatus > 1 OR fecha_vencimiento >= current_date)) THEN
		IF EXISTS (SELECT * FROM Tarjeta WHERE idTarjeta = new.idTarjeta and (fecha_vencimiento >= current_date)) THEN
			UPDATE Tarjeta SET estatus = 4 WHERE idTarjeta = new.idTarjeta;
		END IF;
		RAISE EXCEPTION 'No hay estatus válido para la realización de operación o tarjeta vencida.';
	END IF;
	IF EXISTS (SELECT * FROM Banco JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta AND Banco.idBanco = Tarjeta.idBanco
				  								WHERE Banco.estatus > 1) THEN
		UPDATE Tarjeta SET estatus = 4 WHERE idTarjeta = new.idTarjeta;
		RAISE EXCEPTION 'Banco en estatus inválido para permitir transacciones';
	END IF;
	IF EXISTS (SELECT * FROM Usuario JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta WHERE Usuario.estatus > 1)THEN
		RAISE EXCEPTION 'El usuario tiene un estatus inválido para realizar dichos procedimientos.';
	END IF;
	FOR parametro IN parametros LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Monto Transferencia') THEN
				IF new.monto > parametro.validacion THEN
					RAISE EXCEPTION 'Error de parámetro, monto de transferencia';
				END IF;
				
			END IF;
			IF (parametro.tipo_parametro = 'Cantidad Operaciones') THEN
				SELECT COUNT(OperacionTarjeta.*) FROM OperacionTarjeta into cantidad 
					JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta
					WHERE OperacionTarjeta.fecha >= fecha_límite;
				IF cantidad >= parametro.validacion THEN
					RAISE EXCEPTION 'Exceso de operaciones';
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado') THEN
				SELECT SUM(OperacionTarjeta.monto) FROM OperacionTarjeta into monto_acum 
					JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta
					WHERE OperacionTarjeta.fecha >= fecha_límite;
				IF monto_acum >= parametro.validacion THEN
					RAISE EXCEPTION 'Exceso de monto acumulado';
				END IF;
			END IF;
		END IF;
	END LOOP;
	FOR parametro IN parametros_destino LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Recepción Monto') THEN
				IF new.monto > parametro.validacion THEN
					RAISE EXCEPTION 'Error de parámetro, recepción de monto';
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado Recepcion') THEN
				SELECT SUM(OperacionTarjeta.monto) FROM OperacionTarjeta into monto_acum
					WHERE OperacionTarjeta.fecha >= fecha_límite AND OperacionTarjeta.idUsuarioReceptor = new.idUsuarioReceptor;
				IF monto_acum >= parametro.validacion THEN
					RAISE EXCEPTION 'Exceso de monto acumulado recibido';
				END IF;
			END IF;
		END IF;
	END LOOP;
END;
$BODY$;

CREATE TRIGGER validar_transaccionTarjetaT
BEFORE INSERT
   ON OperacionTarjeta
       EXECUTE PROCEDURE validar_transaccionTarjeta();
	   
--//////////////////////////////////////////////////////////////////////////////
--Validación de transaccion Cuenta
DROP TRIGGER IF EXISTS validar_transaccionCuentaT ON OperacionCuenta CASCADE;
CREATE OR REPLACE FUNCTION validar_transaccionCuenta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	fecha_límite DATE;
	cantidad int;
	monto_acum DECIMAL;
	id_usuario int;
	tipo_cuenta varchar;
	parametros CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = Usuario_Parametro.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta AND A.idUsuario = Cuenta.idUsuario;
	parametros_destino CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = Usuario_Parametro.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						WHERE A.idUsuario = new.idUsuarioReceptor;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE idUsuario = new.idUsuarioReceptor) THEN
		RAISE EXCEPTION 'No hay un registro de usuario destino';
	END IF;
	IF NOT EXISTS (SELECT * FROM Cuenta WHERE idCuenta = new.idCuenta) THEN
		RAISE EXCEPTION 'No hay un registro de cuenta origen';
	END IF;
	IF NOT EXISTS (SELECT * FROM Cuenta WHERE idCuenta = new.idCuenta and (estatus > 1 OR fecha_vencimiento >= current_date)) THEN
		IF EXISTS (SELECT * FROM Cuenta WHERE idCuenta = new.idCuenta and (fecha_vencimiento >= current_date)) THEN
			UPDATE Cuenta SET estatus = 4 WHERE idCuenta = new.idCuenta;
		END IF;
		RAISE EXCEPTION 'No hay estatus válido para la realización de operación o cuenta vencida.';
	END IF;
	IF EXISTS (SELECT * FROM Banco JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta AND Banco.idBanco = Cuenta.idBanco
				  								WHERE Banco.estatus > 1) THEN
		UPDATE Cuenta SET estatus = 4 WHERE idCuenta = new.idCuenta;
		RAISE EXCEPTION 'Banco en estatus inválido para permitir transacciones';
	END IF;
	IF EXISTS (SELECT * FROM Usuario JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta WHERE Usuario.estatus > 1)THEN
		RAISE EXCEPTION 'El usuario tiene un estatus inválido para realizar dichos procedimientos.';
	END IF;
	SELECT idUsuario FROM Cuenta WHERE Cuenta.idCuenta = new.idCuenta;
	SELECT Saldo_Monedero(idUsuario) into monto_acum;
	SELECT descripcion FROM TipoCuenta into tipo_cuenta
		JOIN Cuenta ON TipoCuenta.idTipoCuenta= Cuenta.idTipoCuenta
		WHERE Cuenta.idCuenta = new.idCuenta AND Descripcion = 'Monedero';
	IF (new.monto > monto_acum AND tipo_cuenta = 'Monedero') THEN
		RAISE EXCEPTION 'Monto excede cantidad disponible, no se puede realizar el pago.';
	END IF;
	FOR parametro IN parametros LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Monto Transferencia') THEN
				IF new.monto > parametro.validacion THEN
					RAISE EXCEPTION 'Error de parámetro, monto de transferencia';
				END IF;
				
			END IF;
			IF (parametro.tipo_parametro = 'Cantidad Operaciones') THEN
				SELECT COUNT(OperacionCuenta.*) FROM OperacionCuenta into cantidad 
					JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta
					WHERE OperacionCuenta.fecha >= fecha_límite;
				IF cantidad >= parametro.validacion THEN
					RAISE EXCEPTION 'Exceso de operaciones';
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado') THEN
				SELECT SUM(OperacionCuenta.monto) FROM OperacionCuenta into monto_acum 
					JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta
					WHERE OperacionCuenta.fecha >= fecha_límite;
				IF monto_acum >= parametro.validacion THEN
					RAISE EXCEPTION 'Exceso de monto acumulado';
				END IF;
			END IF;
		END IF;
	END LOOP;
	FOR parametro IN parametros_destino LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Recepción Monto') THEN
				IF new.monto > parametro.validacion THEN
					RAISE EXCEPTION 'Error de parámetro, recepción de monto';
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado Recepcion') THEN
				SELECT SUM(OperacionCuenta.monto) FROM OperacionCuenta into monto_acum
					WHERE OperacionCuenta.fecha >= fecha_límite AND OperacionCuenta.idUsuarioReceptor = new.idUsuarioReceptor;
				IF monto_acum >= parametro.validacion THEN
					RAISE EXCEPTION 'Exceso de monto acumulado recibido';
				END IF;
			END IF;
		END IF;
	END LOOP;
END;
$BODY$;

CREATE TRIGGER validar_transaccionCuentaT
BEFORE INSERT
   ON OperacionCuenta
       EXECUTE PROCEDURE validar_transaccionCuenta();
	   
--//////////////////////////////////////////////////////////////////////////////
--Validación de Reintegro
DROP TRIGGER IF EXISTS validar_ReintegroT ON Reintegro CASCADE;
CREATE OR REPLACE FUNCTION validar_Reintegro()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	
BEGIN
	IF NOT EXISTS (SELECT * FROM OperacionCuenta WHERE referencia = new.referencia) AND  
		NOT EXISTS (SELECT * FROM OperacionTarjeta WHERE referencia = new.referencia) AND new.estatus = 'Consolidado' THEN
		RAISE EXCEPTION 'No hay referencia indicada para una operación';
	END IF;
	IF new.estatus = 'Solicitado' and new.referencia is not null THEN
		RAISE EXCEPTION 'Reintegro inválido';
	END IF;
END;
$BODY$;

CREATE TRIGGER validar_ReintegroT
BEFORE INSERT
   ON Reintegro
       EXECUTE PROCEDURE validar_Reintegro();
	   
--//////////////////////////////////////////////////////////////////////////////
--Validación de Pago
DROP TRIGGER IF EXISTS validar_PagoT ON Pago CASCADE;
CREATE OR REPLACE FUNCTION validar_Pago()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	
BEGIN
	IF NOT EXISTS (SELECT * FROM OperacionCuenta WHERE referencia = new.referencia) AND  
		NOT EXISTS (SELECT * FROM OperacionTarjeta WHERE referencia = new.referencia) AND new.estatus = 'Consolidado' THEN
		RAISE EXCEPTION 'No hay referencia indicada para una operación';
	END IF;
	IF new.estatus = 'Solicitado' and new.referencia is not null THEN
		RAISE EXCEPTION 'Pago inválido';
	END IF;
END;
$BODY$;

CREATE TRIGGER validar_PagoT
BEFORE INSERT
   ON Pago
       EXECUTE PROCEDURE validar_Pago();