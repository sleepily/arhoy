using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTracker : MonoBehaviour
{
    GameObject tracker;

    private void Start()
    {
        tracker = GetComponentInParent<Page>().Tracker;
    }

    void Update()
    {
        this.transform.position = tracker.transform.position;
        this.transform.rotation = tracker.transform.rotation;
    }
}
