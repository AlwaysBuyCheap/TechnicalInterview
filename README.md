# TechnicalInterview

Antes de lanzar el proyecto debe iniciar la base de datos,
para ello ejecute el siguiente comando en la raiz de la 
solucion:

docker-compose up -d --build

Para poder usar el proyecto debera establecer las variables 
de configuracion, para ello, en el proyecto TechnicalInterview
haga click con el boton derecho (en el visual studio) y seleccione
'manejar secretos de ususario', introduzca las siguientes variables
en el fichero secrets.json que se abrira:
  "WEATHER_API_ACCESS_KEY": "tu clave secreta para la api de weather",
  "MYSQL_USER": "root",
  "MYSQL_PASSWORD": "Admin@123",
  "MONGODB_USER": "root",
  "MONGODB_PASSWORD": "abc123.."