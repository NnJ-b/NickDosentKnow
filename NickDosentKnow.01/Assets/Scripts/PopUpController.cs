using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour {

    public GameObject goParent;
    public Vector2 offset;
    private RectTransform rt;
    private Camera cam;
    public Animator anim;
    public Button farmButton;
    public Button barraacksButton;
    public GameObject farmPre;
    public GameObject barrPre;
    

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        rt = GetComponent<RectTransform>();
        goParent = transform.parent.parent.gameObject;
        anim = transform.parent.GetComponent<Animator>();

        farmButton.onClick.AddListener(instFarm);
        barraacksButton.onClick.AddListener(instBarr);
	}
	
	void instFarm ()
    {
        //GameObject go = (GameObject)Instantiate(farmPre, transform.parent.parent.transform) as GameObject;
        //go.transform.parent = go.transform;
        Instantiate(farmPre,new Vector3(goParent.transform.position.x, 0.0001f, goParent.transform.position.z), Quaternion.Euler(0,0,0),null);
        Destroy(goParent);
    }

    void instBarr()
    {
       // GameObject go = (GameObject)Instantiate(barrPre,transform.parent.parent.transform);
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
