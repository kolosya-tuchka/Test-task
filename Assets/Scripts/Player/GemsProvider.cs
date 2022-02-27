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

    private List<IPortable<Gem>> _pickedGems;

    private void Start()
    {
        _pickedGems = new List<IPortable<Gem>>();
        _scoreUI.UpdateScoreText(Score);
    }

    public void AddGem(IPortable<Gem> gem)
    {
        if (_pickedGems.Count == _gemsCapacity) return;
        
        gem.OnPicked(_gemsProviderPoints[_pickedGems.Count]);
        _pickedGems.Add(gem);
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
