using BasketsStuff;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    namespace ForBasketSpawner
    {
        public class BasketSpawnerForLevels : BaseBasketSpawner
        {
            [SerializeField] private List<Color> _nonRandom—olors = new List<Color>();

            private int _colorNumber = 0;

            public new event Action Spawning;

            public List<Color> CurrentColor => _nonRandom—olors;

            public override void Spawn()
            {
                foreach (var spawnPoint in _spawnPoints)
                {
                    Vector3 correctSpawnPoint = spawnPoint.transform.position;
                    correctSpawnPoint.z -= 0.5f;
                    Basket newBasket = Instantiate(_basketPrefab, correctSpawnPoint, Quaternion.identity, this.transform);
                    _spawnedBasket.Add(newBasket);

                    Renderer renderer = newBasket.GetSlime().GetComponent<Renderer>();

                    if (renderer != null)
                    {
                        Material newMaterial = new Material(renderer.material);
                        newMaterial.color = _nonRandom—olors[_colorNumber++];
                        renderer.material = newMaterial;
                    }

                    _spawnedSlimes.Add(newBasket.GetSlime());
                }

                if (_colorNumber > _nonRandom—olors.Count)
                {
                    _colorNumber = 0;
                }

                Spawning?.Invoke();
            }

            public override void Respawn()
            {
                base.Respawn();
                _colorNumber = 0;
            }
        }
    }
}