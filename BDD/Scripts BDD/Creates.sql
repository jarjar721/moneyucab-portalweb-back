
-- -----------------------------------------------------
-- Schema Public
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS Public CASCADE;

-- -----------------------------------------------------
-- Schema Public
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS Public;

-- -----------------------------------------------------
-- Table public.Aplicacion
-- -----------------------------------------------------
DROP SCHEMA public CASCADE;
CREATE SCHEMA public;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;

--No se han agregado los check sobre los atributos de los posibles valores.

--Las claves primarias se componen por las dos primeras letras de la tabla y "_PK".
--Si la tabla es de dos palabras, se utiliza las iniciales de cada una.
--Los atributos tendrán primero la regla superior para identificar los atributos.
--Para las claves foráneas se utiliza el mismo formato con la diferencia de colocar "_FK" en vez de "_PK"
--CREATES ENTITY FRAMEWORKS
---------------------------

-- Table: public."AspNetUsers"

-- DROP TABLE public."AspNetUsers";

CREATE TABLE public."AspNetUsers"
(
    "Id" text COLLATE pg_catalog."default" NOT NULL,
    "UserName" character varying(256) COLLATE pg_catalog."default",
    "NormalizedUserName" character varying(256) COLLATE pg_catalog."default",
    "Email" character varying(256) COLLATE pg_catalog."default",
    "NormalizedEmail" character varying(256) COLLATE pg_catalog."default",
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text COLLATE pg_catalog."default",
    "SecurityStamp" text COLLATE pg_catalog."default",
    "ConcurrencyStamp" text COLLATE pg_catalog."default",
    "PhoneNumber" text COLLATE pg_catalog."default",
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL,
    "SignupDate" date,
    CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUsers"
    OWNER to postgres;

-- Index: EmailIndex

-- DROP INDEX public."EmailIndex";

CREATE INDEX "EmailIndex"
    ON public."AspNetUsers" USING btree
    ("NormalizedEmail" COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-- Index: UserNameIndex

-- DROP INDEX public."UserNameIndex";

CREATE UNIQUE INDEX "UserNameIndex"
    ON public."AspNetUsers" USING btree
    ("NormalizedUserName" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
-- Table: public."AspNetRoles"

-- DROP TABLE public."AspNetRoles";

CREATE TABLE public."AspNetRoles"
(
    "Id" text COLLATE pg_catalog."default" NOT NULL,
    "Name" character varying(256) COLLATE pg_catalog."default",
    "NormalizedName" character varying(256) COLLATE pg_catalog."default",
    "ConcurrencyStamp" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetRoles"
    OWNER to postgres;

-- Index: RoleNameIndex

-- DROP INDEX public."RoleNameIndex";

CREATE UNIQUE INDEX "RoleNameIndex"
    ON public."AspNetRoles" USING btree
    ("NormalizedName" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
-- Table: public."AspNetUserClaims"

-- DROP TABLE public."AspNetUserClaims";

CREATE TABLE public."AspNetUserClaims"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    "ClaimType" text COLLATE pg_catalog."default",
    "ClaimValue" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserClaims"
    OWNER to postgres;

-- Index: IX_AspNetUserClaims_UserId

-- DROP INDEX public."IX_AspNetUserClaims_UserId";

CREATE INDEX "IX_AspNetUserClaims_UserId"
    ON public."AspNetUserClaims" USING btree
    ("UserId" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
-- Table: public."AspNetUserLogins"

-- DROP TABLE public."AspNetUserLogins";

CREATE TABLE public."AspNetUserLogins"
(
    "LoginProvider" text COLLATE pg_catalog."default" NOT NULL,
    "ProviderKey" text COLLATE pg_catalog."default" NOT NULL,
    "ProviderDisplayName" text COLLATE pg_catalog."default",
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserLogins"
    OWNER to postgres;

-- Index: IX_AspNetUserLogins_UserId

-- DROP INDEX public."IX_AspNetUserLogins_UserId";

CREATE INDEX "IX_AspNetUserLogins_UserId"
    ON public."AspNetUserLogins" USING btree
    ("UserId" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
-- Table: public."AspNetUserRoles"

-- DROP TABLE public."AspNetUserRoles";

CREATE TABLE public."AspNetUserRoles"
(
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    "RoleId" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId")
        REFERENCES public."AspNetRoles" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserRoles"
    OWNER to postgres;

-- Index: IX_AspNetUserRoles_RoleId

-- DROP INDEX public."IX_AspNetUserRoles_RoleId";

CREATE INDEX "IX_AspNetUserRoles_RoleId"
    ON public."AspNetUserRoles" USING btree
    ("RoleId" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
-- Table: public."AspNetUserTokens"

-- DROP TABLE public."AspNetUserTokens";

CREATE TABLE public."AspNetUserTokens"
(
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    "LoginProvider" text COLLATE pg_catalog."default" NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Value" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserTokens"
    OWNER to postgres;
	
-- Table: public."AspNetRoleClaims"

-- DROP TABLE public."AspNetRoleClaims";

CREATE TABLE public."AspNetRoleClaims"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "RoleId" text COLLATE pg_catalog."default" NOT NULL,
    "ClaimType" text COLLATE pg_catalog."default",
    "ClaimValue" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId")
        REFERENCES public."AspNetRoles" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetRoleClaims"
    OWNER to postgres;

-- Index: IX_AspNetRoleClaims_RoleId

-- DROP INDEX public."IX_AspNetRoleClaims_RoleId";

CREATE INDEX "IX_AspNetRoleClaims_RoleId"
    ON public."AspNetRoleClaims" USING btree
    ("RoleId" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
-- Table: public."PreviousPasswords"

-- DROP TABLE public."PreviousPasswords";

CREATE TABLE public."PreviousPasswords"
(
	"PasswordID" uuid not null,
    "PasswordHash" VARCHAR(1000) NOT NULL,
    "FechaCreacion" DATE NOT NULL,
    "UsuarioID" text,
    CONSTRAINT "PK_PreviousPasswords" PRIMARY KEY ("PasswordID"),
    CONSTRAINT "FK_PreviousPasswords_AspNetUsers_UsuarioID" FOREIGN KEY ("UsuarioID")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."PreviousPasswords"
    OWNER to postgres;

-- Index: IX_AspNetRoleClaims_RoleId

-- DROP INDEX public."IX_AspNetRoleClaims_RoleId";

CREATE INDEX "IX_PreviousPasswords_UsuarioID"
    ON public."PreviousPasswords" USING btree
    ("UsuarioID" COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-------BASE DE DATOS DISEÑADO POR PROFESOR BISMARCK-------------

-- -----------------------------------------------------
-- Table Public.TipoUsuario
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.TipoUsuario ;

CREATE TABLE IF NOT EXISTS Public.TipoUsuario (
  idTipoUsuario SERIAL,
  descripcion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTipoUsuario))
;


-- -----------------------------------------------------
-- Table Public.TipoIdentificacion
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.TipoIdentificacion ;

CREATE TABLE IF NOT EXISTS Public.TipoIdentificacion (
  idTipoIdentificacion SERIAL,
  codigo CHAR(1) NOT NULL,
  descripcion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTipoIdentificacion))
;


-- -----------------------------------------------------
-- Table Public.Usuario
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Usuario ;

CREATE TABLE IF NOT EXISTS Public.Usuario (
  idUsuario SERIAL,
  idTipoUsuario INT NOT NULL,
  idTipoIdentificacion INT NOT NULL,
  "idEntity" text,
  usuario VARCHAR(20) NOT NULL,
  fecha_registro DATE NOT NULL,
  nro_identificacion INT NOT NULL,
  email VARCHAR(200) NOT NULL,
  telefono VARCHAR(12) NOT NULL,
  direccion VARCHAR(500) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idUsuario),
  CONSTRAINT "FK_Usuario_TipoUsuario" FOREIGN KEY (idTipoUsuario)
        REFERENCES public.TipoUsuario (idTipoUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
  CONSTRAINT "FK_Usuario_TipoIdentificación" FOREIGN KEY (idTipoIdentificacion)
        REFERENCES public.TipoIdentificacion (idTipoIdentificacion) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
  CONSTRAINT "FK_Usuario_Entity" FOREIGN KEY ("idEntity")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.EstadoCivil
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.EstadoCivil ;

CREATE TABLE IF NOT EXISTS Public.EstadoCivil (
  idEstadoCivil SERIAL,
  descripcion VARCHAR(45) NOT NULL,
  codigo CHAR(1) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idEstadoCivil))
;


-- -----------------------------------------------------
-- Table Public.Persona
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Persona ;

CREATE TABLE IF NOT EXISTS Public.Persona (
  idUsuario INT NOT NULL,
  idEstadoCivil INT NOT NULL,
  nombre VARCHAR(45) NOT NULL,
  apellido VARCHAR(45) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  PRIMARY KEY (idUsuario),
	CONSTRAINT "FK_Persona_EstadoCivil" FOREIGN KEY (idEstadoCivil)
        REFERENCES public.EstadoCivil (idEstadoCivil) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Persona_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Comercio
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Comercio ;

CREATE TABLE IF NOT EXISTS Public.Comercio (
  idUsuario INT NOT NULL,
  razon_social VARCHAR(200) NOT NULL,
  nombre_representante VARCHAR(45) NOT NULL,
  apellido_representante VARCHAR(45) NOT NULL,
  PRIMARY KEY (idUsuario),
	CONSTRAINT "FK_Comercio_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Contrasena
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Contrasena ;

CREATE TABLE IF NOT EXISTS Public.Contrasena (
  idContraseña SERIAL,
  idUsuario INT NOT NULL,
  contrasena VARCHAR(20) NOT NULL,
  intentos_fallidos INT NOT NULL DEFAULT 0,
  estatus INT NOT NULL,
  PRIMARY KEY (idContraseña),
	CONSTRAINT "FK_Contrasena_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.TipoTarjeta
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.TipoTarjeta ;

CREATE TABLE IF NOT EXISTS Public.TipoTarjeta (
  idTipoTarjeta SERIAL,
  descripcion VARCHAR(20) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTipoTarjeta))
;


-- -----------------------------------------------------
-- Table Public.Banco
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Banco ;

CREATE TABLE IF NOT EXISTS Public.Banco (
  idBanco SERIAL,
  nombre VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idBanco))
;


-- -----------------------------------------------------
-- Table Public.Tarjeta
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Tarjeta ;

CREATE TABLE IF NOT EXISTS Public.Tarjeta (
  idTarjeta SERIAL,
  idUsuario INT NOT NULL,
  idTipoTarjeta INT NOT NULL,
  idBanco INT NOT NULL,
  numero BIGINT NOT NULL,
  fecha_vencimiento DATE NOT NULL,
  cvc INT NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTarjeta),
  CONSTRAINT "FK_Tarjeta_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
  CONSTRAINT "FK_Tarjeta_TipoTarjeta" FOREIGN KEY (idTipoTarjeta)
        REFERENCES public.TipoTarjeta (idTipoTarjeta) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Tarjeta_Banco" FOREIGN KEY (idBanco)
        REFERENCES public.Banco (idBanco) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.TipoCuenta
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.TipoCuenta ;

CREATE TABLE IF NOT EXISTS Public.TipoCuenta (
  idTipoCuenta SERIAL,
  descripcion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTipoCuenta))
;


-- -----------------------------------------------------
-- Table Public.Cuenta
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Cuenta ;

CREATE TABLE IF NOT EXISTS Public.Cuenta (
  idCuenta SERIAL,
  idUsuario INT NOT NULL,
  idTipoCuenta INT NOT NULL,
  idBanco INT NOT NULL,
  numero VARCHAR(20) NOT NULL,
  PRIMARY KEY (idCuenta),
	CONSTRAINT "FK_Cuenta_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario(idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Cuenta_TipoCuenta" FOREIGN KEY (idTipoCuenta)
        REFERENCES public.TipoCuenta (idTipoCuenta) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Cuenta_Banco" FOREIGN KEY (idBanco)
        REFERENCES public.Banco (idBanco) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.TipoOperacion
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.TipoOperacion ;

CREATE TABLE IF NOT EXISTS Public.TipoOperacion (
  idTipoOperacion SERIAL,
  descripcion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTipoOperacion))
;


-- -----------------------------------------------------
-- Table Public.OperacionesMonedero
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.OperacionesMonedero ;

CREATE TABLE IF NOT EXISTS Public.OperacionesMonedero (
  idOperacionesMonedero SERIAL,
  idUsuario INT NOT NULL,
  idTipoOperacion INT NOT NULL,
  monto DECIMAL NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  referencia VARCHAR(45) NOT NULL,
  PRIMARY KEY (idOperacionesMonedero),
	CONSTRAINT "FK_OperacionesMonedero_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_OperacionesMonedero_TipoOperacion" FOREIGN KEY (idTipoOperacion)
        REFERENCES public.TipoOperacion (idTipoOperacion) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Aplicacion
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Aplicacion ;

CREATE TABLE IF NOT EXISTS Public.Aplicacion (
  idAplicacion SERIAL,
  nombre VARCHAR(45) NOT NULL,
  descripcion VARCHAR(45) NOT NULL,
  estatus VARCHAR(45) NOT NULL,
  PRIMARY KEY (idAplicacion))
;


-- -----------------------------------------------------
-- Table Public.OpcionMenu
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.OpcionMenu ;

CREATE TABLE IF NOT EXISTS Public.OpcionMenu (
  idOpcionMenu SERIAL,
  idAplicacion INT NOT NULL,
  nombre VARCHAR(45) NOT NULL,
  descripcion VARCHAR(45) NOT NULL,
  url VARCHAR(200) NOT NULL,
  posicion INT NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idOpcionMenu),
	CONSTRAINT "FK_OpcionMenu_Aplicacion" FOREIGN KEY (idAplicacion)
        REFERENCES public.Aplicacion (idAplicacion) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Usuario_OpcionMenu
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Usuario_OpcionMenu ;

CREATE TABLE IF NOT EXISTS Public.Usuario_OpcionMenu (
  idUsuario INT NOT NULL,
  idOpcionMenu INT NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idUsuario, idOpcionMenu),
	CONSTRAINT "FK_Usuario_OpcionMenu" FOREIGN KEY (idOpcionMenu)
        REFERENCES public.OpcionMenu (idOpcionMenu) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Evento
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Evento ;

CREATE TABLE IF NOT EXISTS Public.Evento (
  idEvento SERIAL,
  codigo_evento VARCHAR(4) NOT NULL,
  evento VARCHAR(45) NOT NULL,
  estatus INT NULL,
  PRIMARY KEY (idEvento))
;


-- -----------------------------------------------------
-- Table Public.Bitacora
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Bitacora ;

CREATE TABLE IF NOT EXISTS Public.Bitacora (
  idAuditoria SERIAL,
  idEvento INT NOT NULL,
  idUsuario INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  datos_operacion VARCHAR(2500) NOT NULL,
  causa_error VARCHAR(2500) NULL,
  PRIMARY KEY (idAuditoria),
	CONSTRAINT "FK_Bitacora_Evento" FOREIGN KEY (idEvento)
        REFERENCES public.Evento (idEvento) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Bitacora_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.OperacionTarjeta
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.OperacionTarjeta ;

CREATE TABLE IF NOT EXISTS Public.OperacionTarjeta (
  idOperacionTarjeta SERIAL,
  idUsuarioReceptor INT NOT NULL,
  idTarjeta INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  monto DECIMAL NOT NULL,
  referencia VARCHAR(45) NOT NULL,
  PRIMARY KEY (idOperacionTarjeta),
	CONSTRAINT "FK_OperacionTarjeta_UsuarioReceptor" FOREIGN KEY (idUsuarioReceptor)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_OperacionTarjeta_Tarjeta" FOREIGN KEY (idTarjeta)
        REFERENCES public.Tarjeta(idTarjeta) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE UNIQUE INDEX referencia_UNIQUE ON Public.OperacionTarjeta (referencia ASC) ;


-- -----------------------------------------------------
-- Table Public.OperacionCuenta
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.OperacionCuenta ;

CREATE TABLE IF NOT EXISTS Public.OperacionCuenta (
  idOperacionCuenta SERIAL,
  idCuenta INT NOT NULL,
  idUsuarioReceptor INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  monto DECIMAL NOT NULL,
  referencia VARCHAR(45) NOT NULL,
  PRIMARY KEY (idOperacionCuenta),
	CONSTRAINT "FK_OperacionCuenta_Cuenta" FOREIGN KEY (idCuenta)
        REFERENCES public.Cuenta (idCuenta) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_OperacionCuenta_UsuarioReceptor" FOREIGN KEY (idUsuarioReceptor)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE UNIQUE INDEX referencia_UNIQUE_2 ON Public.OperacionCuenta (referencia ASC) ;


-- -----------------------------------------------------
-- Table Public.TipoParametro
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.TipoParametro ;

CREATE TABLE IF NOT EXISTS Public.TipoParametro (
  idTipoParametro SERIAL,
  descripcion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idTipoParametro))
;


-- -----------------------------------------------------
-- Table Public.Frecuencia
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Frecuencia ;

CREATE TABLE IF NOT EXISTS Public.Frecuencia (
  idFrecuencia SERIAL,
  codigo CHAR(1) NOT NULL,
  descripcion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idFrecuencia))
;


-- -----------------------------------------------------
-- Table Public.Parametro
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Parametro ;

CREATE TABLE IF NOT EXISTS Public.Parametro (
  idParametro SERIAL,
  idTipoParametro INT NOT NULL,
  idFrecuencia INT NOT NULL,
  nombre VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idParametro),
	CONSTRAINT "FK_Parametro_TipoParametro" FOREIGN KEY (idTipoParametro)
        REFERENCES public.TipoParametro (idTipoParametro) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Parametro_Frecuencia" FOREIGN KEY (idFrecuencia)
        REFERENCES public.Frecuencia (idFrecuencia) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Usuario_Parametro
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Usuario_Parametro ;

CREATE TABLE IF NOT EXISTS Public.Usuario_Parametro (
  idUsuario INT NOT NULL,
  idParametro INT NOT NULL,
  validacion VARCHAR(45) NOT NULL,
  estatus INT NOT NULL,
  PRIMARY KEY (idUsuario, idParametro),
	CONSTRAINT "FK_Usuario_Parametro_Usuario" FOREIGN KEY (idUsuario)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Usuario_Parametro_Parametro" FOREIGN KEY (idParametro)
        REFERENCES public.Parametro (idParametro) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Reintegro
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Reintegro ;

CREATE TABLE IF NOT EXISTS Public.Reintegro (
  idReintegro SERIAL,
  idUsuario_solicitante INT NOT NULL,
  idUsuario_receptor INT NOT NULL,
  fecha_solicitud DATE NOT NULL,
  referencia_reintegro VARCHAR(45),
  referencia VARCHAR(45) NOT NULL,
  estatus VARCHAR(45) NOT NULL,
  PRIMARY KEY (idReintegro),
	CONSTRAINT "FK_Reintegro_UsuarioSolicitante" FOREIGN KEY (idUsuario_solicitante)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Reintegro_UsuarioReceptor" FOREIGN KEY (idUsuario_receptor)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


-- -----------------------------------------------------
-- Table Public.Pago
-- -----------------------------------------------------
DROP TABLE IF EXISTS Public.Pago ;

CREATE TABLE IF NOT EXISTS Public.Pago (
  idPago SERIAL,
  idUsuario_solicitante INT NOT NULL,
  idUsuario_receptor INT NOT NULL,
  fecha_solicitud DATE NOT NULL,
  monto VARCHAR(45) NOT NULL,
  estatus VARCHAR(45) NOT NULL,
  referencia VARCHAR(45) NULL,
  PRIMARY KEY (idPago),
	CONSTRAINT "FK_Pago_UsuarioSolicitante" FOREIGN KEY (idUsuario_solicitante)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
	CONSTRAINT "FK_Pago_UsuarioReceptor" FOREIGN KEY (idUsuario_receptor)
        REFERENCES public.Usuario (idUsuario) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);