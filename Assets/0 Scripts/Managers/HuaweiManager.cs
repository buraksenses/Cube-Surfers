using System.Collections;
using System.Collections.Generic;
using CubeSurfers.Managers;
using UnityEngine;
using HmsPlugin;
using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;

public class HuaweiManager : MonoBehaviour
{
    public bool isOwned;
    private void Start()
    {
        HMSAccountKitManager.Instance.OnSignInSuccess = SignInSuccess;
        HMSAccountKitManager.Instance.OnSignInFailed = SignInFailed;
        HMSAccountKitManager.Instance.SignIn();
        EventManager.onSuccess += ShowInterstitialAd;
    }

    private void SignInFailed(HMSException obj)
    {
        Debug.Log($"SignInFailed. exception details: {obj.Message}");
    }

    private void SignInSuccess(AuthAccount obj)
    {
        Debug.Log($"OnLoginSuccess User Name : {obj.DisplayName}");
    }

    private void ShowInterstitialAd()
    {
        if (!isOwned)
        {
            HMSAdsKitManager.Instance.ShowInterstitialAd();
        }
    }
}
