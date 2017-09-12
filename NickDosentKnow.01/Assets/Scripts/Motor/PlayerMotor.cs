using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.stoppingDistance = 0f;
        agent.SetDestination(point);
        Debug.Log(point);
    }

    public void MoveToSelected(Interactable focus)
    {
        agent.stoppingDistance = focus.radius * .8f;
        agent.SetDestination(focus.transform.position);
        
    }
}
