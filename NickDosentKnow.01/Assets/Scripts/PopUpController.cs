using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour {

    public GameObject parent;
    public Vector2 offset;
    private RectTransform rt;
    private Camera cam;
    

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        rt = GetComponent<RectTransform>();
       // offset = RectTransformUtility.WorldToScreenPoint(cam, parent.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (parent != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(cam,parent.transform.position);
            rt.position = pos + offset; 
        }
	}
}
