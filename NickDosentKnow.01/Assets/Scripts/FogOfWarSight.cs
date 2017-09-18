using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarSight : MonoBehaviour {

    public float sightRad = 5f;
    private LayerMask layerMask = -1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, sightRad, layerMask))
        {
            col.SendMessage("Seen", SendMessageOptions.DontRequireReceiver);
        }
	}
}
