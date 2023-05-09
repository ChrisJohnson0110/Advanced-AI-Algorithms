using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeSelectionMenu : MonoBehaviour
{
    [SerializeField] GameObject goSkillTreeSelectionMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateSkillDisplay();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goSkillTreeSelectionMenu.SetActive(false);
        }
    }

    public void UpdateSkillDisplay()
    {
        goSkillTreeSelectionMenu.SetActive(!goSkillTreeSelectionMenu.activeSelf);
    }

}
