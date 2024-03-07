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

    public bool isCleaned;
    //interfaz aqui en algun lado :)


    private void Awake()
    {
        isCleaned = false;
        //dirtyMaterial = this.gameObject.GetComponent<Material>();
    }

    public void Cleaning()
    {
        Debug.Log("Cleaning...");
        IsObjectSelected(false);
        //dirtyMaterial = cleanMaterial;
        rend.material = cleanMaterial;
        Debug.Log(dirtyMaterial +"+ MATERIAL");
        isCleaned = true;
    }
    public void isTheObjectCleaned()
    {
        if (isCleaned)
        {
            rend.material = cleanMaterial;
        }
        else
        {
            rend.material = dirtyMaterial;
        }
    }
}
