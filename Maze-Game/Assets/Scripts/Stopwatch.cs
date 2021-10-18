using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    private bool isActive = false;
    private float currentTime;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = "Stopwatch: " + time.ToString(@"mm\:ss\:fff");
    }
    public void StartStopwatch()
    {
        isActive = true;
    }
    public void StopStopwatch()
    {
        isActive = false;
    }
}
