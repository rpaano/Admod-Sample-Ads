using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{

    private string APP_ID = "ca-app-pub-2790492244434188~5252214182";

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;

    // Start is called before the first frame update
    void Start()
    {
        //For publish apps
        //MobileAds.Initialize(APP_ID);
    }

    void RequestBanner()
    {
        //for testing banners ads
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        //for publishing apps
        //string banner_ID = "ca-app-pub-2790492244434188/3113136003";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner , AdPosition.Top);

    }
}
