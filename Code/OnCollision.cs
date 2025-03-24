public class OnCollision : MonoBehaviour
{

//Detects collisions between the attached object and the player, and reloads the current scene if a collision occurs.
void OnTriggerEnter(Collider col)
{


if(col.CompareTag("Player"))
{
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}
}



Enemy AI Simple Class Code

//Simple implementation of an enemy AI script in Unity using the NavMeshAgent component

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

