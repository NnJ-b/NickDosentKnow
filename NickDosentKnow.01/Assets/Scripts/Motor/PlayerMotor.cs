using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;
    public Player_Controller controller;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<Player_Controller>();
    }

    private void Update()
    {
        if (controller.selected !=null && controller.selected.tag == "Enemy")
        {
            MoveToEnemy(controller.selected.GetComponent<EnemyInt>());
            //look at enemy
            //Vector3 targetVector = new Vector3(transform.position.x, controller.selected.transform.position.y, transform.position.z);
            //transform.LookAt(targetVector);
        }
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
    public void MoveToBarracks(BarracksInt barr)
    {
        agent.stoppingDistance = barr.radius * .8f;
        agent.SetDestination(barr.transform.position);
    }
    public void MoveToEnemy(EnemyInt Enemy)
    {
        agent.stoppingDistance = Enemy.radius * .8f;
        agent.SetDestination(Enemy.transform.position);
    }
}
