public class ScorePerSecond : MonoBehaviour
{

public Text scoreText;
public float scoreAmount;
public float pointIncreasedPerSecond;

// Start is called before the first frame update.
//The scoreAmount and pointIncreasedPerSecond are initialized to 0 and 1.
void Start()
{
scoreAmount = 0f;
pointIncreasedPerSecond = 1f;

}

//scoreAmount is increased by pointIncreasedPerSecond multiplied by the time that has passed since the last frame.
// Update is called once per frame
void Update()
{
scoreText.text = (int)scoreAmount + "Score";
scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
}
}

Timer Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

