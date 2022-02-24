using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class GemsFactory : GameObjectFactory
{
    [Serializable]
    class GemConfig
    {
        public GemType gemType;
        public Material gemMaterial;
        public int cost;
        public int spawnProportion;
    }

    [SerializeField]
    private List<GemConfig> _gemConfigs;

    public void SetConfig(Gem gem, GemType gemType)
    {
        var gemConfig = _gemConfigs.FirstOrDefault(config => config.gemType == gemType);
        if (gemConfig == null)
        {
            throw new ArgumentOutOfRangeException($"No config for {gemType}");
        }

        gem.Initialize(gemConfig.cost, gemConfig.gemMaterial);
    }

    public int GetTotalProportions()
    {
        int sum = 0;
        foreach (var config in _gemConfigs)
        {
            sum += config.spawnProportion;
        }

        return sum;
    }

    public GemType GetGemTypeByProportion(int proportion)
    {
        foreach (var config in _gemConfigs)
        {
            if (config.spawnProportion > proportion)
            {
                return config.gemType;
            }

            proportion -= config.spawnProportion;
        }

        return GemType.Silver;
    }
    
}
