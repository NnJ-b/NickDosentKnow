using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Controller : MonoBehaviour {

    private Knife_Motor Motor;
    public GameObject DeadKnifePre;
    public GameObject Self;

	// Use this for initialization
	void Start ()
    {
        Motor = GetComponent<Knife_Motor>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Motor.Move = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = Instantiate(DeadKnifePre,new Vector3(Self.transform.position.x,Self.transform.position.y,1),Quaternion.identity, null);
        Motor.Move = false;
        transform.position = new Vector3(0, -4, 0);
    }
}
