public class EnemyAISimple : MonoBehaviour
{
//Used to store a reference to the enemy AI's navigation agent component, which is used for pathfinding.
public NavMeshAgent Enemy;
public Transform Player;
private float nextActionTime = 0.5f;
public float period = 5.0f;


// Start is called before the first frame update
//Used to set the initial destination for the enemy AI to the player's position.
void Start()
{
Enemy.SetDestination(Player.position);
}

// Update is called once per frame
//Used to update the enemy's target location every period seconds.
void Update()
{
if (Time.time > nextActionTime)
{
nextActionTime = Time.time + period;
Enemy.SetDestination(Player.position);
}

}
}

Pause Menu Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

