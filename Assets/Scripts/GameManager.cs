using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("Time Manager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckReaction();
    }

    private void CheckReaction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeManager.StopTimer();
            timeManager.ReturnReactionTime();
            //Debug.Log(timeManager.ReturnReactionTime());
        }
    }
}
