public class Timer : MonoBehaviour
{
public Text timerText;
private float startTime;

// Start is called before the first frame update
//startTime is initialized to the current time using Time.time.
void Start()
{
startTime = Time.time;
}

// Update is called once per frame
//The minutes and seconds are concatenated into a string in the format "mm:ss" and assigned to the timerText.text variable, which updates the text displayed in the UI Text component.
void Update()
{
float t = Time.time - startTime;

string minutes = ((int) t / 60).ToString();
string seconds = (t % 60).ToString("f2");

timerText.text = minutes + ":" + seconds;
}
}

Exit Door Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

