using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    private GameObject player;
    public bool isChassing;
    public bool isFighting;
    public bool isRoming;
    public float maxDistance;
    public float findDistance;
    public float fightDistance;
    private float stopingdistance;
    public LayerMask ground;
    public NavMeshAgent agent;
    public float Health;
    private float maxHealth;
    private float originalSpeed;
    private float minSpeed = 5f;
    private float maxSpeed = 1.5f;
    private Transform scale;

    // Use this for initialization
    void Start()
    {
        stopingdistance = 3f;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        //set helth based on plat=yer points
        Health = 100f;
        maxHealth = Health;
        //set speed based on Helath


        InvokeRepeating("Hurt", 0f, 5f); // temporary will be replaced by anim
    }

    private void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if(playerDistance>maxDistance)
        {
            NewLocation();
        }
        else if(playerDistance>findDistance)
        {
            Wander();
        }
        else if(playerDistance<findDistance && playerDistance>fightDistance)
        {
            Chase();
        }
        else if(playerDistance < fightDistance)
        {
            Fight();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Hurt();
        }
    }

    void NewLocation()
    {
        Debug.Log("destroy self and respawn elseware");
        isRoming = true;
        isFighting = false;
        isChassing = false;
    }
    void Wander()
    {
        Debug.Log("roam");
        isRoming = true;
        isFighting = false;
        isChassing = false;
    }
    void Chase()
    {
        Debug.Log("Chase");
        agent.stoppingDistance = 3f;
        agent.SetDestination(player.transform.position);
        isRoming = false;
        isFighting = false;
        isChassing = true;
    }
    void Fight()
    {
        Debug.Log("Fight");
        isRoming = false;
        isFighting = true;
        isChassing = false;
    }
    void Hurt() //add float to reference by player anim
    {
        if (player.GetComponent<Player_Controller>().selected == this.transform)
        {
            Health = Health - 5f; //replace 5f with anim reference float
            Debug.Log(Health);
            //setspeedbased on helth
            agent.speed = agent.speed - 50f;
            agent.speed = agent.speed * .3f;
            agent.speed = Mathf.Pow(agent.speed, 1 / 3);
            agent.speed = agent.speed * -1.1f;
            agent.speed = agent.speed + 4.4f;
            Debug.Log(agent.speed);
                                    //agent.speed = (-1.1 * ((.3f * (Health - 50f)) ^ (1f / 3f)) + 4.4f);

            //set size based on health


            //clamp speed to not exceed min and max
            agent.speed = Mathf.Clamp(agent.speed, minSpeed, maxSpeed);

        }
    }
}
