﻿using UnityEngine;

public class EnemyInt : MonoBehaviour {

    public float radius = 5f;
    public float heightAdder;

    void Awake()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + heightAdder, transform.position.z);
            }
        }
        
    }




}
