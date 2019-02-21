using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //References
    private GameObject player;
    private Vector3 targetPosition;

    //Variables
    public Vector3 offset = new Vector3(0, 5, 5);
    public float lerpSpeed = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + offset; 
    }

    private void FixedUpdate()
    {
        targetPosition = new Vector3(Mathf.Lerp(transform.position.x, player.transform.position.x, lerpSpeed),(Mathf.Lerp(transform.position.y, player.transform.position.y, lerpSpeed)), (Mathf.Lerp(transform.position.z,player.transform.position.z,lerpSpeed)));
        transform.position = targetPosition + offset;
        transform.LookAt(player.transform.position);
    }
}
