--Procedimientos de acciones principales
--A continuación se realizará la jerarquía de procedimientos o funciones.
--.................--
---.Registro Usuario
-----.Trigger validacion de registro
-----.Registro Persona
-----.Registro Comercio
-----.Registro de contacto dentro del comercio


/* OPCION PARA ELIMINAR SCRIPT

DROP FUNCTION comprobacion_log_in CASCADE;
DROP FUNCTION comprobacion_rol CASCADE;
DROP FUNCTION comprobacion_registro CASCADE;
DROP FUNCTION comprobacion_contacto CASCADE;
DROP FUNCTION comprobacion_operacion CASCADE;

*/

--Comprobación de logeo para el usuario.
CREATE OR REPLACE FUNCTION comprobacion_log_in(username varchar(200), clave varchar(500))
RETURNS INTEGER LANGUAGE plpgsql    
AS $$
BEGIN
    IF NOT EXISTS(SELECT * FROM Usuario US 
			WHERE (US.US_CORREO = username OR US.US_USERNAME = username)
			AND US.US_CLAVE = clave AND US.US_COUNT <> 3) THEN
	 	RETURN 0;
	ELSE
		UPDATE usuario SET US.US_COUNT = US.US_COUNT + 1 WHERE US.US_CORREO = username OR US.US_USERNAME = username;
		RETURN -1;
	END IF;
END;
$$;

--Comprobación de registro
CREATE OR REPLACE FUNCTION comprobacion_registro()
RETURNS TRIGGER LANGUAGE plpgsql    
AS $$
DECLARE
	
BEGIN
    IF EXISTS(SELECT * FROM Usuario US 
			WHERE US.US_CORREO = NEW.US_CORREO
			AND US.US_USERNAME = NEW.US_USERNAME) THEN
	 	RAISE EXCEPTION 'Usuario con nombre de usuario o correo existente';
		ROLLBACK;
	END IF;
END;
$$;

CREATE TRIGGER registro_usuario
    BEFORE INSERT ON Usuario
    FOR EACH STATEMENT
    EXECUTE PROCEDURE comprobacion_registro();
	
--Comprobación de contacto
CREATE OR REPLACE FUNCTION comprobacion_contacto()
RETURNS TRIGGER LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
    IF EXISTS(SELECT * FROM Persona_Contacto PC 
			WHERE PC.PE_FK = NEW.PE_FK
			AND PC.CO_FK = NEW.CO_FK) THEN
	 	RAISE EXCEPTION 'Contacto ya realizado';
		ROLLBACK;
	END IF;
END;
$$;

CREATE TRIGGER comprobación_contacto
    BEFORE INSERT ON Persona_Contacto
    FOR EACH STATEMENT
    EXECUTE PROCEDURE comprobacion_contacto();
	
--Comprobación de contacto
CREATE OR REPLACE FUNCTION comprobacion_rol()
RETURNS TRIGGER LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
    IF EXISTS(SELECT * FROM Rol RO 
			WHERE ro.us_FK = NEW.us_FK
			AND ro.pe_FK = NEW.pe_FK) THEN
	 	RAISE EXCEPTION 'Contacto ya realizado';
		ROLLBACK;
	END IF;
END;
$$;

CREATE TRIGGER comprobación_rol
    BEFORE INSERT ON rol
    FOR EACH STATEMENT
    EXECUTE PROCEDURE comprobacion_rol();
	
--Comprobación de Operación
CREATE OR REPLACE FUNCTION comprobacion_operacion()
RETURNS TRIGGER LANGUAGE plpgsql    
AS $$
DECLARE
	monedero_destino monedero%rowtype;
	monedero_origen monedero%rowtype;
BEGIN
	SELECT * FROM MONEDERO into monedero_destino WHERE MO_PK = NEW.OP_MONEDERO_DESTINO_PK;
	SELECT * FROM MONEDERO into monedero_origen WHERE MO_PK = NEW.OP_MONEDERO_ORIGEN_PK;
    IF (NEW.ST_FK = 'TR') THEN
		IF(monedero_destino.)
	END IF;
	IF (NEW.ST_FK = 'RC') THEN
	END IF;
	IF (NEW.ST_FK = 'RE') THEN
	END IF;
END;
$$;

CREATE TRIGGER comprobación_operación
    BEFORE INSERT ON operacion
    FOR EACH STATEMENT
    EXECUTE PROCEDURE comprobacion_operacion();
