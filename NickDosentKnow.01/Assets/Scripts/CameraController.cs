using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    public Vector3 offset;
    //Zoom Veriables
    private float zoom = 10f;
    public float zoomMax = 20f;
    public float zoomMin = 5f;
    public float zoomSpeed = 3f;
    //Yaw Veriables
    private float yawInput;
    public float yawSpeed = 100f;

    private void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);

        yawInput -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = player.position - offset * zoom;
        transform.LookAt(player);
        transform.RotateAround(player.position, Vector3.up, yawInput);
    }


}
