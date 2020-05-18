--Operaciones de acción dentro de la plataforma
---Ingreso e usuario: log_in()[x]
---Registro de usuario Persona[]:
---Registro de usuario Comercio[]:
---Registro de persona de contacto[]:
---Registro de rol para el usuario[]:
----El registro de rol debe tener un procedimiento para cada tipo de rol que englobe los permisos
---Recuperacion de clave[]:
---Cambio de contraseña[]
---Transferencia[]
---Recarga[]
---Reintegro[]

--Comprobación de logeo para el usuario.
CREATE OR REPLACE FUNCTION log_in(username varchar(200), clave varchar(500))
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