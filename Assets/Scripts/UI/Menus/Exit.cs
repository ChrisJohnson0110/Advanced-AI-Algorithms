using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitApp()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
