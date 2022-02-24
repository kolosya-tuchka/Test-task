using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemsSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 5f;
    
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GemsPool _gemsPool;
    [SerializeField] private GemsFactory _gemsFactory;

    private void Start()
    {
        StartCoroutine(SpawnGems());
    }

    private IEnumerator SpawnGems()
    {
        while (true)
        {
            var gem = _gemsPool.ActivatePoolObject();

            gem.OnActvate();
            gem.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.GetLength(0))].position;
            
            int totalProportions = _gemsFactory.GetTotalProportions();
            int proportion = Random.Range(0, totalProportions);
            _gemsFactory.SetConfig(gem, _gemsFactory.GetGemTypeByProportion(proportion));
            
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
