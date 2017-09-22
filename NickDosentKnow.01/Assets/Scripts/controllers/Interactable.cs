using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 5f;
    public float heightAdder;
    private NodeSpawner NS;
    public float spacing = 10f;
    private GameObject[] gos;
    public float dist;

    void Awake()
    {
        NS = GameObject.FindGameObjectWithTag("NS").GetComponent<NodeSpawner>();
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            if(hit.collider.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + heightAdder, transform.position.z);
            }
            else
            {
                NS.spawnNode();
                Debug.Log("newSpot");
                Destroy(this);
            }
        }
        gos = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject go in gos)
        {
            dist = Vector3.Distance(transform.position, go.transform.position);
            if (dist < spacing)
            {
                //NS.spawnNode();
                Debug.Log("Toclose");
            }
            //Destroy(this.gameObject);
        }

    }




}
