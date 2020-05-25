DROP SCHEMA public CASCADE;
CREATE SCHEMA public;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;

--No se han agregado los check sobre los atributos de los posibles valores.

--Las claves primarias se componen por las dos primeras letras de la tabla y "_PK".
--Si la tabla es de dos palabras, se utiliza las iniciales de cada una.
--Los atributos tendrán primero la regla superior para identificar los atributos.
--Para las claves foráneas se utiliza el mismo formato con la diferencia de colocar "_FK" en vez de "_PK"

CREATE TABLE Persona
(
  PE_PK SERIAL,
  US_FK INTEGER NOT NULL,
  PE_NOMBRES VARCHAR(60) NOT NULL,
  PE_APELLIDOS VARCHAR(60) NOT NULL,
  PE_TELEFONO VARCHAR(7) NOT NULL,
  PE_TELEFONO_CODIGO VARCHAR(3) NOT NULL,
  PRIMARY KEY (PE_PK),
  CONSTRAINT PERSONA_USUARIO_ID FOREIGN KEY (US_FK)
      REFERENCES Usuario(ID) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Comercio
(
  CO_PK SERIAL,
  US_FK INTEGER NOT NULL,
  CO_NOMBRE VARCHAR(60) NOT NULL,
  CO_TELEFONO VARCHAR(7) NOT NULL,
  CO_TELEFONO_CODIGO VARCHAR(3) NOT NULL,
  CO_DIRECCION VARCHAR(200) NOT NULL,
  PRIMARY KEY (CO_PK),
  CONSTRAINT COMERCIO_USUARIO_ID FOREIGN KEY (US_FK)
      REFERENCES Usuario(ID) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Persona_Contacto
(
  PC_PK SERIAL,
  PE_FK INTEGER NOT NULL,
  CO_FK INTEGER NOT NULL,
  PRIMARY KEY (PC_PK),
  CONSTRAINT PERSONA_CONTACTO_PERSONA_ID FOREIGN KEY (PE_FK)
      REFERENCES Persona(PE_PK) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT PERSONA_CONTACTO_COMERCIO_ID FOREIGN KEY (CO_FK)
      REFERENCES Comercio(CO_PK) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Monedero
(
	MO_PK SERIAL,
	MO_SALDO FLOAT NOT NULL,
	MO_LIMITE_DEUDA FLOAT,
	MO_LIMITE_OPERACION FLOAT,
	MO_LIMITE_MONTO_DIARIO FLOAT,
	US_FK VARCHAR(1) NOT NULL,
	PRIMARY KEY (MO_PK)
	CONSTRAINT COMERCIO_USUARIO_ID FOREIGN KEY (US_FK)
      		REFERENCES Usuario(ID) MATCH SIMPLE
      		ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Status
(
	ST_PK VARCHAR(2) NOT NULL,
	ST_TIPO VARCHAR(1) NOT NULL,
	ST_DESCRIPCION VARCHAR(300) NOT NULL,
	PRIMARY KEY (ST_PK)
);

CREATE TABLE OPERACION
(
	OP_PK SERIAL,
	OP_FECHA DATE NOT NULL,
	OP_MONTO FLOAT NOT NULL,
	OP_TIPO_OPERACION VARCHAR(1) NOT NULL,
	OP_MONEDERO_DESTINO_PK INTEGER NOT NULL,
	OP_MONEDERO_ORIGEN_PK INTEGER NOT NULL,
	ST_FK VARCHAR(2) NOT NULL,
	PRIMARY KEY(OP_PK),
	CONSTRAINT OPERACION_STATUS_ID FOREIGN KEY (ST_FK)
      REFERENCES Status(ST_PK) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  	CONSTRAINT OPERACION_MONEDERO_DESTINO_ID FOREIGN KEY (OP_MONEDERO_DESTINO_PK)
      REFERENCES MONEDERO(MO_PK) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT OPERACION_MONEDERO_ORIGEN_ID FOREIGN KEY (OP_MONEDERO_ORIGEN_PK)
      REFERENCES MONEDERO(MO_PK) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);
