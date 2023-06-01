using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// exit game button functionality
    /// </summary>
    public void ExitApp()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
