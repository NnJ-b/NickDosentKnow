using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour {

    public GameObject ground;
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

    public int numberOfSpawns; 

    private void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");

        groundX = ground.GetComponent<Terrain>().terrainData.size.x;
        groundY = ground.GetComponent<Terrain>().terrainData.size.y;
        groundZ = ground.GetComponent<Terrain>().terrainData.size.z;

        // groundX = ground.GetComponent<Renderer>().bounds.size.x;
        // groundY = ground.GetComponent<Renderer>().bounds.size.y;
        // groundZ = ground.GetComponent<Renderer>().bounds.size.z;

        while (numberOfSpawns>0)
        {
            spawnNode();
            numberOfSpawns--;
        }
    }

    public void spawnNode ()
    {
        spawnPoint = new Vector3(Random.Range((groundX/-2f)*.8f,(groundX/2f) *.8f), 9999f, Random.Range((groundZ/-2f)*.8f,(groundZ/2) *.8f));
        Instantiate(nodePre,spawnPoint, Quaternion.Euler(0, 0, 0), null);
    }
}
