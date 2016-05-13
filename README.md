---
title:  "MOM"
subtitle: "Mom's Online Monitor"
author: "Fernando Agosto Cruz, Jishar Rodriguez Aguilar"
avatar: "img/authors/wferr.png"
image: "img/e.jpg"
date:   2016-05-13 11:15:00
---

### MOM
¿Que es MOM?


Es un sensor de movimiento para la prevención del síndrome muerte súbita (SIDS) 

### ¿Porque es un problema el SIDS?
La muerte súbita del lactante es la principal causa de fallecimiento de los bebés menores de un año. Aún se desconoce a ciencia cierta su causa, aunque sí factores que la predisponen. Es decir, no hay forma de evitarla, aunque sí de prevenirla.

La asfixia de posición ocurre cuando el bebé duerme, o se queda dormido en un lugar peligroso, o en una posición peligrosa. 


Ejemplos de lugares peligrosos incluyen: Sillones, camas de agua,sillas rellenas de bolitas, almohadas, bebés compartiendo cama con otras personas,cunas con colchones que no son de tamaño apropiado,camas de adulto,cunas con pieles de borrego, acolchadas y otras superficies suaves


También puede ser causada por una mala posición como: Dormir elevado, dormir en un carrito de bebé con la cabeza cubierta, o con la cara contra una superficie suave, incluyendo el pecho de los padres, dormir de lado.


### ¿Como funciona?

El dispositivo se encontrara adaptado a la ropa del bebe de tal forma que no presente un obstaculo al dormir, este se encontrara a la altura del estomago.


El acelerómetro va a monitorear la posición del bebé cuando este se encuentre durmiendo, seguidamente lo datos serán enviados por medio de un dispositivo ESPino (módulo wifi), este dispositivo se conecta a la red wifi para enviar la información a una  API que se encuentra alojado en un servidor web  y así procesar la petición (guardar y actualización ).


Las alertas serán generadas por medio de una aplicación en un smathphone, esto para la detección inmediata de un posible movimiento inadecuado.


###Tecnologia 
Se utilizo la siguiente tecnologia para el desarrollo de este proyecto:


Hardware:


Acelerómetro lsm9ds0, ESPino - módulo ESP8266, Dispositivo móvil (Sistema operativo Android)


Software:


Servidor web, API REST en PHP, Aplicación Android C#


### Prototipo
El diseño se hizo lo mas pequeño y funcional posible, cabe destacar que se utilizo un hilo conductor para ser adaptado como tecnologia vestible.


En la siguiente imagen observamos el prototipo y su implementación.
<img class="image-center" src="img/mom/1.JPG"  style="display:inline"/>
<img class="image-center" src="img/mom/2.jpeg"/ style="display:inline">


Vista de la aplicación.


<img class="image-center" src="img/mom/app1.JPG"  style="display:inline"/>
<img class="image-center" src="img/mom/"/ style="display:inline">



### Activación de la alerta
<iframe width="560" height="315" src="https://www.youtube.com/watch?v=2kjEEVfhhww&feature=youtu.be" frameborder="0" allowfullscreen></iframe>


### Repositorios

*Repositorio de la API [Ver repositorio](https://github.com/fdoago/MomDevices)


*Repositorio de ESPino [Ver repositorio](https://github.com/fdoago/MomDevicesEspinoLuaSender)

