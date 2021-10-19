using System;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public static bool isActive = false;
    private float currentTime;
    public Text currentTimeText;
    private string lineTag;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        lineTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            currentTime = currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = "Time:\n" + time.ToString(@"mm\:ss\:fff");
        }
    }

    public void ToggleStopwatch()
    {
        isActive = !isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        ToggleStopwatch();
        gameObject.GetComponent<Collider>().enabled = false; // disable collider if they cross the line again
    }
}
