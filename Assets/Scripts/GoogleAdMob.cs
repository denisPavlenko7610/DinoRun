using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GoogleAdMob : MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Awake()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7173647303121367~8828703241";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
        
        interstitial.OnAdClosed += HandleOnAdClosed;
    }
    
    public void GameOver()
    {
        if (this.interstitial.IsLoaded()) {
            this.interstitial.Show();
        }
    }
    
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        SceneManager.LoadScene(0);
    }
}
