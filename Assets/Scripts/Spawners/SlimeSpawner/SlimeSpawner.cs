using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlimeSpawner : BaseBasketSpawner, ISlimeSpawner
{
    [SerializeField] private Score _score;
    [SerializeField] private PlusCoins _savedCoins;
    [SerializeField] private int _pointsToRemoveCount;
    [SerializeField] private Tool _timer;

    private int _minRandomNumberToRemove = 8;
    private int _maxRandomNumberToRemove = 12;
    private List<SpawnPoint> _deletedPoints = new List<SpawnPoint>();

    public new event Action Spawning;

    public override void Spawn()
    {
        SetRandomPointsToRemove();

        foreach (var spawnPoint in _spawnPoints)
        {
            bool HasEffect = Random.Range(0f, 1f) < 0.1f;
            Vector3 correctSpawnPoint = spawnPoint.transform.position;
            correctSpawnPoint.z -= 0.5f;
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
        ResetPointsCount();
    }

    public override bool DeleteSlimeFromList(Slime slime)
    {
        _spawnedSlimes.Remove(slime);
        _savedCoins.AddCoins(slime.Stars);
        _score.AddScore(slime.ScorePoints);

        if (_spawnedSlimes.Count == 0)
        {
            Respawn();
            return false;
        }

        return true;
    }

    public override void Respawn()
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

        SetPointsToRemoveCount();

        Spawn();
    }

    public void SetPointsToRemoveCount()
    {
        _pointsToRemoveCount = Random.Range(_minRandomNumberToRemove, _maxRandomNumberToRemove);
    }

    private void ResetPointsCount()
    {
        foreach (var point in _deletedPoints)
        {
            _spawnPoints.Add(point);
        }

        _deletedPoints.Clear();
    }

    private void SetRandomPointsToRemove()
    {
        for (int i = 0; i < _pointsToRemoveCount; i++)
        {
            int randomNumber = Random.Range(0, _spawnPoints.Count);
            _deletedPoints.Add(_spawnPoints[randomNumber]);
            _spawnPoints.RemoveAt(randomNumber);
        }
    }
}