using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

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

        RequestBanner();
        RequestInterstitial();
        RequestVideoAd();
    }

    void RequestBanner()
    {
        //for testing banners ads
        //string banner_ID = "ca-app-pub-3940256099942544/6300978111";

        //for publishing apps
        string banner_ID = "ca-app-pub-2790492244434188/3113136003";

        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner , AdPosition.Top);

        //For testing purposes
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //For Real app
        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerAD.LoadAd(adRequest);
    }

    void RequestInterstitial()
    {
        //for testing banners ads
        //string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

        //for publishing app
        string interstitial_ID = "ca-app-pub-2790492244434188/1905131581";

        interstitialAd = new InterstitialAd(interstitial_ID);

       

        //For testing purposes
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //For Real app
        AdRequest adRequest = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(adRequest);
    }

    void RequestVideoAd()
    {
        //for testing banners ads
        //string video_ID = "ca-app-pub-3940256099942544/5224354917";

        //for publishing app
        string video_ID = "ca-app-pub-2790492244434188/4228042594";

        rewardVideoAd = RewardBasedVideoAd.Instance;



        //For testing purposes
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //For Real app
        AdRequest adRequest = new AdRequest.Builder().Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);
    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void DisplayInterstitial()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    public void Diplay_Reward_Video()
    {
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }

    //Handle Events
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //Ad is loaded show it
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //It has failed to laod, load it again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }

    }

    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }
}
