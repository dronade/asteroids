using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    public bool isRewinding = false;
    List<PointInTime> points;


    // Start is called before the first frame update
    void Start()
    {
        points = new List<PointInTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();

        } else
        {
            Record();
        }
    }
    public void Rewind()
    {
        if (points.Count > 0)
        {

            PointInTime pit = points[0];
            transform.position = pit.position;
            transform.rotation = pit.rotation;
            points.RemoveAt(0);
        } else
        {
            StopRewind ();
        }
        
    }

    public void Record()
    {
        PointInTime pit = new PointInTime(transform.position, transform.rotation);
        points.Insert(0, pit);
    }

    public void StartRewind()
    {
        isRewinding=true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
