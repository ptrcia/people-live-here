using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TakeDrop : Object
{
    [SerializeField]
    float impulse;
    private void Awake()
    {
        col = GetComponent<Collider>();
    }
    public void ActionOne()
    {
        Take();
    }
    public void ActionTwo()
    {
        Drop();
    }

    void Take()
    {
        IsObjectSelected(false);
        rb.isKinematic = true;
        transform.SetParent(Camera.main.transform.GetChild(0).transform); //CUIDAO
        transform.localPosition = Vector3.zero;
        transform.localRotation = new Quaternion();
        col.enabled = false;
    }
    void Drop()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        rb.AddForce(transform.forward * impulse);
        col.enabled = true;
    }
}
