using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeaderBoardData loadedData = DataSaver.loadData<LeaderBoardData>("leaderboard");

        // only add a new score if the player pref is not empty
        if (PlayerPrefs.HasKey("timeScore") && PlayerPrefs.HasKey("name"))
        {

            // get time and name
            float recordedScore = PlayerPrefs.GetFloat("timeScore");
            string name = PlayerPrefs.GetString("name");

            // Clear the player prefs 
            PlayerPrefs.DeleteAll();

            // add the score and name to the data
            if (loadedData == null)
            {
                loadedData = new LeaderBoardData();
            }
            loadedData.names.Add(name);
            loadedData.times.Add(recordedScore);
           
            // Save it
            DataSaver.saveData(loadedData, "leaderboard");

        }

        if (loadedData == null)
        {
            Debug.Log("Empty leaderboard");
        }
        else
        {
            // make the 2 lists into a dictionary
            List<float> times = loadedData.times;
            List<string> names = loadedData.names;
            
            var orderedZip = times.Zip(names, (x, y) => new { x, y })
                      .OrderBy(pair => pair.x)
                      .ToList();

            times = orderedZip.Select(pair => pair.x).ToList();
            names = orderedZip.Select(pair => pair.y).ToList();

            GenerateTextObjects(times, names);
        }

    }

    private void GenerateTextObjects(List<float> times, List<string> names)
    {

        for (int i = 0; i < names.Count; i++)
        {
            // get the current item
            string thisName = names[i];
            string thisTime = times[i].ToString();
            // combine to one string
            string entryString = (i + 1).ToString() + ". " + thisName + "_____" + thisTime;

            // make a gameobject for the text
            GameObject newText = new GameObject("Entry", typeof(RectTransform));
            newText.layer = 5; // make it a ui layer

            // Change its size
            RectTransform rectTransform = newText.GetComponent<RectTransform>();
            float temp = rectTransform.localScale.x;
            rectTransform.localScale = new Vector3(1 / temp, 1, 1);
            rectTransform.sizeDelta = new Vector2(344, 66);

            // add a text componet to new game object
            var newTextComp = newText.AddComponent<Text>();

            // set up text
            newTextComp.text = entryString;
            newTextComp.alignment = TextAnchor.MiddleCenter;
            newTextComp.color = Color.black;

            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            newTextComp.font = ArialFont;
            newTextComp.fontSize = 22;

            // make it a child of content gameobject
            newText.transform.SetParent(transform);

        }
    }

}

[Serializable]
public class LeaderBoardData
{
    public List<float> times = new List<float>();
    public List<string> names = new List<string>();
}
