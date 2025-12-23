using System;
using System.Collections.Generic;
using BasketsStuff;
using Interfaces;
using Random = UnityEngine.Random;
using Slimes;
using UI;
using UnityEngine;
using YG;

namespace Spawners
{
    public class BaseBasketSpawner : MonoBehaviour, ITool, ISlimeSpawner
    {
        [SerializeField] protected List<SpawnPoint> _spawnPoints;
        [SerializeField] protected Basket _basketPrefab;
        [SerializeField] protected DeliveryPoint _deliveryPoint;
        [SerializeField] protected SpriteManager _spriteManager;
        [SerializeField] protected float _zCorrecter = 0.5f;

        protected List<Slime> _spawnedSlimes = new List<Slime>();
        protected List<Basket> _spawnedBasket = new List<Basket>();
        protected List<Color> _colors = new List<Color>() { Color.cyan, Color.green, Color.red, Color.yellow };

        public event Action Spawning;
        public List<Slime> SpawnedSlimes => _spawnedSlimes;

        private void Start()
        {
            _spriteManager = FindAnyObjectByType<SpriteManager>();
            _basketPrefab.SetSlimeSprite(_spriteManager.LoadSprite(YG2.saves.SlimeSpriteName));
        }

        public virtual void Spawn()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                Vector3 correctSpawnPoint = spawnPoint.transform.position;
                correctSpawnPoint.z -= _zCorrecter;
                Basket newBasket = Instantiate(_basketPrefab, correctSpawnPoint, Quaternion.identity, this.transform);
                _spawnedBasket.Add(newBasket);

                Renderer renderer = newBasket.GetSlime().GetComponent<Renderer>();

                if (renderer != null)
                {
                    Material newMaterial = new Material(renderer.material);
                    newMaterial.color = _colors[Random.Range(0, _colors.Count)];
                    renderer.material = newMaterial;
                }

                _spawnedSlimes.Add(newBasket.GetSlime());
            }

            Spawning?.Invoke();
        }

        public virtual void Respawn()
        {
            foreach (Slime slime in _spawnedSlimes)
            {
                Destroy(slime.gameObject);
            }

            foreach (Basket basket in _spawnedBasket)
            {
                Destroy(basket.gameObject);
            }

            _spawnedBasket.Clear();
            _spawnedSlimes.Clear();

            Spawn();
        }

        public virtual bool DeleteSlimeFromList(Slime slime)
        {
            _spawnedSlimes.Remove(slime);

            return true;
        }

        public Color RandomColor()
        {
            return _spawnedSlimes[Random.Range(0, _spawnedSlimes.Count)].SlimeColor;
        }

        public void RemoveBasketsOnLose()
        {
            foreach (Slime slime in _spawnedSlimes)
            {
                Destroy(slime.gameObject);
            }

            foreach (Basket basket in _spawnedBasket)
            {
                Destroy(basket.gameObject);
            }

            _spawnedBasket.Clear();
            _spawnedSlimes.Clear();
        }

        public void ApplyEffect(int number)
        {
            Respawn();
        }
    }
}