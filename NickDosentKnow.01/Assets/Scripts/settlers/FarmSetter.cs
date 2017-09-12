using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmSetter : MonoBehaviour {

    public LayerMask ground;
	// Use this for initialization
	void Awake ()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
           if (hit.collider.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }

            Debug.Log(hit.collider.name);
            
            
        }

	}
}
