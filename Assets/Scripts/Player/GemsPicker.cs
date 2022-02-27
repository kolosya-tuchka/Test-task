using System;
using UnityEngine;

[RequireComponent(typeof(GemsProvider))]
public class GemsPicker : MonoBehaviour
{
    private GemsProvider _gemsProvider;

    private void Start()
    {
        _gemsProvider = GetComponent<GemsProvider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPortable<Gem>>(out IPortable<Gem> gem))
        {
            PickUp(gem);
        }
    }

    private void PickUp(IPortable<Gem> gem)
    {
        _gemsProvider.AddGem(gem);
    }
}
