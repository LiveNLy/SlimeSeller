using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private List<Effect> _buffs = new List<Effect>();
    [SerializeField] private RectTransform _spawnArea;
    [SerializeField] private TimerForScoreMode _timer;
    [SerializeField] private PlusCoins _coins;
    [SerializeField] private SlimeSpawner _slimeSpawner;

    private Coroutine _coroutine;
    private WaitForSeconds _wait = new WaitForSeconds(7);

    private void Start()
    {
        _coroutine = StartCoroutine(Spawn());
    }

    private void StartSpawn()
    {
        Effect randomBuff = _buffs[Random.Range(0, _buffs.Count)];
        Effect newBuff = Instantiate(randomBuff, _spawnArea);
        SetToolToBuff(newBuff);

        RectTransform buffRect = newBuff.GetComponent<RectTransform>();

        if (buffRect != null)
        {
            Vector2 randomPosition = GetRandomPosition();
            buffRect.anchoredPosition = randomPosition;
        }
    }

    private void SetToolToBuff(Effect buff)
    {
        switch (buff)
        {
            case (PlusTimer):
                buff.SetTool(_timer);
                break;
            case (CoinsBuff):
                buff.SetTool(_coins);
                break;
            case (Respawn):
                buff.SetTool(_slimeSpawner);
                break;
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 areaSize = _spawnArea.rect.size;

        float randomX = Random.Range(-areaSize.x / 2, areaSize.x / 2);

        return new Vector2(randomX, areaSize.y);
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            StartSpawn();

            yield return _wait;
        }
    }
}
