using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float timeDuration = 0f;

    private float timer;


    private void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }
}
