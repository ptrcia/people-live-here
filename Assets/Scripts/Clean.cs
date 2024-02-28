using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clean : Object
{
    [SerializeField]
    GameObject dirtyObject;
    [SerializeField]
    GameObject cleanPrefab;

    private void Awake()
    {
        dirtyObject = this.gameObject;
    }

    public void Cleaning()
    {
        Debug.Log("Cleaning...");
        Instantiate(cleanPrefab, this.transform);
        Destroy(dirtyObject);
    }
}
