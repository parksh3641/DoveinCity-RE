using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobRewardAd : MonoBehaviour
{
    public static AdmobRewardAd instance;

    private int Kind = 0;

    private string Reward_ID = "ca-app-pub-6754544778509872/7655569834";
    private string Test_Reward_ID = "ca-app-pub-3940256099942544/5224354917";

    private string Test_Device_ID = "77f968ae67dda263";

    private RewardedAd reward;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        Kind = 0;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        MobileAds.Initialize(Reward_ID);

        reward = new RewardedAd(Reward_ID);
        Handle(reward);

        AdRequest request = new AdRequest.Builder().AddTestDevice(Test_Device_ID).Build();

        reward.LoadAd(request);
    }

    private void Handle(RewardedAd videoAd)
    {
        videoAd.OnAdFailedToShow += HandleOnAdFailedToShow;
        videoAd.OnAdClosed += HandleOnAdClosed;
        videoAd.OnUserEarnedReward += HandleOnUserEarnedReward;
    }

    public RewardedAd ReloadAd()
    {
        RewardedAd reward = new RewardedAd(Reward_ID);
        Handle(reward);

        AdRequest request = new AdRequest.Builder().AddTestDevice(Test_Device_ID).Build();

        reward.LoadAd(request);

        return reward;
    }

    public void Show(int number)
    {
        Kind = number; //0은 이어하기, 1은 코인 100% , 2는 상점 보석획득
        StartCoroutine("ShowRewardAd");
    }

    private IEnumerator ShowRewardAd()
    {
        while (!reward.IsLoaded())
        {
            yield return null;
        }
        reward.Show();
    }

    public void HandleOnAdFailedToShow(object sender, AdErrorEventArgs args) //재생실패
    {
        StartCoroutine(Fail_Wait());
    }


    public void HandleOnAdClosed(object sender, EventArgs e) //재생종료
    {
        this.reward = ReloadAd();
    }

    public void HandleOnUserEarnedReward(object sender, Reward e) //보상지급
    {
        StartCoroutine(Reward_Wait());
    }

    IEnumerator Reward_Wait()
    {
        yield return new WaitForSeconds(0.1f);
        if (Kind == 0)
        {
            GameManager.instance.RewardAd_Alive();
        }
        else if(Kind == 1)
        {
            GameManager.instance.RewardAd_Coin_Watch_Clear();
        }
        else if (Kind == 2)
        {
            ShopManager.instance.RewardAd_Clear();
        }
    }

    IEnumerator Fail_Wait()
    {
        yield return new WaitForSeconds(0.1f);
        if (Kind == 0)
        {
            GameManager.instance.RewardAd_Watch = false;
        }
        else if (Kind == 1)
        {
            GameManager.instance.RewardAd_Watch = false;
        }
        else if (Kind == 2)
        {

        }
    }
}
