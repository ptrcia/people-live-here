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
        if (Input.GetMouseButton(0))
        {
            //TakeDrop:
            if (playerRaycast.takeDrop != null)
            {
                if (objectSelected != null)
                {
                    Debug.Log("Acción2: DROPING");

                    objectSelected.GetComponent<TakeDrop>().ActionTwo();
                    objectSelected = null;
                }
                else
                {
                    Debug.Log("Acción1: TAKING");
                    playerRaycast.takeDrop.ActionOne();
                    objectSelected = playerRaycast.takeDrop.gameObject;
                    //playerRaycast.takeDrop = null;
                }
            }
            //Clean:
            if (playerRaycast.clean != null)
            {
                if (objectSelected != null)
                {
                    objectSelected = null;
                }
                else
                {
                    Debug.Log("Acción1:CLEANING");
                    playerRaycast.clean.Cleaning();
                    objectSelected = playerRaycast.clean.gameObject;
                    playerRaycast.clean = null;
                }
            }

            //Read:
            if(playerRaycast.read != null)
            {
                if(objectSelected != null)
                {
                    Debug.Log("Acción2: STOP READING");
                    objectSelected.GetComponent<Read>().StopReading();
                    objectSelected = null;
                }
                else
                {
                    Debug.Log("Acción1:READING");
                    playerRaycast.read.Reading();
                    objectSelected = playerRaycast.read.gameObject;
                    playerRaycast.read = null;
                }
            }
            //TidyUp:
            if(playerRaycast.tidyUp != null)
            {
                if (objectSelected != null)
                {
                    objectSelected = null;
                }
                else
                {
                    Debug.Log("Acción1:TIDYING UP");
                    playerRaycast.tidyUp.TidyingUp();
                    objectSelected = playerRaycast.clean.gameObject;
                    playerRaycast.tidyUp = null;
                }
            }
            //On/Off:
            if(playerRaycast.onOff != null)
            {
                if(objectSelected != null)
                {
                    objectSelected = null;
                }
                else
                {
                    Debug.Log("Acción1:SWITCHING ON OFF");
                    playerRaycast.onOff.SwitchOnOff();
                    objectSelected = playerRaycast.onOff.gameObject;
                    //playerRaycast.onOff= null;
                }
            }

            /*
            //Take Drop

            if (Input.GetMouseButtonDown(0) && playerRaycast.takeDrop != null)
            {
                Debug.Log("Acción1: TAKING");
                playerRaycast.takeDrop.ActionOne();
                objectSelected = playerRaycast.takeDrop.gameObject;
                playerRaycast.takeDrop = null;
                //Debug.Log(objectSelected.name+  "");
            }
            else if (Input.GetMouseButtonDown(0) && objectSelected != null)
            {
                Debug.Log("Acción2: DROPING");

                objectSelected.GetComponent<TakeDrop>().ActionTwo();
                objectSelected = null;
            }        

            //Clean: 
            if(Input.GetMouseButtonDown(0) && playerRaycast.clean != null)
            {
                Debug.Log("Acción1:CLEANING");
                playerRaycast.clean.Cleaning();
                objectSelected = playerRaycast.clean.gameObject;
                playerRaycast.clean = null;
            }
            else if (Input.GetMouseButtonDown(0) && objectSelected != null)
            {
                objectSelected = null;
            }

            //Read:
            if (Input.GetMouseButtonDown(0) && playerRaycast.read != null)
            {
                Debug.Log("Acción1:READING");
                playerRaycast.read.Reading();
                objectSelected = playerRaycast.read.gameObject;
                playerRaycast.read = null;
            }
            else if (Input.GetMouseButtonDown(0) && objectSelected != null)
            {
                objectSelected = null;
            }
            //TidyUp:
            if (Input.GetMouseButtonDown(0) && playerRaycast.tidyUp != null)
            {
                Debug.Log("Acción1:TIDYING UP");
                playerRaycast.tidyUp.TidyingUp();
                objectSelected = playerRaycast.clean.gameObject;
                playerRaycast.tidyUp = null;
            }
            else if (Input.GetMouseButtonDown(0) && objectSelected != null)
            {
                objectSelected = null;
            }
            //On/Off:
            if (Input.GetMouseButtonDown(0) && playerRaycast.onOff != null)
            {
                Debug.Log("Acción1:SWITCHING ON OFF");
                playerRaycast.onOff.SwitchOnOff();
                //objectSelected = playerRaycast.onOff.gameObject;
                //playerRaycast.onOff= null;
            }
            /*else if (Input.GetMouseButtonDown(0) && objectSelected != null)
            {
                objectSelected = null;
            }*/

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
