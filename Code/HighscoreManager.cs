public class HighscoreManager : MonoBehaviour
{
private string connectionString;
private IDbConnection dbConnection;

void Start()
{
connectionString = "URI=file:" + Application.dataPath + "/Highscores.db";
dbConnection = new SqliteConnection(connectionString);
dbConnection.Open();
}

void OnApplicationQuit()
{
dbConnection.Close();
}

public void GetHighscores()
{
IDbCommand dbCommand = dbConnection.CreateCommand();
dbCommand.CommandText = "SELECT * FROM Highscores ORDER BY Score DESC LIMIT 10";
IDataReader reader = dbCommand.ExecuteReader();
while (reader.Read())
{
string playerName = reader.GetString(0);
int score = reader.GetInt32(1);
}
reader.Close();
}
}


I would get these errors even though both namespaces and the DLL connector were correctly attached.






My SQL

//Try 1

CREATE TABLE highscores (
id INT(11) NOT NULL AUTO_INCREMENT,
player_name VARCHAR(50) NOT NULL,
score INT(11) NOT NULL,
PRIMARY KEY (id)
);

//Try 2

using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public void SaveHighscore(string playerName, int score)
{
string connectionString = "Server=localhost;Database=Highscore;Uid=PlayerName;Pwd=Happy;";
MySqlConnection connection = new MySqlConnection(connectionString);
connection.Open();

string query = "INSERT INTO Highscore (player_name, score) VALUES (@playerName, @score)";
MySqlCommand command = new MySqlCommand(query, connection);

//Error Handling code
command.Parameters.AddWithValue("@playerName", playerName);
command.Parameters.AddWithValue("@score", score);
command.ExecuteNonQuery();

connection.Close();
}


Score Manager Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

