# Space Blocks

#### Video Demo:  <URL HERE>

#### Description:
A Tetris style block building game that happens in space. Each level has a target of 20 lines to clear. You clear lines by getting 10 blocks on a line. When 10 blocks are on a line the blocks are destroyed. At each progressive level the speed at which the shapes fall increase which  increases the difficulty. If the blocks stack up to the top the game is over.


## Controls

Up Arrow - Changes Rotation of a Shape

Left Arrow - Moves the shape one unit to the left

Right Arrow - Moves the shape one unit to the right

Down Arrow - increases the speed of the falling shape


## Introduction

The aim was to recreate the classic block building game from scratch using the skills I acquired in CS50 while learning the unity game engine and C# along the way. I chose Unity because it uses C# which has similar syntax to the C language which I really enjoyed working with in the CS50 course.


## Design Decisions

I decided not to use the physics engine in unity for the project, all the movement of the blocks in the game are deliberate and controlled. Shapes fall automatically when there is nothing obstructing them. Also I have broken down as much of the game logic as I could into separate game objects in order to reduce complexity and not have spaghetti code, the aim was abstraction as much as possible.


## Game Logic

### The Individual Block Logic

* The individual blocks are game objects with a  script component added to each.
* The script component of each block is called “Block\_Script”
* The individual block game objects have a sprite renderer attached with a sprite inside it which I design in Affinity designer, based on the colours of the original Tetris game
* The aim was to create a look for the blocks the was reminiscent of my childhood. I wanted them to look almost like Jelly.
* Inside the “Block\_Script” there are 2 variables called positionX and positionY
* These variables take the world position of the block and add an offset value so that the most left position on the X plane starts at 0 and not negative six and lowest position on the Y plane starts at zero and not negative ten

### The Shape Logic

* Each shape game object consists of child game objects which are the individual blocks.

* They are placed to form the  standard “Tetris Style” Shapes.

* Each Shape game object has a script component attached called “Shape\_Script”

* The shape script has methods that check to see if there are any obstructions below each of the Shape Game objects child blocks.

* If there are no obstructions it will move one unit down until in encounters and obstruction or its lowest block in the shape’s positionY is equal to zero.

### The Block Array

* In order to store the positions of each block I decided to use an array.

* The array is structured as a 2D array of Game Objects which correlate to the positionX and PositionY of the individual blocks

* The individual blocks variables are constantly updating themselves with positionX and positionY variables in their “Block\_Script”

* Because the lowest a block can go is positionY = 0 and the furthest to the left a block can go is positionX = 0 these variables work directly with the array;

* The array is made up of 22 rows and 10 columns

* When the Shape stops moving its individual child blocks are written to the array

###  The Shape Instantiator

* I made prefabs of each individual shape.

* In the scrip component of the shape instatiator a list is created of all the prefab shapes

* The Shape Instantiator chooses the list  randomly and instantiates a shape

* It’s method is called at the start of the game to instantiate the first shape and every time a currently instantiated shape stops it is called again and a new shape is instantiated

* I created an event Action that sends the most recently instantiated shape to the Shape Controller every time a shape is instantiated the event Actions invoke() method is called

### The Shape Controller

* The shape controller contains logic for controlling the most recently instantiated shape

* When a shape is instantiated it is sent to the Shape controller

* The controller uses logic to determine the key presses of the user and moves accordingly or rotates.

  * Up Arrow - Changes Rotation of a Shape

  * Left Arrow - Moves the shape one unit to the left

  * Right Arrow - Moves the shape one unit to the right

  * Down Arrow - increases the speed of the falling shape

### The Block Destroyer

* The Block Destroyer contains a script component called BlockDestroyer\_Script

* When a shape stops moving due to an obstruction and is written into the array, the script checks the array to see if there are any rows completely full

* If there is a row that is completely full it will destroy all game objects on that row I.e the individual blocks on the row.

### The Score Tracker

*  The Score Tracker contains a script component

* When a row of blocks is destroyed the BlockDetroyer Script sends info to the Score Tracker via an event Action

*  The Score tracker updates its values for Score, Target and Level

  * Score - is the score which is incremented by one every time a row is destroyed

  * Target - is the current target of the level, each level has a target of 20 and when the a row is destroyed the target is decremented by one, when the target reaches zero the level is updated and target is set to 20 again

  * Level - The level starts at 1 and goes up once the target reaches zero. As each level goes up the speed of the game increase, this is done by increasing the Time variable

* The Score sends the information to the various ui display elements via event Actions

  

### Game Over Menu

*  When the user runs out of places to place the shapes and the last instantiated shape reaches above the threshold on the Y axis the game is over and the game over screen is displayed, it allows a user to exit the game or restart.


## Scenes

* The Game consists of 2 scenes:

  * Menu\_Start - When the game starts for the first time you are greeted with the start screen where you can choose to start the game or quit.

  * Game - This is the scene that is the actual game, its is activated when a user starts a new game or restarts a game using scene management

## UI and Creative

* The Game UI is contained in a Canvas Game Object

* It contains the Score, Target and Level Display as well as the guiding lines of the game

* The fonts for the Score, Target and Level where chosen to look like a digital clock this gives the game a retro arcade feel

### The Logo

* I have also designed the logo for Space Blocks which you see on the start screen in Affinity Designer, the look is designed to be retro arcade style

### The Background

* The background image is a beautiful free image I found of space, I added a dark overlay to it so that it doesn’t overpower or distract the user when playing the game

## Conclusion

All in all it was a great journey, I really wanted to challenge myself to do something different and I am very happy with the results. There were a lot of sleepless nights trying to figure out how to solve some problems I encountered but the aim for me was to learn as much as I could while doing this and the best way to learn is by doing.
