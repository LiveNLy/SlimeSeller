using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private int _neededLevel = 1;
    [SerializeField] private bool _isEnabled = true;

    public int NeededLevel => _neededLevel;

    public void SetIsEnabled(bool isEnabled)
    {
        _isEnabled = isEnabled;
    }

    public void OnLevel()
    {
        if (_isEnabled)
        {
            SceneManager.LoadScene(_neededLevel);
        }
    }
}