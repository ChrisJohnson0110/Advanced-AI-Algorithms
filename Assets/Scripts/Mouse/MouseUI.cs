using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseUI : MonoBehaviour, IPointerClickHandler
{
    SkillTreeSelectionMenu SkillTreeSelectionMenuRef;

    [SerializeField] GameObject goRedSkillTree;
    [SerializeField] GameObject goBlueSkillTree;
    [SerializeField] GameObject goPurpleSkillTree;
    [SerializeField] GameObject goGreenSkillTree;
    [SerializeField] GameObject goYellowSkillTree;

    private void Start()
    {
        SkillTreeSelectionMenuRef = GetComponent<SkillTreeSelectionMenu>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goRedSkillTree.SetActive(false);
            goBlueSkillTree.SetActive(false);
            goPurpleSkillTree.SetActive(false);
            goGreenSkillTree.SetActive(false);
            goYellowSkillTree.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "RedCell")
        {
            goRedSkillTree.SetActive(true);
        }
        else if (eventData.pointerPressRaycast.gameObject.name == "BlueCell")
        {
            goBlueSkillTree.SetActive(true);
        }
        else if (eventData.pointerPressRaycast.gameObject.name == "PurpleCell")
        {
            goPurpleSkillTree.SetActive(true);
        }
        else if (eventData.pointerPressRaycast.gameObject.name == "GreenCell")
        {
            goGreenSkillTree.SetActive(true);
        }
        else if (eventData.pointerPressRaycast.gameObject.name == "YellowCell")
        {
            goYellowSkillTree.SetActive(true);
        }
        else
        {
            return;
        }
        SkillTreeSelectionMenuRef.UpdateSkillDisplay(); //hide skill tree selection menu
    }

}
