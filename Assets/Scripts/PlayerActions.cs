using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] float zObject; //el objeto lo vamos amover un pojo en el ejez delate de la camara
    [SerializeField] Transform posObject; //el ganeobject vacio que va como hijo de la camara

    private GameObject objectSelected;

    private PlayerRaycast playerRaycast;
    private MouseLook mouseLook;

    private Vector3 posObjectInit; //posicion inicial
    private Vector3 posObjectToRotate; //posicion a la que hay que hayq ue colocar el objeto para rrotarlo
    private float angleX;
    private float angleY;

    private void Awake()
    {
        playerRaycast = GetComponent<PlayerRaycast>();
        mouseLook = GetComponent<MouseLook>();
    }
    private void Start()
    {
        posObjectInit = posObject.localPosition;
        posObjectToRotate = new Vector3(posObject.localPosition.x, posObject.localPosition.y,
            posObject.localPosition.z + zObject);
    }

    private void Update()
    {
        ActionPlayer();
        RotateObject();
    }
    void ActionPlayer()
    {
        //si pulso y apunto a un objeto interactuable:
        if (Input.GetMouseButtonDown(0) && playerRaycast.takeDrop != null)
        {
            Debug.Log("Acción1");
            playerRaycast.takeDrop.ActionOne();
            objectSelected = playerRaycast.takeDrop.gameObject;
            playerRaycast.takeDrop = null;
        }
        else if (Input.GetMouseButtonDown(0) && objectSelected != null)
        {
            Debug.Log("Acción2");

            objectSelected.GetComponent<TakeDrop>().ActionTwo();
            objectSelected = null;
        }
    }
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.E) && objectSelected != null)
        {
            mouseLook.enabled = false;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            angleX += mouseY * mouseSensitivity;
            angleY += mouseX * mouseSensitivity;

            posObject.localPosition = posObjectToRotate;
            objectSelected.transform.rotation = Quaternion.Euler(angleX, angleY, 0);
        }
        else
        {
            posObject.localPosition = posObjectInit;
            mouseLook.enabled = true;
        }
    }
}
