using UnityEngine;
using YG;

public class ShowADV : MonoBehaviour
{
    [SerializeField] private Stars _stars;

    private int _starsRewardCount = 50;
    private string _starsID = "stars";

    public void ShowInterstitialADV()
    {
        YG2.InterstitialAdvShow();
    }

    public void ShowRewardedADV()
    {
        YG2.RewardedAdvShow(_starsID, StarReward);
        YG2.onCloseRewardedAdv += SaveStars;
    }

    private void SaveStars()
    {
        YG2.SaveProgress();
    }

    private void StarReward()
    {
        _stars.AddStars(_starsRewardCount);
    }
}