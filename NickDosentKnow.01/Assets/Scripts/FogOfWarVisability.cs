using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarVisability : MonoBehaviour {

    private bool visable = false;
    private Renderer renderer;

	// Use this for initialization
	void Start ()
    {
        renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(visable)
        {
            //make visable
            renderer.enabled = true;
        }
        else
        {
            //make invisable
            renderer.enabled = false;
            
        }
        visable = false;
	}

    void Seen ()
    {
        visable = true;
    }
}
