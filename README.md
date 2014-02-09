Munching Monsters Mayhem
========================
EECS290 Spring '14, Team 8
--------------------------

Hey guys,

Included in this .zip file are the assets for a 2D grid creator/maze generator using a modified version of Prim's Algorithm.  

On the Grid object, setting an X and Z dimension will define the size of the maze (Y makes no difference).
I've found that 30 x 30 mazes tend to be complex enough, but feel free to try whatever size you want.
Be careful though, anything over 100 x 100 will have 10,000+ total cells and takes a long time to load (but it's really cool to watch the maze generate).
The variable 'PathCells' contains all of the white cells in Grid (the path).

Note: Pressing 'F1' in-game will reload the level and generate a new maze.

I've designed it so that white cells represent the paths through the maze and the black cells represent walls.  Based on this code, 
we want you to make the maze 3D.  You will also need to add walls around the maze perimeter or else you may walk right off of it.  
The green cell represents the start and the red cell represents the end.

Once you have made the maze 3D and contained, you can use it to complete Group Assignment 6, in which you will create a player with controls to navigate
the maze, monsters within the maze, collectibles, and whatever else you want to add.

Feel free to read through the code I have provided and make any changes or remove any comments 
you want (as long as it remains functional).  It is important to understand how the Grid is created
and how to access the list PathCells (for spawning purposes, etc.).

This will be your first seriously graded project for the course (I'm guessing), so don't hold back and be as creative as you can!
And as always, just let me know if you have any questions.

-- Tim