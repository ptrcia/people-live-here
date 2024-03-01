using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : Object
{
    //This script changes the material of the object
    //from a dirty one to a clean one without the need to change the whole object.

    //No funciona :)

    [SerializeField]
    Material dirtyMaterial;
    [SerializeField]
    Material cleanMaterial;
    [SerializeField]
    Renderer rend;

    private void Awake()
    {
        dirtyMaterial = this.gameObject.GetComponent<Material>();
        rend = this.gameObject.GetComponent<Renderer>();
    }

    public void Cleaning()
    {
        Debug.Log("Cleaning...");
        IsObjectSelected(false);
        //dirtyMaterial = cleanMaterial;
        rend.material = cleanMaterial;
        Debug.Log(dirtyMaterial +"+ MATERIAL");

    }
}
