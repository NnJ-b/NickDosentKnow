using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Transform player;
    public bool isChassing;
    public bool isFighting;
    public bool isRoming;
    public float maxDistance;
    public float findDistance;
    public float fightDistance;
    public LayerMask ground;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            if (hit.collider.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                //  transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }
        }
    }

    private void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        if(playerDistance>maxDistance)
        {
            Debug.Log("destroy self and respawn elseware");
            isRoming = true;
            isFighting = false;
            isChassing = false;
        }
        else if(playerDistance>findDistance)
        {
            Debug.Log("roam");
            isRoming = true;
            isFighting = false;
            isChassing = false;
        }
        else if(playerDistance<findDistance && playerDistance>fightDistance)
        {
            Debug.Log("Chase");
            isRoming = false;
            isFighting = false;
            isChassing = true;
        }
        else if(playerDistance < fightDistance)
        {
            Debug.Log("Fight");
            isRoming = false;
            isFighting = true;
            isChassing = false;
        }
        
    }
}
