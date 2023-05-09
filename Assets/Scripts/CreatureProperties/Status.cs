using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public GameObject StatusDisplay;

    Player PlayerReference;
    public List<Damage.type> Effects;

    private void Start()
    {
        PlayerReference = FindObjectOfType<Player>();
        UpdateDisplay();
    }
    

    public void Apply(Damage.type a_DamageType)
    {
        Effects.Add(a_DamageType);
        UpdateDisplay();
    }

    /// <summary>
    /// update the status display
    /// </summary>
    private void UpdateDisplay()
    {
        if (StatusDisplay != null)
        {
            //string DisplayStatusString = "";
            //foreach (Damage.type d in Effects)
            //{
            //    if (DisplayStatusString.Contains(d.ToString()) == false)
            //    {
            //        if (DisplayStatusString != "")
            //        {
            //            DisplayStatusString += " + ";
            //        }
            //        DisplayStatusString += d.ToString();
            //    }
            //}
            //StatusDisplay.GetComponent<Text>().text = DisplayStatusString;
            //if (Effects[0] != null)
            //{
            //    StatusDisplay.GetComponent<Text>().text = Effects[0].ToString();
            //}

        }

    }

}
