using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour {

    private GameObject ground;
    public GameObject nodePre;

    private float groundX;
    private float xMax;
    private float xMin;
    private float groundY;
    private float yMax;
    private float yMin;
    private float groundZ;
    private float zMax;
    private float zMin;

    private Vector3 spawnPoint;

    private void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");

        groundX = ground.GetComponent<Renderer>().bounds.size.x;
        groundY = ground.GetComponent<Renderer>().bounds.size.y;
        groundZ = ground.GetComponent<Renderer>().bounds.size.z;

        InvokeRepeating("spawnNode",0.0f,1f);
    }

    void spawnNode ()
    {
        spawnPoint = new Vector3(Random.Range(0,groundX/2f *.8f),1, Random.Range(0,groundZ/2 *.8f));
        Debug.Log(spawnPoint);
        Instantiate(nodePre,spawnPoint, Quaternion.Euler(0, 0, 0), null);
    }
}
