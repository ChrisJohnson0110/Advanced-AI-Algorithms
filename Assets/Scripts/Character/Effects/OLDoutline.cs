using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDoutline : MonoBehaviour
{
    Material OutlineMaterial;

    Renderer OBJRenderer; //objects renderer
    Material[] RendererMaterials; //objects materials
    Material[] MaterialsWithOutline; //list of new materials

    GameObject CurrentlyHighlightedObject;

    // Start is called before the first frame update
    void Start()
    {
        OBJRenderer = GetComponent<Renderer>(); //objects renderer
        RendererMaterials = OBJRenderer.materials; //objects materials
        MaterialsWithOutline = new Material[RendererMaterials.Length + 1]; //list of new materials

        for (int i = 0; i < RendererMaterials.Length; i++) //put all obj materials into new mat array
        {
            MaterialsWithOutline[i] = RendererMaterials[i];
        }


        OutlineMaterial = Resources.Load<Material>("OutlineMaterial");
        MaterialsWithOutline[RendererMaterials.Length] = OutlineMaterial; //set last mat of new mat array to outline mat


        //OBJRenderer.materials = MaterialsWithOutline; //ouline renderer material
        OBJRenderer.materials = RendererMaterials; //default render materials
    }


    public void ApplyOutline()
    {
        OBJRenderer.materials = MaterialsWithOutline; //ouline renderer material

    }

    public void RemoveOutline()
    {
        OBJRenderer.materials = RendererMaterials; //ouline renderer material
    }

}
