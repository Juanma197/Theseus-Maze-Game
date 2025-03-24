public static class MazeGenerator
{
//GetOppositeWall takes WallState as a parameter and returns the opposite WallState.
private static WallState GetOppositeWall(WallState wall)
{
switch (wall)
{
case WallState.RIGHT: return WallState.LEFT;
case WallState.LEFT: return WallState.RIGHT;
case WallState.UP: return WallState.DOWN;
case WallState.DOWN: return WallState.UP;
default: return WallState.LEFT;
}
}
//Two-dimensional array of type WallState[,] named "maze"
//The maze is generated using the ApplyRecursiveBacktracker method
//Which applies the recursive backtracking algorithm to the maze represented by the WallState[,] array.
private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int width, int height)
{

//The code below uses depth-first search.
//It creates a new instance of the Random class, which is used to generate random numbers.
//It creates an empty stack to keep track of the visited positions in the maze.
var rng = new System.Random();
var positionStack = new Stack<Position>();
var position = new Position { X = rng.Next(0,width), Y = rng.Next(0,height)};

maze[position.X, position.Y] |= WallState.VISITED; //1000 1111
positionStack.Push(position);

//A loop that will continue until all positions in the positionStack have been visited.
while (positionStack.Count > 0)
{
var current = positionStack.Pop();

//GetUnvisitedNeighbours is assumed to be a separate function that takes the current position, the maze array, and the width and height values as arguments.
//It will then return a list of neighbouring positions.
var neighbours = GetUnvisitedNeighbours(current, maze, width, height);


//Checks that there are no unvisited neighbours.
if (neighbours.Count > 0)
{
positionStack.Push(current);

var randIndex = rng.Next(0, neighbours.Count);
var randomNeighbour = neighbours[randIndex];

var nPosition = randomNeighbour.Position;
maze[current.X, current.Y] &= ~randomNeighbour.SharedWall;
maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.SharedWall);

maze[nPosition.X, nPosition.Y] |= WallState.VISITED;

positionStack.Push(nPosition);
}
}

return maze;
}


//GetUnvisitedNeighbours method takes a Position object, a 2D array of WallState objects, and two integers representing the width and height of the maze.
//The method first creates a new empty list of Neighbour objects.
private static List<Neighbour> GetUnvisitedNeighbours(Position p, WallState[,] maze, int width, int height)
{
var list = new List<Neighbour>();

if (p.X > 0) // LEFT
{
if (!maze[p.X -1, p.Y].HasFlag(WallState.VISITED))
{
list.Add(new Neighbour
{
Position = new Position
{
X = p.X - 1,
Y = p.Y
},
SharedWall = WallState.LEFT
});
}
}
if (p.Y > 0) //BOTTOM
{
if (!maze[p.X, p.Y - 1].HasFlag(WallState.VISITED))
{
list.Add(new Neighbour
{
Position = new Position
{
X = p.X,
Y = p.Y - 1
},
SharedWall = WallState.DOWN
});
}
}
if (p.Y < height -1) // UP
{
if (!maze[p.X, p.Y + 1].HasFlag(WallState.VISITED))
{
list.Add(new Neighbour
{
Position = new Position
{
X = p.X,
Y = p.Y + 1
},
SharedWall = WallState.UP
});
}
}
if (p.X < width -1) //RIGHT
{
if (!maze[p.X + 1, p.Y].HasFlag(WallState.VISITED))
{
list.Add(new Neighbour
{
Position = new Position
{
X = p.X + 1,
Y = p.Y
},
SharedWall = WallState.RIGHT
});
}
}
//the method returns the list of neighbouring cells that have not been visited.
return list;
}

//Generate method initializes the maze array and returns the final maze
public static WallState[,] Generate(int width, int height)
{
WallState[,] maze = new WallState[width, height];
WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN;

for (int i = 0; i < width; i++)
{
for(int j = 0; j < height; j++)
{
maze[i, j] = initial;

}
}
return ApplyRecursiveBacktracker(maze, width, height);
}
}

Maze Renderer Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

