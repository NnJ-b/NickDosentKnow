using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracker : MonoBehaviour {

    public List<PointAgent> agents;
    public float score = 10f;

    private void Start()
    {
        if (agents == null)
        {
            agents = new List<PointAgent>();
        }

        InvokeRepeating("PointUpdate",0f,5f);
    }

    void PointUpdate()
    {
        foreach(PointAgent agent in agents)
        {
            score = score + agent.pointPlyer;
        }
        score = Mathf.RoundToInt(score);
    }


}
