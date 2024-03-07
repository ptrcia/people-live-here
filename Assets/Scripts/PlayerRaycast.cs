using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public TakeDrop takeDrop;
    public Clean clean;
    public Read read;
    public TidyUp tidyUp;
    public OnOff onOff;

    [SerializeField]
    LayerMask objectLayer;

    Ray ray;
    RaycastHit hit;
    float maxDistance;
    Transform myCamera;
    private void Awake()
    {
        takeDrop = GetComponent<TakeDrop>();
        clean = GetComponent<Clean>();
        read = GetComponent<Read>();
        tidyUp = GetComponent<TidyUp>();
        onOff = GetComponent<OnOff>();
    }
    private void Start()
    {
        myCamera = Camera.main.transform;
        maxDistance = 5f;
    }
    private void Update()
    {
        ray.origin = myCamera.position;
        ray.direction = myCamera.forward;
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        //TAKE DROP
        if(Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            takeDrop = hit.collider.GetComponent<TakeDrop>();
            if(takeDrop != null )
            {
                takeDrop.IsObjectSelected(true);
                //Debug.Log("Objecto Selecionado TAKE DROP");
            }
        }
        else
        {
            //decirle de alguna forma si no tengo bjeto selecionado ya o en la mano
            //que esta parte del takedrop se desactive
            if(takeDrop != null)
            {
                takeDrop.IsObjectSelected(false);
                takeDrop = null;
                //Debug.Log("Objeto no selecionado");
            }
        }

        //CLEAN
        if (Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            clean = hit.collider.GetComponent<Clean>();
            if (clean != null)
            {
                clean.IsObjectSelected(true);
                //Debug.Log("Objeto selecionado CLEAN");
            }
        }
        else
        {
            if (clean != null)
            {
                clean.IsObjectSelected(false);
                clean.isTheObjectCleaned();
                clean = null;
                //Debug.Log("Objeto no selecionado");
                //ccomprobar si tiene elcolor rojo o verde

            }
        }
        //READ
        if (Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            read = hit.collider.GetComponent<Read>();
            if (read != null)
            {
                read.IsObjectSelected(true);
                //Debug.Log("Objeto selecionado READ");
            }
        }
        else
        {
            if (read != null)
            {
                read.IsObjectSelected(false);
                read = null;
                //Debug.Log("Objeto no selecionado");
            }
        }

        //TIDYUP
        if (Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            tidyUp = hit.collider.GetComponent<TidyUp>();
            if (tidyUp != null)
            {
                tidyUp.IsObjectSelected(true);
                //Debug.Log("Objeto selecionado TIDY");
            }
        }
        else
        {
            if (tidyUp != null)
            {
                tidyUp.IsObjectSelected(false);
                tidyUp = null;
                //Debug.Log("Objeto no selecionado");
            }
        }
        //ON/OFF
        if (Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            onOff = hit.collider.GetComponent<OnOff>();
            if (onOff != null)
            {
                onOff.IsObjectSelected(true);
                //Debug.Log("Objeto selecionado ONOFF");
            }
        }
        else
        {
            if (onOff != null)
            {
                onOff.IsObjectSelected(false);
                onOff = null;
                //Debug.Log("Objeto no selecionado");
            }
        }

    }
}
