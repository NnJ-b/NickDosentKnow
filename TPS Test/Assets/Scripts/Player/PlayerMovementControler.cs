using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour {

    //references
    private Rigidbody rb;

    //Variables
    public float xMovement;
    public float zMovement;
    public Vector3 Movement;
    public float movementForce = 5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");
        Movement = new Vector3(-xMovement, 0, -zMovement) * movementForce * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Movement);
    }
}
