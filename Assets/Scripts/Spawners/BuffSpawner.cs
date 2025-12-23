using System.Collections;
using System.Collections.Generic;
using Buffs;
using Spawners;
using UI;
using UnityEngine;

namespace Spawners
{
    public class BuffSpawner : MonoBehaviour
    {
        [SerializeField] private List<BuffClick> _buffs = new List<BuffClick>();
        [SerializeField] private RectTransform _spawnArea;
        [SerializeField] private TimerForScoreMode _timer;
        [SerializeField] private PlusCoins _coins;
        [SerializeField] private BasketSpawnerForRecordMode _slimeSpawner;

        private Coroutine _coroutine;
        private WaitForSeconds _wait = new WaitForSeconds(7);

        private void Start()
        {
            _coroutine = StartCoroutine(Spawn());
        }

        private void StartSpawn()
        {
            BuffClick randomBuff = _buffs[Random.Range(0, _buffs.Count)];
            BuffClick newBuff = Instantiate(randomBuff, _spawnArea);
            SetToolToBuff(newBuff);

            RectTransform buffRect = newBuff.GetComponent<RectTransform>();

            if (buffRect != null)
            {
                Vector2 randomPosition = GetRandomPosition();
                buffRect.anchoredPosition = randomPosition;
            }
        }

        private void SetToolToBuff(BuffClick buff)
        {
            switch (buff)
            {
                case PlusTimer:
                    buff.SetTool(_timer);
                    break;
                case CoinsBuff:
                    buff.SetTool(_coins);
                    break;
                case Respawn:
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
}