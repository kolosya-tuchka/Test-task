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
        if (other.TryGetComponent<Gem>(out Gem gem))
        {
            PickUp(gem);
        }
    }

    private void PickUp(Gem gem)
    {
        _gemsProvider.AddGem(gem);
    }
}
