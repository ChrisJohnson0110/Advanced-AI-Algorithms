using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// attached gameobject will follow it movement of the player
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    GameObject goPlayer;
    Vector3 CameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player"); //find player
        CameraOffset = transform.position - goPlayer.transform.position; //get offset from player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = goPlayer.transform.position + CameraOffset; //move with player
    }
}
