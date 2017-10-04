using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrConstruction : MonoBehaviour {
    public GameObject player;
    private float minDistance = 5f;
    public GameObject barrPre;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position,transform.position)>minDistance)
        {
            GameObject go = Instantiate(barrPre, transform.position, Quaternion.identity, null);
            Destroy(this.gameObject);
        }
    }

}
