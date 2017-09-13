using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSpawnerController : MonoBehaviour
{
    public GameObject PlayerPre;
    public Terrain terrain;
    // Use this for initialization
    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Ground").GetComponent<Terrain>();
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                GameObject go = Instantiate(PlayerPre, transform.position, Quaternion.identity, null);
            }
            Destroy(gameObject);
        }

    }
}
