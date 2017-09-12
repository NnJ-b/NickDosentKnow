using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;// = GameObject.FindGameObjectWithTag("Player").transform;

    public Vector3 offset;
    //Zoom Veriables
    private float zoom = 10f;
    public float zoomMax = 20f;
    public float zoomMin = 5f;
    public float zoomSpeed = 3f;
    //Yaw Veriables
    private float yawInput;
    public float yawSpeed = 100f;
  
    //Pitch Variables
    private float pitchInput;
    public float pitchSpeed = 100f;
    public float pitchMin;
    public float pitchMax;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);

        yawInput += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        pitchInput += Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        pitchInput = Mathf.Clamp(pitchInput, pitchMin, pitchMax);
        
    }

    private void LateUpdate()
    {
        transform.position = player.position - offset * zoom;
        Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        transform.LookAt(point);
        transform.RotateAround(player.position, Vector3.up, yawInput);
        Vector3 localX = transform.TransformDirection(Vector3.right);
        transform.RotateAround(player.position, localX, pitchInput);
    }


}
