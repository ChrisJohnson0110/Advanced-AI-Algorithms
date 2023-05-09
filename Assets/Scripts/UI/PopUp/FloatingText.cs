using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCamera;
    Transform unit;
    Transform worldSpaceCanvas;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        worldSpaceCanvas = GameObject.FindGameObjectWithTag("WorldSpaceCanvas").transform;
        mainCamera = Camera.main.transform;
        unit = transform.parent;

        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position);
        transform.position = unit.position + offset;
    }
}
