using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public GameObject PlayerPre;
    // Use this for initialization
    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                GameObject go = Instantiate(PlayerPre, transform.position, Quaternion.identity, null);
                Destroy(this);
            }
        }

    }
}
