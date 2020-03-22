using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobScreenAd : MonoBehaviour
{
    public static AdmobScreenAd instance;

    private string Screen_ID = "ca-app-pub-6754544778509872/6311177507";
    private string Test_Screen_ID = "ca-app-pub-3940256099942544/1033173712";

    private string Test_Device_ID = "77f968ae67dda263";

    private InterstitialAd screen;

    public int Count = 0;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        Count = 2;
    }
    void Start()
    {
        MobileAds.Initialize(Screen_ID);

        screen = new InterstitialAd(Screen_ID);

        AdRequest request = new AdRequest.Builder().AddTestDevice(Test_Device_ID).Build();
        screen.LoadAd(request);
    }

    public void Count_Up()
    {
        Count += 1;
        if(Count > 3)
        {
            Count = 0;
            Show();
        }
    }

    public void Show()
    {
        StartCoroutine(ShowScreenAd());
    }


    IEnumerator ShowScreenAd()
    {
        while(!screen.IsLoaded())
        {
            yield return null;
        }

        screen.Show();
    }

}
