using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Threading.Tasks;

public class GooglePlayManager : MonoBehaviour
{
    public int Value = 0;

    public static GooglePlayManager instance;

    public bool Login = false;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        DontDestroyOnLoad(gameObject);
    }

    public void OnLogin()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool bSuccess) =>
            {
                if (bSuccess)
                {
                    Login = true;
                    PlayerPrefs.SetInt("Login", 2);
                    //text.text = Social.localUser.userName;
                    if (Value == 0)
                    {
                        TitleManager.instance.TouchNo();
                        StartCoroutine(Wait());
                    }
                    else
                    {
                        SelectManager.instance.DefaultOption();
                    }
                }
                else
                {
                    Login = false;
                    if (Value == 0)
                    {
                        TitleManager.instance.Login_GooglePlay_Fail();
                    }
                    else
                    {
                        SelectManager.instance.DefaultOption();
                    }
                }
            });
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        TitleManager.instance.GooglePlay_Go();
    }

    public void OnLogOut()
    {
        PlayerPrefs.SetInt("Login", 0);
        Login = false;
        ((PlayGamesPlatform)Social.Active).SignOut();

        if(Value == 1)
        {
            SelectManager.instance.DefaultOption();
        }
    }

    public void Leaderboard_Renewal()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(SelectManager.instance.HighScore, GPGSIds.leaderboard, (bool success) => { });
        }
    }

    public void ShowLeaderboardUI()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAchievementUI()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement_1()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement, 100, (bool success) => { });
        }
    }

    public void UnlockAchievement_2()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_2, 100, (bool success) => { });
        }
    }


}