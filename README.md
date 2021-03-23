# GrammarProject
GBUI Project

Voice Recognition Project
Cuan O’Conchuir – G00300230

Unity Version – 2019.4.19f1

Game Concept
The style of game I chose for this submission was a Space Invaders style game.
It is a more simplified version of the original concept, but it includes all the core features of the original. 
The game begins with the player bottom center of the screen. The enemy characters at the top. The enemies slowly move down towards the player, firing bullets at the player at random intervals. The player can move left and right on the screen and also can fire a bullet at the enemies to destroy them one at a time.
The game state conditions include; If the player can successfully shoot and destroy all the enemies a “Win” condition is met. The player has one life and if they get hit by an enemy projectile they are defeated resulting in a “Game Over” condition. Another “Game Over” condition is if the enemy entities reach the bottom of the screen.
There are also the classic obstructions from space invaders that the player can hide behind to block incoming projectiles. They have a limited amount of health and can be destroyed by the enemies if they are hit enough, thus increasing the difficulty of the game as it progresses.
A basic implementation of a score system is also included, but for the sake of the submission being focused on voice commands as opposed to gameplay, it is simplified quite a bit.

Controlling the game
The game uses a grammar recognizer xml file to parse commands. Each rule is returned via the “meaning” string which is switched upon to determine functionality. For example: The moveL rule is returned as “moveL” to the switch which gives x axis movement to the player. This rule can be called upon through various phrases and speech terminology. 
The defined rules are as follows: (in no particular order)
Pause:
-	Allows the player to pause the game at any time.
-	Defined and interpreted with phrases like:
o	Pause the game
o	Pause game
o	Pause
Resume:
-	Allows the player to resume the game from a pause state.
-	Defined as:
o	Resume
o	Resume the game
o	Go
o	Start
o	Start game
o	Continue
o	Continue game
moveL:
-	Allows leftward x axis movement, which is constant until told to stop.
-	Defined as:
o	Go left
o	Move left
o	Travel left
o	Left
moveR:
-	Allows rightward x axis movement, which is constant until told to stop.
-	Defined as:
o	Go right
o	Move right
o	Travel right
o	right
stop:
-	Stops the players x axis movement at the desired point.
-	Defined as:
o	Stop
o	Stop moving
o	Stop now
o	Wait
o	Stop there
Fire:
-	Allows the user to fire a projectile up the Y axis towards the enemies.
-	Defined as:
o	Shoot
o	Fire
o	Shoot now
o	Fire now
o	Shoot gun
o	Fire gun

A visual representation of the game can be seen below:

 

 Some things to note about the submission:
There is no main menu GUI, as I felt it wasn’t a meaningful way to spend my development time, since we have created many in the past and the core concept of this submission is to show how the grammar systems work which is where I spent most of my time.
There is a known bug with the “Game Over” condition where it does not trigger. I spent quite a large amount of time trying to debug it but gave up due to time constraints. Apologies for that.
