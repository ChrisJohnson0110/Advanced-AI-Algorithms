using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// destroy attached gameobject after 0.5s
/// </summary>
public class HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
