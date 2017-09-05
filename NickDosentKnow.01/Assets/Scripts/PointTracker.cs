using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class PointTracker : MonoBehaviour {

    public List<PointAgent> agents;
    public float score = 10f;
    private float scoreRounded;
    public TextMeshProUGUI scoreTextMP;

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
        scoreRounded = Mathf.RoundToInt(score);
        scoreTextMP.SetText(scoreRounded.ToString());
         
    }


}
