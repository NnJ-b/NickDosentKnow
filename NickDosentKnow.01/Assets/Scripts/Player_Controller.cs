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

    //standard veriables
    private Vector3 clickPosistion;
    public float interactDist;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1)==false)
           {
                if (Physics.Raycast(ray, out hit, 100f))
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
        if (prevSelected != null && prevSelected != selected)
        {
            prevSelected.Find("Canvas").gameObject.SetActive(false);
            prevSelected = null;
        }
        if (selected != null)
        {
            if(selected.tag == "Interactable" && Vector3.Distance(transform.position, selected.transform.position) < interactDist)
            {
                selected.Find("Canvas").gameObject.SetActive(true);
            }
            prevSelected = selected;
        }
        if(selected == null && prevSelected != null)
        {
            prevSelected.Find("Canvas").gameObject.SetActive(false);
            prevSelected = null;
        }
    }
}
