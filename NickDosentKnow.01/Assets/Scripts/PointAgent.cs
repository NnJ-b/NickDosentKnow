using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAgent : MonoBehaviour {

    PointTracker tracker;
    public float pointPlyer;
    public float plyerPlyer;

    private void Start()
    {
        tracker = FindObjectOfType<PointTracker>();
        pointPlyer = ((tracker.score + .00001f) * plyerPlyer)/tracker.scorePlaceHolder;
        tracker.agents.Add(this);
        

    }


}
