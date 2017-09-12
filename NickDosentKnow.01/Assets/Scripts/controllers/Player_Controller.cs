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
    public Transform selected;
    private Transform prevSelected;
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

           if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1)==false)
           {
                if (Physics.Raycast(ray, out hit, 500f))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        selected = null;
                        motor.MoveToPoint(hit.point);
                    }
                    if (hit.collider.tag == "Interactable")
                    {
                        Interactable focus = hit.collider.GetComponent<Interactable>();
                        selected = hit.collider.transform;
                        motor.MoveToSelected(focus);
                    }
                }
           }
        }
        //popup controll

        if (prevSelected != null && prevSelected != selected)
        {
            //prevSelected.Find("Canvas").gameObject.SetActive(false);
            prevSelected.GetComponentInChildren<Animator>().SetBool("isInteracting", false);
            prevSelected = null;
        }
        if (selected != null)
        {
            if(selected.tag == "Interactable" && Vector3.Distance(transform.position, selected.transform.position) < interactDist)
            {
                // selected.Find("Canvas").gameObject.SetActive(true);
                prevSelected.GetComponentInChildren<Animator>().SetBool("isInteracting", true);
            }
            prevSelected = selected;
        }
        if(selected == null && prevSelected != null)
        {
            //prevSelected.Find("Canvas").gameObject.SetActive(false);
            prevSelected.GetComponentInChildren<Animator>().SetBool("isInteracting",false);
            prevSelected = null;
        }
    }
}
