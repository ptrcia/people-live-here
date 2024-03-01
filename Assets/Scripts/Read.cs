using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : Object
{
    //En proceso

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

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        originalPosition = transform;
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


    }
     public void StopReading()
    {
        transform.SetParent(null);
        transform.position = originalPosition.position; //¿?
        col.enabled = true;
        EnableMovement();

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
