public class PauseMenu : MonoBehaviour
{
//Variables
public static bool GameIsPaused = false;
public GameObject pauseMenuUI;

//Update is called once per frame
//Checks if the Escape key has been pressed using the Input.GetKeyDown function.
void Update()
{
if (Input.GetKeyDown(KeyCode.Escape))
{
if (GameIsPaused)
{
Resume();
}
else
{
Pause();
}
}
}

//It hides the pause menu, sets the time scale back to normal (1f), and sets GameIsPaused to false.
public void Resume()
{
pauseMenuUI.SetActive(false);
Time.timeScale = 1f;
GameIsPaused = false;
}

//Shows the pause menu, sets the time scale to 0f (pausing the game), and sets GameIsPaused to true.
void Pause()
{
pauseMenuUI.SetActive(true);
Time.timeScale = 0f;
GameIsPaused = true;
}

//Sets the time scale back to 1f, loads the "LevelSelection" scene.
public void LoadMenu()
{
Time.timeScale = 1f;
SceneManager.LoadScene("LevelSelection");
Debug.Log("Loading menu...");
}

//Logs a message to the console and calls Application.Quit(), which quits the game.
public void QuitGame()
{
Debug.Log("Quitting game...");
Application.Quit();
}
}

The Database Mystery Code
This is where I started having problems, I tried different ways of connecting the database to Unity, I installed SQLiteStudio which is a management app for a database which is used online and on an online server and coded the connection to Unity. I coded in SQLite in three different ways, of which none were successful, then I changed the management service DB Browser but no luck. After a few days of trying, I then switched to My SQL and downloaded the package and phpMyAdmin which is like DB Browser for SQLite but for My SQL, I coded queries in the management app for My SQL and even tried writing a DLL file directly to Unity to solve the issue but couldn’t solve it. After a week, I tried to use MySQL Connector/NET library to establish a connection to the database, the code was working perfectly but I still had errors in Unity, so it wasn’t connecting. So, after careful consideration and imploring how this would affect the project, I spoke with the Stakeholder of the project to see his opinion.


Solution
After my chat with the stakeholder, we agreed that the high score will be saved but will have to restarted manually. Doesn’t change the game or the end aim, it’s just that it doesn’t have a visual table to demonstrate the values so the players would have to remember the values themselves.
Below its some of the code that I used to try make the connection to Unity, but all were unsuccessful. I was using my ER diagram as a template, but I didn’t quite manage to advance since the first scripts that were vital for the database to work weren’t working.

SQLite

//Try 1



//Try 2

using System.Data;
using Mono.Data.Sqlite;

