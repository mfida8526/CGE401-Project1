using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Mimi Davis
* Project1
* Camera follows player as they move around on the map
*/
public class CamFollowPlayer : MonoBehaviour
{
    //Set this reference to the player in the inspector
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            transform.position.z);
    }
}
