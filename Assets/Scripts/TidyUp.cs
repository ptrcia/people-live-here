using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyUp : Object
{
    public void TidyingUp()
    {
        Debug.Log("TidyngUp...");
        Destroy(gameObject);
    }
}
