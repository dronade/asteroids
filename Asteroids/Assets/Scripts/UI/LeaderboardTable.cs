using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardTable : MonoBehaviour

    // i'll finish this at some point
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<LeaderboardEntry> leaderboardEntryList;
    private List<Transform> leaderboardEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("Container");
        entryTemplate = entryContainer.Find("LeaderboardTemplate");
        entryTemplate.gameObject.SetActive(false);

        leaderboardEntryList = new List<LeaderboardEntry>() {
            new LeaderboardEntry{ score = 12346, user = "aaa" },
            new LeaderboardEntry{ score = 12345, user = "bbb" },
            new LeaderboardEntry{ score = 12344, user = "ccc" },
            new LeaderboardEntry{ score = 12343, user = "ddd" },
            new LeaderboardEntry{ score = 12342, user = "eee" },
            new LeaderboardEntry{ score = 12341, user = "fff" },
        };

        leaderboardEntryTransformList = new List<Transform>();
        foreach(LeaderboardEntry entry in leaderboardEntryList)
        {
            CreateLeaderbordEntryTransform(entry, entryContainer, leaderboardEntryTransformList);
        }
    }

    private void CreateLeaderbordEntryTransform(LeaderboardEntry leaderboardEntry, Transform container, List<Transform> transformList)
    {
        float templateheight = 70f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        Vector2 newPosition = entryTransform.position;
        newPosition.y = entryTransform.position.y - (templateheight * transformList.Count);
        entryTransform.position = newPosition;
        entryTransform.gameObject.SetActive(true);

        Transform posTextTransform = entryTransform.Find("PosTemplate");
        Transform scoreTextTranform = entryTransform.Find("ScoreTemplate");
        Transform userTextTransform = entryTransform.Find("UserTemplate");

        TMP_Text positionText = posTextTransform.GetComponent<TMP_Text>();
        TMP_Text scoreText = scoreTextTranform.GetComponent<TMP_Text>();
        TMP_Text userText = userTextTransform.GetComponent<TMP_Text>();


        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th";
                break;

            case 1:
                rankString = "1st";
                break;

            case 2:
                rankString = "2nd";
                break;

            case 3:
                rankString = "3rd";
                break;
        }
        positionText.SetText(rankString);

        int score = leaderboardEntry.score;
        scoreText.SetText(score.ToString());

        string user = leaderboardEntry.user;
        userText.SetText(user);

        transformList.Add(entryTransform);
    }
}