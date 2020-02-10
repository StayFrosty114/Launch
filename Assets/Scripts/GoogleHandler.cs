using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GoogleHandler : MonoBehaviour
{
    public void StartGooglePlayServices()
    {
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success == true)
                {

                }
                else
                {
                    Debug.Log("Login failed");
                }
            });
        }
    }

    public void UpdateAchievement(string achievementID)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100.0f, (bool success) =>
            {
                if (success == true)
                {
                    Debug.Log("Unlocked" + achievementID);
                }
                else
                {
                    Debug.Log("Failed to achieve");
                }
            });
        }
    }

    public void IncrementAchievement(string achievementID, int increment)
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.IncrementAchievement(achievementID, increment, (bool success) =>
            {
                if (success == true)
                {
                    // Achievement incremented
                }
                else
                {
                    Debug.Log("Failed to increment");
                }
            });
        }
    }

    public void UpdateLeaderboard(string leaderboardID, int score)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, leaderboardID, (bool success) =>
            {
                if (success == true)
                {
                    // Score updated
                }
                else
                {
                    Debug.Log("Failed to update");
                }
            });
        }
    }

    public void ShowGoogleAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Not authenticated");
        }
    }
}
