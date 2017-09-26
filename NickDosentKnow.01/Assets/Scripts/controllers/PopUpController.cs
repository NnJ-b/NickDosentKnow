using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour {

    public GameObject goParentInt;
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
        goParentInt = transform.parent.parent.gameObject;
        anim = transform.parent.GetComponent<Animator>();

        farmButton.onClick.AddListener(instFarm);
        barraacksButton.onClick.AddListener(instBarr);
	}
	
	void instFarm ()
    {
        GameObject go = Instantiate(farmPre,new Vector3(goParentInt.transform.position.x, 9999f, goParentInt.transform.position.z), Quaternion.identity,null);
        Destroy(goParentInt);
    }

    void instBarr()
    {
        GameObject go = Instantiate(barrPre, new Vector3(goParentInt.transform.position.x, 9999f, goParentInt.transform.position.z), Quaternion.identity, null);
        Destroy(goParentInt);
    }

	void Update ()
    {
		if (goParentInt != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(cam,goParentInt.transform.position);
            rt.position = pos + offset; 
        }
	}
}
