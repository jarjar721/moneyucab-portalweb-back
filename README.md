# MoneyUCAB Backend
Web API para el Portal Web de MoneyUCAB - Desarrollo de Software 202025 UCAB

Basada en la arquitectura de N Capas, el backend conforma la definición y uso de la capa de lógica de negocio y de datos. Aunque el backend sería parte de la lógica de negocio, 
la realidad de lo desarrollado es que se encapsuló toda la lógica del modelo a través de base de datos con la definición de procedimientos y triggers con este objetivo, dejando
al backend como la interfaz de acceso a estos datos y por los cuales se controla el procesamiento de solicitudes, sirviendo como medio de definición de cualidades técnicas (requerimientos
no funcionales).


## Base de Datos
Definición de base de datos para producción [Build](https://github.com/jarjar721/moneyucab-portalweb-back/tree/development/BDD/Scripts%20BDD)

La base de datos tiene una constitución de dos partes:
Entity - Desarrollo

AspNetUsers y Usuario constituyen la unión de las dos partes de base de datos.

#### Entity - Framework de autenticación
Entity establece el framework para el ASP.NET web api para establecer la seguridad de autenticación para los usuarios dentro de las aplicaciones que constituyen el proyecto de
MoneyUCAB.

#### Desarrollo - Base de datos estándar para MoneyUCAB
Se establece acá el estándar de datos y procedimientos además de la lógica que conlleva para el proyecto MoneyUCAB.
