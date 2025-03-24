public class ScoreManager : MonoBehaviour
{

//Used to display the current score and high score in the game's UI.
public Text ScoreText;
public Text HiScoreText;

//Will store the current score and high score values.
public float scoreCount;
public float hiScoreCount;

//Rate at which the score increases.
public float pointsPerSecond;

public bool scoreIncreasing;


// Start is called before the first frame update
//It loads the high score value from PlayerPrefs and assigns it to the hiScoreCount field.
void Start()
{
if (PlayerPrefs.GetFloat("HighScore") != null)
{
hiScoreCount = PlayerPrefs.GetFloat("HighScore");
}

}

// Update is called once per frame
//scoreCount value is compared to the hiScoreCount value, and if it is greater, hiScoreCount is updated, and the new value is saved to PlayerPrefs.
void Update()
{
if (scoreIncreasing)
{
scoreCount += pointsPerSecond * Time.deltaTime;
}


scoreCount += pointsPerSecond * Time.deltaTime;

if(scoreCount > hiScoreCount)
{
hiScoreCount = scoreCount;
PlayerPrefs.SetFloat("HighScore", hiScoreCount);
}


ScoreText.text = "Score: " + Mathf.Round(scoreCount);
HiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);

}
}

Score Per Second Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

