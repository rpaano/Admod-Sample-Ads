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

        //For testing purposes
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //For Real app
        //AdRequest adRequest = new AdRequest.Builder().Build();

        bannerAD.LoadAd(adRequest);
    }

    void RequestInterstitial()
    {
        //for testing banners ads
        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

        //for publishing app
        //string interstitial_ID = "ca-app-pub-2790492244434188/1905131581";

        interstitialAd = new InterstitialAd(interstitial_ID);

       

        //For testing purposes
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //For Real app
        //AdRequest adRequest = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(adRequest);
    }

    void RequestVideoAd()
    {
        //for testing banners ads
        string video_ID = "ca-app-pub-3940256099942544/5224354917";

        //for publishing app
        //string video_ID = "ca-app-pub-2790492244434188/4228042594";

        rewardVideoAd = RewardBasedVideoAd.Instance;



        //For testing purposes
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //For Real app
        //AdRequest adRequest = new AdRequest.Builder().Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);
    }
}
