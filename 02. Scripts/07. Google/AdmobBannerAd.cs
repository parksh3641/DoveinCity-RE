using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBannerAd : MonoBehaviour
{
    public static AdmobBannerAd instance;

    private string Banner_ID = "ca-app-pub-6754544778509872/8570014499";
    private string Test_Banner_ID = "ca-app-pub-3940256099942544/6300978111";

    private string Test_Device_ID = "77f968ae67dda263";

    private BannerView banner;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        MobileAds.Initialize(Banner_ID);

        banner = new BannerView(Banner_ID, AdSize.SmartBanner,AdPosition.Top);

        AdRequest request = new AdRequest.Builder().AddTestDevice(Test_Device_ID).Build();

        banner.LoadAd(request);
    }

    public void Banner_Ads_Show()
    {
        banner.Show();
    }

    public void Banner_Ads_Hide()
    {
        banner.Hide();
    }

}
