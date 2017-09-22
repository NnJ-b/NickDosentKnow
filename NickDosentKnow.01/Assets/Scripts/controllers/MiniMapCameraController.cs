using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour {

    public float height = 10f;
    public Transform player;
    public Vector3 targetLocation;
    public float updateSpeed;
    public Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        targetLocation = new Vector3(player.position.x, height, player.position.z);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetLocation.x,updateSpeed),transform.position.y,Mathf.Lerp(transform.position.z,targetLocation.z,updateSpeed));
        //transform.rotation = new Quaternion(transform.rotation.x, mainCam.transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
}
