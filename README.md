Turtle Challenge
A turtle must walk through a minefield. Write a program that will read the initial game settings
from one file and one or more sequences of moves from a different file, then for each move
sequence, the program will output if the sequence leads to the success or failure of the little
turtle.
The program should also handle the scenario where the turtle doesn’t reach the exit point or
doesn’t hit a mine.
Notes
There are no restrictions or requirements on how to model the game settings and the
sequences of moves.
Inputs
The board is a square of n by m number of tiles:
5x4 Board
The starting position is a tile (x,y) and the initial direction the turtle is facing (that is: north, east,
south, west):
Starting position: x = 0, y = 1, dir = North
The exit point is a tile (x,y)
Exit point: x = 4, y = 2
The mines are defined as a list of tiles (x,y).
Turtle actions can be either a move (m) one tile forward or rotate (r) 90 degrees to the right.
Example
Given a file containing the board size, starting point and direction, exit point and mines called
“game-settings” and a file containing one or more move sequences called “moves”
When I run the program passing the filenames as a parameters, the program will print out the
result for each sequence in the “moves” file.
