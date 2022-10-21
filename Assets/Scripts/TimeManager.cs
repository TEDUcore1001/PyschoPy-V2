using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float timeDuration = 0f;

    public float timer;

    public float tempTimer;

    public float reactionTime;

    public bool counting;
    


    private void Start()
    {
        counting = false;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            timer += Time.deltaTime;
        }
    }

    public void ResetTimer()
    {
        timer = timeDuration;
    }

    public void StartTimer()
    {
        counting = true;
    }

    public void StopTimer()
    {
        counting = false;
        tempTimer = timer;

    }

    public float ReturnReactionTime()
    {
        reactionTime = timer;
        Debug.Log(reactionTime);
        return reactionTime;
        
    }
}
