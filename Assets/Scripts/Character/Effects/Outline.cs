using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{

    Material OutlineMaterial;

    GameObject CurrentlyHighlightedObject;

    Renderer OBJRenderer; //objects renderer
    Material[] RendererMaterials; //objects materials
    Material[] MaterialsWithOutline; //list of new materials


    

    // Start is called before the first frame update
    void Start()
    {
        OutlineMaterial = Resources.Load<Material>("OutlineMaterial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetMaterials(GameObject a_goObjectToHighlight)
    {
        OBJRenderer = a_goObjectToHighlight.GetComponent<Renderer>(); //get the renderer of object
        RendererMaterials = OBJRenderer.materials; // save the objets materials
        MaterialsWithOutline = new Material[RendererMaterials.Length + 1]; //init new array of previous materials plus outline material

        for (int i = 0; i < RendererMaterials.Length; i++) //fill array with current materials all but last
        {
            MaterialsWithOutline[i] = RendererMaterials[i];
        }
        MaterialsWithOutline[RendererMaterials.Length] = OutlineMaterial; //set last mat to outline mat

        //OBJRenderer.materials = MaterialsWithOutline; //ouline renderer material
        //OBJRenderer.materials = RendererMaterials; //default render materials
    }

    public void ApplyOutline(GameObject a_goObjectToHighlight)
    {
        if (a_goObjectToHighlight != CurrentlyHighlightedObject)
        {
            if (OBJRenderer != null)
            {
                OBJRenderer.materials = RendererMaterials; //remove outline
            }

            GetMaterials(a_goObjectToHighlight); //get new obj properties
            CurrentlyHighlightedObject = a_goObjectToHighlight; //set currently highlighted obj
            OBJRenderer.materials = MaterialsWithOutline; //outline new obj
        }
    }

    public void RemoveOutline()
    {
        if (CurrentlyHighlightedObject != null) // if an object is highlighted
        {
            if (OBJRenderer != null) //if there is a stored renderer
            {
                OBJRenderer.materials = RendererMaterials; //remove outline
                CurrentlyHighlightedObject = null; //remove highlighted ref
            }
        }
    }

}
