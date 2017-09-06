using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour {

    public float height = 10f;
    public Transform player;
    public Vector3 targetLocation;
    public float updateSpeed;

    private void FixedUpdate()
    {
        targetLocation = new Vector3(player.position.x, height, player.position.z);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetLocation.x,updateSpeed),transform.position.y,Mathf.Lerp(transform.position.z,targetLocation.z,updateSpeed));
    }
}
