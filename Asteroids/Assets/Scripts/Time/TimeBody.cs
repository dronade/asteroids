using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    List<PointInTime> points;
    public int rewindNumber = 0;
    private IAchievementService achievementService;

    void Start()
    {
        points = new List<PointInTime>();
        achievementService = ServiceLocator.Current.Get<IAchievementService>();
    }

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

        if (rewindNumber >= 3)
        {
            achievementService.UnlockAchievement(2);
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    public void Rewind()
    {
        if (points.Count > 0)
        {
            rewindNumber++;
            PointInTime pit = points[0];
            transform.position = pit.position;
            transform.rotation = pit.rotation;
            points.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    public void Record()
    {
        PointInTime pit = new PointInTime(transform.position, transform.rotation);
        points.Insert(0, pit);
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
