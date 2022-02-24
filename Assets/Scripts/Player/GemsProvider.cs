using System.Collections.Generic;
using UnityEngine;

public class GemsProvider : MonoBehaviour
{
    public int Score { get; private set; }
    [SerializeField] private Transform[] _gemsProviderPoints;

    [SerializeField] private GemsScoreUI _scoreUI;

    private int _gemsCapacity
    {
        get
        {
            return _gemsProviderPoints.GetLength(0);
        }
    }

    private List<Gem> _pickedGems;

    private void Start()
    {
        _pickedGems = new List<Gem>();
        _scoreUI.UpdateScoreText(Score);
    }

    public void AddGem(Gem gem)
    {
        if (_pickedGems.Count == _gemsCapacity) return;

        gem.transform.position = _gemsProviderPoints[_pickedGems.Count].position;
        gem.transform.parent = _gemsProviderPoints[_pickedGems.Count];
        _pickedGems.Add(gem);
        gem.OnPicked();
    }

    private void UnloadGems()
    {
        foreach (var gem in _pickedGems)
        {
            Score += gem.Cost;
            gem.OnUnloaded();
        }
        _scoreUI.UpdateScoreText(Score);
        _pickedGems.Clear();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnloadZone"))
        {
            UnloadGems();
        }
    }
}
