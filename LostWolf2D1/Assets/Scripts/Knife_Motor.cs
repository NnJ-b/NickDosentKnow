using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Motor : MonoBehaviour {

    public GameObject Target;
    public float Speed;

    public bool Move = false;

    private void LateUpdate()
    {
        if(Move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        }
    }
}
