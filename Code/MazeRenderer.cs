public class MazeRenderer : MonoBehaviour
{
[SerializeField]
[Range(1,50)]
private int width = 10;

[SerializeField]
[Range(1,50)]
private int height = 10;

[SerializeField]
private float size = 1f;

[SerializeField]
private Transform wallPrefab = null;

[SerializeField]
private Transform floorPrefab = null;

//The Start() method generates a maze using the MazeGenerator.Generate() method and passes the resulting maze to the Draw() method.
// Start is called before the first frame update
void Start()
{
//Generates a visual representation of the maze using prefabs that represent the walls and floor of each cell.
var maze = MazeGenerator.Generate(width, height);
Draw(maze);
}

//The Draw() method uses a nested for loop to iterate through each cell in the maze and render its walls and floor.
//It instantiates wall and floor prefabs and positions them accordingly based on the location of the current cell in the maze.
private void Draw(WallState[,] maze)
{

var floor = Instantiate(floorPrefab, transform);
//Change the value of 0 to 1 to change the whole floor to green.
floor.localScale = new Vector3(width, 1, height);


//Nested for loops.
//They determine the cell's position in 3D space and checks its WallState value to determine which walls should be present.
//It creates a game object which is what will change position.
for (int i = 0; i < width; i++)
{
for(int j = 0; j < height; j++)
{
var cell = maze[i,j];
var position = new Vector3(-width/2 + i, 0, -height/2 + j);

//The method instantiates a new wall GameObject using the wallPrefab argument and positions it at the top of the current cell.
if (cell.HasFlag(WallState.UP))
{
var topWall = Instantiate(wallPrefab, transform) as Transform;
topWall.position = position + new Vector3(0,0, size/2);
topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
}
// Positions it at the left of the current cell.
//It sets the localScale and eulerAngles properties to match the size value and rotate the wall 90 degrees on the Y-axis.
if (cell.HasFlag(WallState.LEFT))
{
var leftWall = Instantiate(wallPrefab, transform) as Transform;
leftWall.position = position + new Vector3(-size / 2, 0, 0);
leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
leftWall.eulerAngles = new Vector3(0, 90, 0);
}
if (i == width - 1)
{
//Positions it at the right of the current cell.
if (cell.HasFlag(WallState.RIGHT))
{
var rightWall = Instantiate(wallPrefab, transform) as Transform;
rightWall.position = position + new Vector3(+size / 2, 0, 0);
rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
rightWall.eulerAngles = new Vector3(0, 90, 0);
}
}
if (j == 0)
{
//Positions it at the bottom of the current cell.
if (cell.HasFlag(WallState.DOWN))
{
var bottomWall = Instantiate(wallPrefab, transform) as Transform;
bottomWall.position = position + new Vector3(0, 0, -size / 2);
bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
}
}
}
}
}



//Update is called once per frame
void Update()
{

}
}

Player Movement Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

