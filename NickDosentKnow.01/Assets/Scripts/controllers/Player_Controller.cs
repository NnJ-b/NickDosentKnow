using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class Player_Controller : MonoBehaviour {
    //References
    private Rigidbody rb;
    private Camera cam;
    public LayerMask moveMask;
    public LayerMask interactMask;
    PlayerMotor motor;
    public GameObject selected;
    private GameObject prevSelected;
    public LayerMask ground;

    //standard veriables
    private Vector3 clickPosistion;
    public float interactDist;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    void Awake()
    {
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
    private void Update()
    {
        //Movement
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1) == false)
           {
                if (Physics.Raycast(ray, out hit, 500f))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        selected = null;
                        motor.MoveToPoint(hit.point);
                        if(prevSelected != null)
                        {
                            PopDown();
                        }
                    }
                    if (hit.collider.tag == "Interactable")
                    {
                        Interactable focus = hit.collider.GetComponent<Interactable>();
                        selected = hit.collider.gameObject;
                        motor.MoveToSelected(focus);
                        if(prevSelected != null)
                        {
                            PopDown();
                        }
                        Debug.Log(hit.collider.name);
                    }
                    if (hit.collider.tag == "Enemy")
                    {
                        EnemyInt enemy = hit.collider.GetComponent<EnemyInt>();
                        selected = hit.collider.gameObject;
                        motor.MoveToEnemy(enemy);
                        if (prevSelected != null)
                        {
                            PopDown();
                        }

                    }
                }
           }
        }
        if(selected != null && selected.tag == "Interactable" && selected !=prevSelected)
        {
            PopUpCont(selected);
        }
        

    }
    void PopUpCont(GameObject Selected)
    {
        if(Vector3.Distance(transform.position,Selected.transform.position) < 5f)
        {
            selected.GetComponentInChildren<Animator>().SetBool("IsSelected", true);
            prevSelected = selected;
        }
    }
    void PopDown()
    {
        prevSelected.GetComponentInChildren<Animator>().SetBool("IsSelected", false);
        prevSelected = null;
    }
}
