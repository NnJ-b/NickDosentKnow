using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 10f;
    private float horizontal;
    private float vertical;
    private Vector2 movement;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal")*speed;
        vertical = Input.GetAxis("Vertical")*speed;
    }

    private void FixedUpdate()
    {
        movement = new Vector2(horizontal, vertical);
        Debug.Log(movement);
    }

}
