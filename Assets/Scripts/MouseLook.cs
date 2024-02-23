using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook: MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] float bottomAngle; //limites de giro de la camara
    [SerializeField] float topAngle;
    [SerializeField] float yRotationSpeed;
    [SerializeField] float xCameraSpeed;

    private float desiredYRotation;
    private float desiredCameraXRotation;
    private float currentYRotation;
    private float currentCameraXRotation;
    private float roatationYVelocity;
    private float cameraXVelocity;

    private Camera myCamera;
    private float mouseX;
    private float mouseY;
    private void Awake()
    {
        myCamera = Camera.main;
        //bloquear cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MouseImputMovement();
    }

    void FixedUpdate()
    {
        ApplyRotation();
    }
    private void MouseImputMovement()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //el giro que quiero para que el player gire en torno al eje y

        desiredYRotation = desiredYRotation + (mouseX * mouseSensitivity);
        //eje X
        desiredCameraXRotation = desiredCameraXRotation - (mouseY * mouseSensitivity);
        //limite de los angulos
        desiredCameraXRotation = Mathf.Clamp(desiredCameraXRotation, bottomAngle, topAngle);
    }

    void ApplyRotation()
    {
        currentYRotation = Mathf.SmoothDamp(currentYRotation, desiredYRotation, ref roatationYVelocity,
            yRotationSpeed);
        currentCameraXRotation = Mathf.SmoothDamp(currentCameraXRotation, desiredCameraXRotation,
            ref cameraXVelocity, xCameraSpeed);

        //aplicamos la rotacion al gameobject
        //giro a lo largo del eje Y para la capsula
        transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
        //giro la camara a lo lago del eje x
        myCamera.transform.localRotation = Quaternion.Euler(currentCameraXRotation, 0, 0);
    }

}
