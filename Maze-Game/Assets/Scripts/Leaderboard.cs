using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // get time and name
        float recordedScore = PlayerPrefs.GetFloat("timeScore");

        string timeString = recordedScore.ToString();
        string name = PlayerPrefs.GetString("name");

        // Clear the player prefs 
        PlayerPrefs.DeleteAll();


        // Instantiate data object
        LeaderBoardData saveData = new LeaderBoardData();

        // Add current combo to list 
        saveData.names.Add(name);
        saveData.times.Add(recordedScore);

        // Save it
        DataSaver.saveData(saveData, "leaderboard");

        // Get data now with new score
        LeaderBoardData leaderBoardData = DataSaver.loadData<LeaderBoardData>("leaderboard");

        // Use dictionary to sort 
        Dictionary<string, float> timeNamePairs = new Dictionary<string, float>();

        for (int i = 0; i < leaderBoardData.names.Count; i++)
        {
            string currentName = leaderBoardData.names[i];
            float currentTime = leaderBoardData.times[i];

            timeNamePairs.Add(currentName, currentTime);
        }

        foreach(KeyValuePair<string, float> item in timeNamePairs.OrderBy(key => key.Value))
        {

        }
  
    }

}

[Serializable]
public class LeaderBoardData
{
    public List<float> times = new List<float>();
    public List<string> names = new List<string>();
}
