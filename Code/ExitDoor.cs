public class ExitDoor : MonoBehaviour
{

public int iLevelToLoad;
public string sLevelToLoad;

public bool useIntegerToLoadLevel = false;


//It checks if the colliding game object has the name "Player", and if so, it calls the LoadScene method.
private void OnTriggerEnter(Collider collision)
{
GameObject collisionGameObject = collision.gameObject;

if (collisionGameObject.name == "Player")
{
LoadScene();
}
}

//The LoadScene method checks the value of "useIntegerToLoadLevel" and loads the scene specified by "iLevelToLoad" if true or by "sLevelToLoad" if false.
void LoadScene()
{
if (useIntegerToLoadLevel)
{
SceneManager.LoadScene(iLevelToLoad);
}
else
{
SceneManager.LoadScene(sLevelToLoad);
}
}

}




Testing

I finished coding the program and will now start testing all the classes, functions, algorithms, and settings used in my scripts and in Unity including the UI coded and the UI set up through Unity functions. All the tests are in the tables written below, the first table shows the objectives from the analysis that were specified and agreed at the beginning with the stakeholder, the last table shows the classes and methods and some of the visuals that the program is supposed to have when the code is ran. Some of the components of the scripts and settings attached to Unity will not be visible due to a few scripts act as a background algorithm. In my case, the maze generator algorithm script cannot be seen visually as it’s being created, as a viewer we can tell it works because the maze is correctly configured, and it’s being created randomly hence the algorithm works the way it’s supposed to. Most of the testing of the program will be done either in the Unity Editor or in the IDE (Integrated Development Environment) to make sure everything works in order.

Test Plan Results

Objectives Results (Compared to the Analysis’s objectives)

The objectives data plan is at the start of the technical solution to help orientate on what I need to achieve and what I can add according to time and ability. This section is the results after the code has been finished and I compare it to the original objectives.



Typical Data







Typical Data Results
The classes and the data required for the game to work and be playable. As stated in the objectives, every single result in this section should pass since this is standard requirement of the clause of the game agreement.

Player Movement()

Timer()


Enemy()


Pause Menu()

Maze Generator()


Maze Renderer()

Score Manager()

Exit Door()

FPS Controller()

Main Menu Scene()



Evidence

Maze Generator Evidence

Maze Generator script shown in the technical solution attached to unity in my project.
In the screenshots below, I show the floor and wall prefabs which make the maze. The maze is always random, and this shall be shown in later images as well.

































The image below represents the view of the maze generator in game from the unity editor view, how I edit the dimensions and the camera view as well. The rest of the images are of levels of the game showing that every time the game reloads, it’s a completely different game. This will also be shown in the demonstration video.





















Maze Renderer Evidence

The maze renderer uses the maze generator script algorithm and unites the prefabs it changes the size of the maze in terms of width and height.

















Player Movement Evidence
The player moves from the first position in the beginning to the 2nd position, as you can see, the mazes are identical since the photos are both from the same game just 15s later.










In the photos underneath, it shows the attributes of the player class that is connected to the game object defined as player. Most of the attributes are predefined by Unity like Transform and RigidBody, but I still must change its dimensions according to the size/ distance of the maze.
Other attributes like the Character Controller and Player Movement Script, I added to make the game object move and to connect it to the keys, also to specify its variables which form part of the game. (Gravity, Ground, Move and Walk)














































FPS Controller Evidence
Level 5 uses the same backtracking algorithm and the same classes; the only difference is that the player has a script of FPS controller (for 3D movement) instead of the player movement script which is for 2D movement. Since the maze was originally designed in 3D, the only thing to create the 3D maze was to unite the camera to the player and change the angle of projection to the player’s vision instead of looking at the maze from above like in the other levels.
Below is the player and the camera view:



























































Enemy AI Evidence
The cube below is a game object representing the enemy AI, without the code and it’s attributes, the cube would just fall below into nothingness. In the photos below, I show the area (green floor) which the enemy uses to mobilize since it doesn’t recognise the floor created by the algorithm since its random and only created when the game is started. This was fixed by adding an enemy floor which basically is the navigation area for the enemy where he chases the player if in that area, since the maze is smaller than said area, the player will always be as well so the enemy will chase the enemy no matter what.












































































Pause Menu Evidence
Only appears when Esc (escape) is pressed.


































































Score Manager Evidence







































Timer Evidence





















































Exit Door Evidence





























Final Settings and Details



















Results of Testing
All the objectives that were a must, were met, all the objectives in the should were met as well and almost all of the could objectives were completed. The main functions and the working algorithms and classes were very successful.



Evaluation

Objectives Comparison
I have reached the end of my program; this is my final version of my game which contains most of the features and specifications required by the user and meets almost all of the objectives predefined, I will now explain the requirements and objectives, which ones were met, and which ones weren’t.

Have a randomizer algorithm to create the map/maze (“No game should be the same map”).
This was met to its full extent; I created a recursive backtracking algorithm that worked with the prefabs designed in Unity. The maze generator script connects to the maze renderer and randomises the map created.

Have a Menu Scene with access to all the levels.
This was met to its full extent; the menu scene connects to all the levels, and it is formatted to be the first scene to appear when you play the game so you can directly choose which level you want to go into.
Pause Menu accessible whenever the player wants (“In Game”) through pressing keys in the keyboard.
This was met to its full extent; The pause menu can be called from any scene level by pressing Esc key in the keyboard, the functions within the pause menu work fully but the quit function only works in the phone, it doesn’t work in the unity IDE.
Pause Menu should stop the game and have labels, buttons.
This was met fully to its extent; it has 3 buttons, resume, menu and quit, all with fully working functionalities. The physics and time components of the game stop when esc is pressed.
Door, portal to advance to next level, all levels to be connected.
This was met to its full extent; the door is fully connected to all the levels and the last level has 2 doors as well!
2D interpretation.
All of the levels have a 2D level interpretation except the bonus 3D level which I had time to include.
Visual Image of maze, player, and the door.
This was met to its full extent; all of the game Objects are fully visible and can be easily differentiated due to the contrast in colours in the creation of the project.
Enemy creation that chases player.
This was met to its full extent; The enemy player has an A.I method and functioning that basically chases the player on a certain area, since the area is the whole maze, it will constantly chase the player.
Active Timer that stops when Pause Menu is active.
This was met to its full extent; the timer is coded to stop included with the physics and movement of the enemy when the pause menu function is called.
Score Count directly proportional to the timer.
This was met to its full extent; As the time increases, so does the score count.
Path from start (starting point of player) to finish (door/exit/portal).
This was met to its full extent; The recursive backtracking algorithm has a searching algorithm within it that makes sure there is always a path from the start of the maze to the end.
Be a tractable problem (solvable in reasonable amount of time).
This was met to its full extent; The game is a tractable problem since if you can’t complete the maze, then the enemy will basically kill you and you will have to restart the level.
Player Death when colliding with Enemy.
This was met to its full extent; the player “dies” and the level restarts, the score also restarts when enemy collision happens.
Save highest score and keep it in game so the player can try to beat it.
This was met to its full extent; the high score is saved using Player Prefs and successfully stays saved when open.
Have a maze renderer (software process that generates a visual image from a model).
This was met to its full extent since a maze renderer is connected accordingly to the maze generator and fully creates the dimensions of the maze.
Have a stop button; to be able to pause the game, a stop button in the screen or by pressing a desired key in the keyboard.
This was met to an extent since the game stops with the pause function, but it doesn’t have a button labelled as stop. But the functionality is still the same.
Advance into harder level of complexity every time player goes through a portal/door.
This was met to its full extent. The dimensions increase and the area of game play also increases to make it more complex to make it to the door.
Be the same wall dimensions per scene.
This was met to its full extent; since the dimensions do not change when playing the game nor do they change when you die and respawn.
Be the same floor dimensions per scene.
This was met to its full extent; since the prefab is predetermined, so are their dimensions.
Have the timer to two significant figures.
This was met to its full extent since the timer is coded to only show 00:00 hours and seconds.
Have a score count and a variable high score count which changes when the score count increases higher than the current high score.
This was met to its full extent; The scenes have 2 boxes on the top left and top right for the scores and the high score saving which increases if score passes high score.
Have a resetting function; it should have a button or function in the keys to reset the game.
This was met to an extent since there isn’t a resetting function or button, but you can pause the game click main menu and click the same level/scene and you have reset the game!
3D game version of the 2D algorithm.
This was met to its full extent since I created a full working game of a maze in 3D where the player works as if he is in an FPS shooter game except the guns of course.
Definite speed throughout the level and as you advance, enemy increase in speed.
This was met to its full extent, since the enemy does increase in speed when the level gets bigger.
Range of enemy, minimal (on collision with player).
This was met to its full extent since the range is very small (0.05x dimensions) so hence the player can evade the enemy even if the player goes into a blocked passage.

Unmet Specification Requirements
Most of the objectives and what we agreed upon was completed except the stats information scene. Like I explained in Technical Solution in real time, I tried and put a lot of effort in trying to figure out a way to complete it, but it ended up being unsuccessful. I contacted the Stakeholder and told him about what happened, and his response was a bit dry, and he seemed annoyed, but he accepted it since after all, the program does save the high score just cannot compare it.
Stakeholder Response.


Added Bonus and Limitations that were accomplished.


The code for the Enemy, uses AI, not complex but AI nonetheless, it uses an On Collision script instead of a range and the line of vision is infinity.

Stakeholder Views on the finished project

