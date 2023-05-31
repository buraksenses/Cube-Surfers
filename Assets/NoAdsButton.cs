using System.Collections;
using System.Collections.Generic;
using HmsPlugin;
using HuaweiMobileServices.IAP;
using UnityEngine;

public class NoAdsButton : MonoBehaviour
{
   public void OnClick()
   {
      HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
      HMSIAPManager.Instance.PurchaseProduct(HMSIAPConstants.AdsRemove);
   }

   private void OnBuyProductSuccess(PurchaseResultInfo obj)
   {
      if (obj.InAppPurchaseData.ProductId == HMSIAPConstants.AdsRemove)
      {
         Debug.Log("OnBuyProductSuccess");
         FindObjectOfType<HuaweiManager>().isOwned = true;
         HMSAdsKitManager.Instance.HideBannerAd();
      }
   }
}
