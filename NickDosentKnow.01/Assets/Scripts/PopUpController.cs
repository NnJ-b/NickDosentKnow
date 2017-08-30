using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour {

    public GameObject goParent;
    public Vector2 offset;
    private RectTransform rt;
    private Camera cam;
    public Animator anim;
    

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        rt = GetComponent<RectTransform>();
        goParent = transform.parent.parent.gameObject;
        anim = transform.parent.GetComponent<Animator>();
	}
	
	
	void Update ()
    {
		if (goParent != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(cam,goParent.transform.position);
            rt.position = pos + offset; 
        }
	}
}
