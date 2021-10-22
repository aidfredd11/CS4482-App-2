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
        string name = PlayerPrefs.GetString("name");
      
        // Clear the player prefs 
        PlayerPrefs.DeleteAll();

        // Load the previous data
        LeaderBoardData loadedData = DataSaver.loadData<LeaderBoardData>("leaderboard");
        loadedData.names.Add(name);
        loadedData.times.Add(recordedScore);
        DataSaver.saveData(loadedData, "leaderboard");

        // Instantiate data object
        //LeaderBoardData saveData = new LeaderBoardData();

        // Add current combo to list 
       // saveData.names.Add(name);
       // saveData.times.Add(recordedScore);

        // Save it
      //  DataSaver.saveData(saveData, "leaderboard");

        // Get data now with new score
        LeaderBoardData leaderBoardData = DataSaver.loadData<LeaderBoardData>("leaderboard");

        if (leaderBoardData == null)
        {
            Debug.Log("Empty leaderboard");
        }
            
        for (int i = 0; i < leaderBoardData.names.Count; i++)
        {
            Debug.Log(leaderBoardData.names[i]);
        }
        for (int i = 0; i < leaderBoardData.times.Count; i++)
        {
            Debug.Log(leaderBoardData.times[i]);
        }

    }

}

[Serializable]
public class LeaderBoardData
{
    public List<float> times = new List<float>();
    public List<string> names = new List<string>();
}
