using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : Object
{
    //En proceso
    //quiero hacer que se active la luz cuando lo cojas
    //pero que haya algun tipo de render en el layer para que no afecte esa luz a nada mas


    //Theoretically this script will make the object
    //come close enough to be readable and,
    //when released,
    //it will be placed exactly where it was and
    //in the process the character cannot move.

    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform originalPosition;
    [SerializeField]
    Light readLight;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        originalPosition = transform;
        readLight = gameObject.GetComponentInChildren<Light>();
    }
    public void Reading()
    {
        Debug.Log("Reading...");

        IsObjectSelected(false);
        rb.isKinematic = true;
        transform.SetParent(Camera.main.transform.GetChild(1).transform); //CUIDAO
        transform.localPosition = Vector3.zero;
        transform.localRotation = new Quaternion();
        col.enabled = false;
        DisableMovement();
         readLight.enabled = true;


    }
     public void StopReading()
    {
        transform.SetParent(null);
        transform.position = originalPosition.position; //¿?
        col.enabled = true;
        EnableMovement();
        readLight.enabled = false;

    }

    void DisableMovement()
    {
        playerMovement.enabled = false; //no funciona 
    }
    void EnableMovement()
    {
        playerMovement.enabled = true;
    }
}
