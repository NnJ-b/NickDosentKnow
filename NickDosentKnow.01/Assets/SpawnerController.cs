using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject ground;
    private float groundX;
    private float groundY;
    private float groundZ;
    private float spawnCount;

    void Start ()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");

        groundX = ground.GetComponent<Renderer>().bounds.size.x;
        groundY = ground.GetComponent<Renderer>().bounds.size.y;
        groundZ = ground.GetComponent<Renderer>().bounds.size.z;

        

    }

}
