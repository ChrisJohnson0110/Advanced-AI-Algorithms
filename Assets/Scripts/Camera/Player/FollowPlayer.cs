using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject goPlayer;
    Vector3 CameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        CameraOffset = transform.position - goPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = goPlayer.transform.position + CameraOffset;
    }
}
