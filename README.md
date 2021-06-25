# Hackencio

### Juego para tópico II

### Cosas que faltan:
 - [ ] Enemigos
  - [X] Sprite y animacion de caminar
  - [X] Script para patrullar
  - [X] Si toca al jugador es GG
  - [ ] Perseguir al jugador  
 - [ ] Otro Puzzle
 - [ ] Diseño de nivel
 - [ ] ...cosas

# Como abrrir el juego en Unity

 - Clonar el repositorio
 - Abrir Unity Hub
 - Añadir nuevo proyecto
 - Seleccionar carpeta donde se clono el repo
 - Listo!

# Como agregar elementos al juego

## Como crear nivel:
 - Crear nueva escena
 - Crear nuevo tilemap
 - Usar paleta con tiles
 - Pintar
 - Agregar componente TilemapColission2d
 - Agergar material "resbaloso" (para que no se puedan escalar)

## Agregar Escaleras:
 - Agregar el sprite de escaleras
 - Dentro del inspector agregar el tag de "Ladder"
 - Agregar componente BoxColiision2d
 - Marcar la opcion isTrigger dentro de este

## Como agregar personaje:
 - Arrastrar prefab del personaje al nivel y listo

## Agregar movimiento de camara:
 - Crear cinemachine 2d
 - Arrastrar el personaje a donde dice "Follow"
 - Crear un gameObject vacio
 - Agregar componente PolygonCollision2d
 - Marcar la opcion isTrigger dentro de este

