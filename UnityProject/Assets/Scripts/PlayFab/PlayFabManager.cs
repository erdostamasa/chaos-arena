using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEditor;
using UnityEngine;

public class PlayFabManager : MonoBehaviour {
    public static PlayFabManager instance;
    [SerializeField] DeathMenu deathMenu;

    [SerializeField] GameObject entriesParent;
    [SerializeField] Transform rowPreafab;

    void Awake() {
        instance = this;
    }


    public void Start() {
        Login();
    }

    void Login() {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult result) {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnError(PlayFabError error) {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    public void SendLeaderboard() {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "HighScore",
                    Value = GameManager.instance.score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Leaderboard successfully sent");
    }

    public void GetLeaderboard() {
        var request = new GetLeaderboardRequest {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result) {
        foreach (Transform o in entriesParent.transform) {
            Destroy(o.gameObject);
        }
        
        foreach (PlayerLeaderboardEntry entry in result.Leaderboard) {
            Debug.Log(entry.Position + " " + entry.PlayFabId + " " + entry.StatValue);
            Transform row = Instantiate(rowPreafab, entriesParent.transform);
            row.GetComponent<LeaderboardRow>().Initialize(entry.Position, entry.PlayFabId, entry.StatValue);
        }
    }
}