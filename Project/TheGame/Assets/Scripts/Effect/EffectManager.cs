using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : SingletonMonoBehaviour<EffectManager>
{
    [SerializeField]
    private Effect[] _effectPrefabs = null;


    private Dictionary<string, List<Effect>> _effectTable = new Dictionary<string, List<Effect>>();


    public IEffect GetEffect(string assetName)
    {
        if (_effectTable.TryGetValue(assetName, out var effects))
        {
            foreach (var effect in effects)
            {
                if (!effect.IsActive)
                {
                    return effect;
                }
            }
        }

        var effectPrefab = GetEffectPrefab(assetName);
        if (effectPrefab != null)
        {
            return Instantiate(effectPrefab);
        }

        return null;
    }

    private Effect GetEffectPrefab(string assetName)
    {
        for (var i = 0; i < _effectPrefabs.Length; i++)
        {
            var effectPrefab = _effectPrefabs[i];
            if (effectPrefab.name == assetName)
            {
                return effectPrefab;
            }
        }

        return null;
    }
}
