using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float accelerationSpeed;
    [SerializeField] float deaccelerationSpeed;
    [SerializeField] int maxSpeed;

    [Header("Raycast - Ground")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float rayLength;

    [Header("Crouch")]
    public float newHeight;
    public float newRadius;
    float colliderHeight, colliderRadius;    
    public CapsuleCollider playerCollider;
    bool isCrouched;



    Rigidbody rb;
    float vertical, horizontal;
    Vector3 slowdown;
    bool isGrounded;
    //bool jumpPressed;
    Ray ray;
    RaycastHit hit;

    Vector2 horizontalMovement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //playerCollider = transform.GetChild(1).GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        colliderHeight = playerCollider.height;
        colliderRadius = playerCollider.radius;
    }
    private void Update()
    {
        InputPlayer();

        if(!isCrouched && Input.GetMouseButtonDown(1)) //mantener pulsado
        {
            Crouch();
        }
        else if(isCrouched && Input.GetMouseButtonDown(1))
        {
            StandUp();
        }

    }

    private void FixedUpdate()
    {
        IsGrounded();
        Movement();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        //controlar que no supere la velocidad maxima
        //aqui me guyardo a que velocidad va el rigidbody en ña x y la z
        horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        if (horizontalMovement.magnitude > maxSpeed)
        {
            //Limita la velocdad de movimiento
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement = horizontalMovement * maxSpeed;
        }
        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, horizontalMovement.y);

        if (isGrounded)
        {
            rb.AddRelativeForce(horizontal * accelerationSpeed * Time.deltaTime, 0,
                vertical * accelerationSpeed * Time.deltaTime);
        }
        else
        {
            //disminuimos la fuerza ya que estasen el aire
            rb.AddRelativeForce(horizontal * accelerationSpeed / 2 * Time.deltaTime, 0,
                vertical * accelerationSpeed / 2 * Time.deltaTime);
        }

        //desaceleramos
        if (isGrounded)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(0, rb.velocity.y, 0),
                ref slowdown, deaccelerationSpeed);
        }
    }
    void IsGrounded()
    {
        ray.origin = transform.position;
        ray.direction = -transform.up;

        if (Physics.Raycast(ray, out hit, rayLength, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        //Debug.Log("" + isGrounded);
    }
    void Crouch()
    {
        isCrouched = true;
        playerCollider.height = newHeight;
        playerCollider.radius = newRadius;
        Debug.Log("Entro a Crouch");


    }
    void StandUp()
    {
        isCrouched = false;
        playerCollider.height = colliderHeight;
        playerCollider.radius = colliderRadius;
        Debug.Log("Entro a StandUP");
    }
}
