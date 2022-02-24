using System.Collections.Generic;
using UnityEngine;

public class GemsPool : MonoBehaviour, IPool<Gem>
{
    [SerializeField] private int _size;
    [SerializeField] private Gem _gemPrefab;

    private Queue<Gem> _gems;

    private void Start()
    {
        _gems = new Queue<Gem>();
        for (int i = 0; i < _size; ++i)
        {
            var gem = Instantiate(_gemPrefab, transform);
            gem.GemPool = this;
            _gems.Enqueue(gem);
            gem.gameObject.SetActive(false);
        }
    }

    public Gem ActivatePoolObject()
    {
        if (_gems.Count == 0) return null;
        
        var gem = _gems.Dequeue();
        gem.gameObject.SetActive(true);
        return gem;
    }

    public void DeactivatePoolObject(Gem gem)
    {
        gem.transform.parent = transform;
        gem.gameObject.SetActive(false);
        _gems.Enqueue(gem);
    }
}
