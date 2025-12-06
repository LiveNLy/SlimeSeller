using UnityEngine;
using UnityEngine.UI;
using YG;

public class OnLevelWin : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private TimerForLevels _timerForLevels;
    [SerializeField] private Image _silver;
    [SerializeField] private Image _gold;
    [SerializeField] private int _forSilver;
    [SerializeField] private int _forGold;

    private string _id = "bronze";

    public void SetStats()
    {
        MakeConvertationTime();
        YG2.saves.LevelDone(_levelNumber - 1);
        YG2.saves.LevelsStats[_levelNumber - 1] = _id;
        YG2.SaveProgress();
    }

    private void MakeConvertationTime()
    {
        if (_timerForLevels.Timer < _forSilver)
        {
            Color color = new Color(255f, 255f, 255f, 1);
            _silver.color = color;

            _id = "silver";
        }

        if (_timerForLevels.Timer < _forGold)
        {
            Color color = new Color(255f, 255f, 255f, 1);
            _gold.color = color;

            _id = "gold";
        }

        if (YG2.saves.LevelsStats[_levelNumber - 1] == "gold" && (_id == "silver" || _id == "bronze"))
        {
            _id = "gold";
        }
        else if (YG2.saves.LevelsStats[_levelNumber - 1] == "silver" && (_id != "gold" || _id == "bronze"))
        {
            _id = "silver";
        }

        Debug.Log(_id);
    }
}