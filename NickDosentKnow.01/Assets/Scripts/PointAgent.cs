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
        pointPlyer = (tracker.score + .01f) * plyerPlyer;
        tracker.agents.Add(this);
        

    }


}
