using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;


public class PlayFabManager : MonoBehaviour
{
    private static PlayFabManager instance;

    public static PlayFabManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayFabManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("PlayFabManager");
                    instance = container.AddComponent<PlayFabManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Initialize PlayFab with your Title ID
        PlayFabSettings.TitleId = "YOUR_PLAYFAB_TITLE_ID";
    }

    public void UpdatePlayerScore(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        { //the type or namespace name 'List<>' could not be found
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScore",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdateSuccess, OnLeaderboardUpdateFailure);
    }

    private void OnLeaderboardUpdateSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard updated successfully!");
    }

    private void OnLeaderboardUpdateFailure(PlayFabError error)
    {
        Debug.LogError("Leaderboard update failed: " + error.ErrorMessage);
    }
}
