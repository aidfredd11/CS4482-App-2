using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<LeaderboardEntry> boardEntryList;
    private List<Transform> boardEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        boardEntryList = new List<LeaderboardEntry>()
        {
            new LeaderboardEntry{ score = 123456, name= "AAA"},
            new LeaderboardEntry{ score = 345454, name= "BBB"},
            new LeaderboardEntry{ score = 953485, name= "CCC"},
            new LeaderboardEntry{ score = 156789, name= "DDD"},
            new LeaderboardEntry{ score = 456789, name= "EEE"},
            new LeaderboardEntry{ score = 785439, name= "FFF"},
        };

        SortList(boardEntryList);
        boardEntryTransformList = new List<Transform>();

        foreach(LeaderboardEntry entry in boardEntryList)
        {
            CreateEntryTransform(entry, entryContainer, boardEntryTransformList);
        }
    }

    private void CreateEntryTransform(LeaderboardEntry leaderboardEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        // place
        int place = transformList.Count + 1;
        string placeText = place.ToString();
        entryTransform.Find("placeText").GetComponent<Text>().text = placeText;

        // name
        string name = leaderboardEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // time
        int timeScore = leaderboardEntry.score;
        entryTransform.Find("timeText").GetComponent<Text>().text = timeScore.ToString();

        transformList.Add(entryTransform);
    }

    private class LeaderboardEntry {
        public string name;
        public int score;
    }

    // sort the list of entries by their scores
    private void SortList(List<LeaderboardEntry> list)
    {
        for(int i =0; i < list.Count; i++)
        {
            for(int j = i+1; j < list.Count; j++)
            {
                if (list[j].score > list[i].score)
                {
                    // Swap
                    LeaderboardEntry temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }   
        }
    }

}
