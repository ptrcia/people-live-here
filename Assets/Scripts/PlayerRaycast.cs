using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public TakeDrop takeDrop;

    [SerializeField]
    LayerMask objectLayer;

    Ray ray;
    RaycastHit hit;
    float maxDistance;
    Transform myCamera;
    private void Start()
    {
        myCamera = Camera.main.transform;
        maxDistance = 5f;
    }
    private void Update()
    {
        ray.origin = myCamera.position;
        ray.direction = myCamera.forward;

        if(Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            takeDrop = hit.collider.GetComponent<TakeDrop>();
            if(takeDrop != null )
            {
                takeDrop.IsObjectSelected(true);
                Debug.Log("Objecto Selecionado");
            }
        }
        else
        {
            if(takeDrop != null)
            {
                takeDrop.IsObjectSelected(false);
                takeDrop = null;
                Debug.Log("Objeto no selecionado");
            }
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
    }
}
