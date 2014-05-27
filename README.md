const-chile
===========

Aplicación para "scraping" y servicios web de valores de distintos indicadores económicos en Chile.


## Fuentes

Aplicación obtiene los datos realizando "web scraping" de los datos publicados en el [Sitio web de Servicio de Impuestos Internos](http://www.sii.cl/pagina/valores/valyfechas.htm).

## Utilización

Por el momento se pueden consultar los siguentes indicadores:
* UF http://ws.empoweragile.cl/api/UF/
* Dolar http://ws.empoweragile.cl/api/Dolar/
* UTA http://ws.empoweragile.cl/api/UTA/
* UTM http://ws.empoweragile.cl/api/UTM/
* IPC http://ws.empoweragile.cl/api/IPC/
* IPC Puntos http://ws.empoweragile.cl/api/IPCPunto/
* IPC Acumulado de año http://ws.empoweragile.cl/api/IPCAcumuladoAno/
* IPC Acumulado últimos 12 meses http://ws.empoweragile.cl/api/IPCAcumulado12Meses/

Los URLs están escritos de manera REST:
http://ws.empoweragile.cl/api/{Indicador}/{Año}/{Mes}/{Día}

Entonces, para consultar el UF del primero de marzo de 2014, uno debe obtener la siguente URL:
http://ws.empoweragile.cl/api/UF/2014/3/1

Alternativamente, puede consultar la fecha directamente:
http://ws.empoweragile.cl/api/UF/2014-03-01



