using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
