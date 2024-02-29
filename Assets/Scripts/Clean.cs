using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        IsObjectSelected(false);
        Instantiate(cleanPrefab, transform.position, Quaternion.identity);
        Destroy(dirtyObject);
    }
}
