using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class Player_Controller : MonoBehaviour {
    //References
    private Rigidbody rb;
    private Camera cam;
    public LayerMask moveMask;
    public LayerMask interactMask;
    PlayerMotor motor;

    //standard veriables
    private Vector3 clickPosistion;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, moveMask))
            {
               motor.MoveToPoint(hit.point);
            }
        }
    }
}
