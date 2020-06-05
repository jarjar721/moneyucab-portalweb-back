--Operaciones de acción dentro de la plataforma
----Registro de usuario[x]
----Registro de usuario Persona[x]
----Registro de usuario Comercio[x]
----Registro Usuario_OpcionMenu[x]
----Registro Cuenta[x]
----Registro Tarjeta[x]
----Extraer Datos fijos[X]
----Extraer Datos dinámicos[x]
----Establecer Parámetro[x]
----ExtraccionDatos[x]
-----DatosUsuario[x]
------DatosComercio[x]
------DatosPersona[x]
------DatosTarjetas[x]
-----Tarjeta[x]
-----Cuenta[x]
-----HistorialOp[x]:
------OperacionCuenta[x]
------OperacionesMonedero[x]
------OperacionTarjeta[x]
----ExigirCobro[]
----ExcigirReintegro[]
----OperaciónTarjeta

----------------PROCEDIMIENTOS Y FUNCIONES----------------
--Parametros: tipoUsuario, tipoIdentificacion, usuario, fecha_registro, nro_identificacion, email, telefono, direccion, estatus
--nombre/nombre_Representante
--apellido/apellido_representante
--contrasena
--'C': comercio
---razon_social default null
--'P': persona
---estadoCivil
---fecha_nacimiento

--Registros de usuario sobre items fijos para uso del usuario.
--//////Tarjeta, Cuenta, Usuario, Persona, Comercio, Parametro de usuario
CREATE OR REPLACE FUNCTION Registro_Comercio(VARCHAR, VARCHAR, VARCHAR, INT)
										RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
entity_user_id text;
opcionMenuCurs CURSOR FOR SELECT A.* FROM OpcionMenu A JOIN Aplicacion B ON A.idAplicacion = B.idAplicacion WHERE (B.nombre = 'PostVirtual'
							OR B.nombre = 'PortalWeb') AND A.idOpcionMenu NOT IN (SELECT idOpcionMenu FROM Usuario_OpcionMenu WHERE idUsuario = $4);
BEGIN
	BEGIN
		INSERT INTO Comercio (nombre_representante, apellido_representante, razon_social, idUsuario)
				VALUES ($1,$2,$3,$4);
		FOR opcion IN opcionMenuCurs LOOP
			INSERT INTO Usuario_OpcionMenu (idUsuario, idOpcionMenu, estatus) VALUES ($4, opcion.idOpcionMenu, 1);
		END LOOP;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;

CREATE OR REPLACE FUNCTION Registro_Persona(VARCHAR, VARCHAR, int, DATE, int)
										RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
entity_user_id text;
opcionMenuCurs CURSOR FOR SELECT A.* FROM OpcionMenu A JOIN Aplicacion B ON A.idAplicacion = B.idAplicacion WHERE (B.nombre = 'Monedero'
							OR B.nombre = 'PortalWeb') AND A.idOpcionMenu NOT IN (SELECT idOpcionMenu FROM Usuario_OpcionMenu WHERE idUsuario = $4);
BEGIN
	BEGIN
		INSERT INTO Persona (nombre, apellido,idEstadoCivil, fecha_nacimiento,idUsuario)
				VALUES ($1, $2, $3, $4, $5);
		FOR opcion IN opcionMenuCurs LOOP
			INSERT INTO Usuario_OpcionMenu (idUsuario, idOpcionMenu, estatus) VALUES ($4, opcion.idOpcionMenu, 1);
		END LOOP;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;

CREATE OR REPLACE FUNCTION Registro_Usuario(INT, INT, VARCHAR, DATE, INT, VARCHAR, VARCHAR, VARCHAR, INT, CHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR DEFAULT NULL,
												INT DEFAULT NULL, DATE DEFAULT NULL)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
response boolean;
entity_user_id text;
tipo_cuenta int;
banco int;
BEGIN
	BEGIN
		SELECT "Id" FROM AspNetUsers into entity_user_id WHERE UserName = $3 or Email = $6;
		INSERT INTO Usuario ("idEntity", idtipousuario,idtipoidentificacion,usuario,fecha_registro,nro_identificacion,email,telefono,direccion,estatus)
		VALUES (entity_user_id, $1, $2, $3, $4, $5, $6, $7, $8, $9);
		SELECT IdUsuario FROM Usuario into usuario WHERE usuario = $3;
		INSERT INTO CONTRASENA (idUsuario, contrasena, intentos_fallidos, estatus)
		VALUES
					(usuario, $13, 0, 1);
		IF ($10 = 'C') THEN
			SELECT Registro_Comercio($11,$12,$14,usuario) INTO RESPONSE;
			IF NOT (response) THEN
				RAISE EXCEPTION 'Error al registrar comercio';
			END IF;
		ELSE
			SELECT Registro_Persona($11,$12,$15,$16,usuario) INTO RESPONSE;
			IF NOT (response) THEN
				RAISE EXCEPTION 'Error al registrar persona';
			END IF;
		END IF;
		SELECT idBanco FROM Banco into banco WHERE nombre = 'WEB';
		SELECT idTipoBanco FROM TipoCuenta into tipo_cuenta WHERE descripcion = 'Monedero';
		INSERT INTO Cuenta (idUsuario, idTipoCuenta, idBanco, numero)
		VALUES
					(usuario, tipo_cuenta, banco, $3 || 'MONEDERO');
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
CREATE OR REPLACE FUNCTION Registro_Cuenta(INT, INT, INT, VARCHAR)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		INSERT INTO Cuenta (idUsuario, idTipoCuenta, idBanco, numero) VALUES ($1, $2, $3, $4);
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
CREATE OR REPLACE FUNCTION Registro_Tarjeta(INT, INT, INT, INT, DATE, INT, INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		INSERT INTO Tarjeta (idUsuario, idTipoTarjeta, idBanco, numero, fecha_vencimiento, cvc, estatus) VALUES ($1, $2, $3, $4, $5, $6, $7);
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
CREATE OR REPLACE FUNCTION Establecer_Parametro(INT, INT, VARCHAR, INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		INSERT INTO Usuario_Parametro(idUsuario, idParametros, validacion, estatus) VALUES ($1, $2, $3, $4);
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;

--EXTRACCION DE DATOS FIJOS--
--Son los datos para llenar formularios por parte del usuario
CREATE OR REPLACE FUNCTION Estados_Civiles()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM EstadoCivil;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Tarjeta()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoTarjeta;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Bancos()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Banco;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Cuentas()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoCuenta;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Parametros()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoParametro;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Frecuencias()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Frecuencia;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Parametros()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Parametro JOIN Frecuencia B ON B.IdFrecuencia = Parametro.idFrecuencia
											JOIN TipoParametro C ON C.IdTipoParametro = Parametro.idTipoParametro;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Operaciones()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoOperacion;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Identificaciones()
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoIdentificacion;
END
$BODY$
LANGUAGE plpgsql;
--////////////////////////////////////////////////////////////////////////////////////////////////

--//Extracción de datos sobre tablas dinámicas.
--//Todos los datos se exraen a través del parámetro de id de Usuario.
--//////////////////////////////////////////////////////////////////////////////////////////////////
CREATE OR REPLACE FUNCTION Tarjetas(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Tarjeta WHERE idUsuario = $1;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Historial_Operaciones_Tarjetas(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM OperacionTarjeta WHERE idTarjeta = $1 ORDER BY Fecha DESC;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Cuenta(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Cuenta JOIN Banco ON Banco.idBanco = Cuenta.idBanco WHERE idUsuario = $1;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Historial_Operaciones_Cuenta(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM OperacionCuenta WHERE idCuenta = $1 ORDER BY fecha DESC;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Historial_Operaciones_Monedero(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM OperacionesMonedero JOIN TipoOperacion ON TipoOperacion.idTipoOperacion = OperacionesMonedero.idTipoOperacion
													JOIN OperacionTarjeta ON OperacionesMonedero.referencia = OperacionTarjeta.referencia
													JOIN OperacionCuenta ON OperacionesMonedero.referencia = OperacionCuenta.referencia
													WHERE OperacionesMonedero.idUsuario = $1 ORDER BY fecha DESC;
END
$BODY$
LANGUAGE plpgsql;
--REINTEGROS
--Segundo parámetro: 1 - Solicitante, 2 - Receptor
CREATE OR REPLACE FUNCTION Reintegros_Activos(INT, INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT * FROM Reintegro WHERE Reintegro.idUsuario_Solicitante = $1 AND Reintegro.estatus IN ('En Proceso', 'Solicitado');
	END IF;
	RETURN QUERY SELECT * FROM Reintegro WHERE Reintegro.idUsuario_Receptor = $1 AND Reintegro.estatus IN ('En Proceso', 'Solicitado');
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Reintegros_Cancelados(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT * FROM Reintegro WHERE Reintegro.idUsuario_Solicitante = $1 AND Reintegro.estatus IN ('Cancelado', 'Caducado');
	END IF;
	RETURN QUERY SELECT * FROM Reintegro WHERE Reintegro.idUsuario_Receptor = $1 AND Reintegro.estatus IN ('Cancelado', 'Caducado');
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Reintegros_Exitosos(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT * FROM Reintegro WHERE Reintegro.idUsuario_Solicitante = $1 AND Reintegro.estatus IN ('Consolidado');
	END IF;
	RETURN QUERY SELECT * FROM Reintegro WHERE Reintegro.idUsuario_Receptor = $1 AND Reintegro.estatus IN ('Consolidado');
END
$BODY$
LANGUAGE plpgsql;
--Pago
--Segundo parámetro: 1 - Solicitante, 2 - Receptor
CREATE OR REPLACE FUNCTION Cobros_Activos(INT, INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT * FROM Pago WHERE Pago.idUsuario_Solicitante = $1 AND Pago.estatus IN ('En Proceso', 'Solicitado');
	END IF;
	RETURN QUERY SELECT * FROM Pago WHERE Pago.idUsuario_Receptor = $1 AND Pago.estatus IN ('En Proceso', 'Solicitado');
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Cobros_Cancelados(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT * FROM Pago WHERE Pago.idUsuario_Solicitante = $1 AND Pago.estatus IN ('Cancelado', 'Caducado');
	END IF;
	RETURN QUERY SELECT * FROM Pago WHERE Pago.idUsuario_Receptor = $1 AND Pago.estatus IN ('Cancelado', 'Caducado');
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Cobros_Exitosos(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT * FROM Pago WHERE Pago.idUsuario_Solicitante = $1 AND Pago.estatus IN ('Consolidado');
	END IF;
	RETURN QUERY SELECT * FROM Pago WHERE Pago.idUsuario_Receptor = $1 AND Pago.estatus IN ('Consolidado');
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Parametros_Usuario(INT)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Usuario_Parametro A JOIN Parametro B ON B.idParametro = A.idParametro
													JOIN TipoParametro C ON C.idTipoParametro = B.idTipoParametro
													JOIN Frecuencia D ON D.idFrecuencia = C.idFrecuencia
													WHERE A.idUsuario = $1;
END
$BODY$
LANGUAGE plpgsql;

--Excepción de extracción de datos del usuario, se realiza por email.
CREATE OR REPLACE FUNCTION Información_persona(VARCHAR)
			RETURNS SETOF integer AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Usuario JOIN Persona ON Persona.idUsuario = Usuario.idUsuario
										JOIN Comercio ON Comercio.idUsuario = Usuario.idUsuario 
										JOIN TipoIdentificacion ON TipoIdentificacion.idTipoIdentificacion = Usuario.idTipoIdentificacion 
										WHERE email = $1;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Saldo_Monedero(INT)
			RETURNS DECIMAL
LANGUAGE plpgsql		
AS $$
DECLARE
	Recargas decimal;
	Transferencias_Retiros decimal;
BEGIN
	SELECT SUM(A.monto) FROM OperacionesMonedero A INTO Recargas JOIN TipoOperacion B ON B.idTipoOperacion = A.idTipoOperacion 
																		AND (B.descripcion = 'Recarga')
																WHERE A.idUsuario = $1;
	SELECT SUM(A.monto) FROM OperacionesMonedero A INTO Transferencias_Retiros JOIN TipoOperacion B ON B.idTipoOperacion = A.idTipoOperacion 
																		AND (B.descripcion = 'Transferencia' OR B.descripcion = 'Retiro')
																WHERE A.idUsuario = $1;
	RETURN Recargas - Transferencias_Retiros;
END;
$$;

--/////////PROCEDIMIENTOS DE LÓGICA//////////////////--
--Cobro de Comercio a Persona
--Parámetros: id del usuario que lo solicita, email del usuario que debe realizar el pago y el monto para realizar el procedimiento.
CREATE OR REPLACE FUNCTION Cobro(INT, VARCHAR, DECIMAL)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_Solicitante int;
BEGIN
	BEGIN
		SELECT idUsuario FROM Usuario into idUsuario_Solicitante WHERE Usuario.email = $2;
		INSERT INTO Pago (idUsuario_Solicitante, idUsuario_Receptor, fecha_solicitud, monto, estatus, referencia)
		VALUES (idUsuario_Solicitante, $1, current_date, $3, 'Solicitado', NULL);
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;

--Solicitud de reintegro a comercio
--Parámetros: id del usuario que solicita, email del usuario al que se le pide reintegro, referencia del proceso vinculado al pago.
CREATE OR REPLACE FUNCTION Reintegro(INT, VARCHAR, VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_Receptor int;
BEGIN
	BEGIN
		SELECT idUsuario FROM Usuario into idUsuario_Receptor WHERE Usuario.email = $2;
		INSERT INTO Reintegro (idUsuario_Solicitante, idUsuario_Receptor, fecha_solicitud, estatus, referencia, referencia_reintegro)
		VALUES ($1, idUsuario_Receptor, current_date, 'Solicitado', $3, NULL);
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;

-----------PAGOS---------------
--Estos pagos se realizan posterior a seleccionar un cobro generado por una empresa
--Pago con tarjeta
CREATE OR REPLACE FUNCTION Pago_Tarjeta(INT, INT, DECIMAL, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		UPDATE Pago SET estatus = 'En proceso' WHERE idPago = $4;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionTarjeta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, crypt($1 || current_date || current_time || $2, gen_salt('md5')));
		UPDATE Pago SET referencia = crypt($1 || current_date || current_time || $2, gen_salt('md5')), estatus = 'Consolidado' WHERE idPago = $4;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
--Pago con cuenta
CREATE OR REPLACE FUNCTION Pago_Cuenta(INT, INT, DECIMAL, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		UPDATE Pago SET estatus = 'En proceso' WHERE idPago = $4;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, crypt($1 || current_date || current_time || $2, gen_salt('md5')));
		UPDATE Pago SET referencia = crypt($1 || current_date || current_time || $2, gen_salt('md5')), estatus = 'Consolidado' WHERE idPago = $4;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
--Pago con Monedero
--Parámetros: IdUsuarioReceptor, IdUsuarioPago (el que realiza el pago), monto, idPago
CREATE OR REPLACE FUNCTION Pago_Monedero(INT, INT, DECIMAL, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idCuentaMonedero int;
BEGIN
	BEGIN
		UPDATE Pago SET estatus = 'En proceso' WHERE idPago = $4;
		SELECT Cuenta.idCuenta FROM Cuenta INTO idCuentaMonedero
							JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Monedero'
											WHERE Cuenta.idUsuario = $2;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, idCuentaMonedero, current_date, current_time, $3, crypt($1 || current_date || current_time || $2, gen_salt('md5')));
		UPDATE Pago SET referencia = crypt($1 || current_date || current_time || $2, gen_salt('md5')), estatus = 'Consolidado' WHERE idPago = $4;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;

----------------------REINTEGROS--------------------------
CREATE OR REPLACE FUNCTION Reintegro_Tarjeta(INT, INT, DECIMAL, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		UPDATE Reintegro SET estatus = 'En proceso' WHERE idReintegro = $4;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionTarjeta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, crypt($1 || current_date || current_time || $2, gen_salt('md5')));
		UPDATE Reintegro SET referencia_reintegro = crypt($1 || current_date || current_time || $2, gen_salt('md5')), estatus = 'Consolidado' WHERE idReintegro = $4;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
--Pago con cuenta
CREATE OR REPLACE FUNCTION Reintegro_Cuenta(INT, INT, DECIMAL, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	BEGIN
		UPDATE Reintegro SET estatus = 'En proceso' WHERE idReintegro = $4;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, crypt($1 || current_date || current_time || $2, gen_salt('md5')));
		UPDATE Reintegro SET referencia_reintegro = crypt($1 || current_date || current_time || $2, gen_salt('md5')), estatus = 'Consolidado' WHERE idReintegro = $4;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;
--Pago con Monedero
--Parámetros: IdUsuarioReceptor, IdUsuarioPago (el que realiza el pago), monto, idPago
CREATE OR REPLACE FUNCTION Reintegro_Monedero(INT, INT, DECIMAL, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idCuentaMonedero int;
BEGIN
	BEGIN
		UPDATE Reintegro SET estatus = 'En proceso' WHERE idReintegro = $4;
		SELECT Cuenta.idCuenta FROM Cuenta INTO idCuentaMonedero
							JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Monedero'
											WHERE Cuenta.idUsuario = $2;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, idCuentaMonedero, current_date, current_time, $3, crypt($1 || current_date || current_time || $2, gen_salt('md5')));
		UPDATE Reintegro SET referencia_reintegro = crypt($1 || current_date || current_time || $2, gen_salt('md5')), estatus = 'Consolidado' WHERE idReintegro = $4;
		RETURN TRUE;
	EXCEPTION WHEN OTHERS THEN 
		RETURN FALSE;
	END;
END;
$$;



