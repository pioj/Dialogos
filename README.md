# Diálogos2D

### Sistema de diálogos entre personajes

### Author
[☕ Carlos Lecina](https://ko-fi.com/carloslecina)

------

Compatible con **Unity3D v.2018+ LTS**

------

### Descripción

**Diálogos2D** es un pequeño y simple SDK para crear y mostrar diálogos entre personajes. Los diálogos se guardan como **ScriptableObjects** dentro del Proyecto y se pueden gestionar mediante un sencillo Componente que viene incluído.

El SDK contiene tanto los scripts necesarios como una herramienta de *Editor* para generar Assets compatibles a partir de archivos JSON.

Para la demostración, se ha creado un Proyecto de ejemplo de un Videojuego 2D Pixel Art de plataformas. En su *GameManager* hay un componente que reproducirá los Assets de diálogo que se asignen.

La escena contiene un escenario Tilemap y lleva una cámara Pixel Perfect implementada. Tambíén incluye un *Player* mínimamente controlable.

El objetivo es que al desencadenar un evento o pulsar un botón, se reproduza una secuencia de conversaciones de texto. (juego de referencia: IDLE APOCALYPSE)

------

### Estructura

Un Asset *SO_Dialogo* es una **List<*Frase*>**.

*Frase* es una **Struct** compuesta de:  **String** *texto*, **Int** *id de personaje*, y  **Float** *duración*.

Se ha diseñado de forma que "una *Frase* que dice un *personaje* dure **x** *segundos*". Así se puede extender el sistema para permitir enfocar la cámara al personaje que hable en ese momento, y que al terminar el texto se cierre el bocadillo de texto, etc. 

En un futuro espero poder hacer compatible el sistema con otros Assets como DOTween y similares...

------

### Funcionamiento

Al script o Controller de turno se le añade el Componente que gestiona los Assets de Diálogos. Este Componente debería requerir al menos un Canvas o un TMP_Text para relacionarlos con el Asset.

El controller genera un **IEnumerator[ ]**, que se rellena con una misma subrutina, pero pasándole la siguiente *Frase* de la colección en cada llamada. Luego las llama una a una usando ***StartCoroutine()***.

La subrutina "base" como tal es algo tan simple como mostrar el Canvas, poner el texto y esperar X segundos. Se puede personalizar como se quiera.

------

### AVISO: Work In Progress

Todo un poco en pañales todavía, pero en breve lo organizaré mejor y crearé el correspondiente *.unitypackage para subirlo como *Release*. Paciencia, por favor...
