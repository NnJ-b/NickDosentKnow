using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class PointTracker : MonoBehaviour {

    public List<PointAgent> agents;
    public float score = 10f;
    public float scorePlaceHolder =1f;
    private float scoreRounded;
    public TextMeshProUGUI scoreAbreviationMP;
    public TextMeshProUGUI scoreTextMP;

    private void Start()
    {
        scorePlaceHolder = 1f;
        if (agents == null)
        {
            agents = new List<PointAgent>();
        }

        InvokeRepeating("PointUpdate",0f,5f);
        
        //find canvas score abreviationMP and ScoreTextMP
    }

    void PointUpdate()
    {
        foreach (PointAgent agent in agents)
        {
            score = score + agent.pointPlyer;
        }
        scoreRounded = score/scorePlaceHolder; //Mathf.RoundToInt(score);
        scoreTextMP.SetText(scoreRounded.ToString("000.00"));
        if (score / scorePlaceHolder > 1000f)
        {
            scorePlaceHolder = scorePlaceHolder * 1000f;
            scoreRounded = score / scorePlaceHolder;
            scoreTextMP.SetText(scoreRounded.ToString("000.00"));
        }
        if (scorePlaceHolder==1f)
        {
            scoreAbreviationMP.SetText(" ");
        }
        if (scorePlaceHolder==1000f)
        {
            scoreAbreviationMP.SetText("k");
        }
        if (scorePlaceHolder==1000000f)
        {
            scoreAbreviationMP.SetText("Mill");
        }
        

    }

    public void SpendMoney(float pointPlyer)
    {
        if(score/scorePlaceHolder < scorePlaceHolder)
        {
            scorePlaceHolder = scorePlaceHolder / 1000f;
        }
        PointUpdate();
    }


}
