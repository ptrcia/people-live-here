using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyUp : Object
{
    //This script changes the object to an organized version of the same object.

    [SerializeField] GameObject unTidyObject;
    [SerializeField] GameObject tidyObject;

    private void Awake()
    {
        unTidyObject = this.gameObject;
    }
    public void TidyingUp()
    {
        Debug.Log("TidyngUp...");
        
        IsObjectSelected(false);
        Instantiate(tidyObject, transform.position, Quaternion.identity);
        Destroy(unTidyObject);
    }
}
