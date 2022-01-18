using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectNames
{
    public const string PlaneTrail = "SmokeTrail 3d";
    public const string PlaneExplosion = "WFX_ExplosiveSmoke Small";
    public const string RockSpark = "BasicSpark 2";
}

public class EffectManager : SingletonMonoBehaviour<EffectManager>
{
    [SerializeField]
    private Effect[] _effectPrefabs = null;


    private Dictionary<string, List<Effect>> _effectTable = new Dictionary<string, List<Effect>>();


    public void Setup()
    {
        foreach (var effectPrefab in _effectPrefabs)
        {
            _effectTable.Add(effectPrefab.name, new List<Effect>());
        }
    }

    public void Tick()
    {
        foreach (var effectList in _effectTable.Values)
        {
            foreach (var effect in effectList)
            {
                effect.Tick();
            }
        }
    }

    public IEffect GetEffect(string assetName)
    {
        if (_effectTable.TryGetValue(assetName, out var effectList))
        {
            foreach (var effect in effectList)
            {
                if (!effect.IsActive)
                {
                    return effect;
                }
            }

            var effectPrefab = GetEffectPrefab(assetName);
            if (effectPrefab != null)
            {
                var effect = Instantiate(effectPrefab, transform);
                effect.name = assetName;
                effect.Setup();
                effectList.Add(effect);
                return effect;
            }
        }

        return null;
    }

    public void DestroyEffect(IEffect iEffect)
    {
        var effect = iEffect as Effect;
        if (_effectTable.TryGetValue(effect.name, out var effectList))
        {
            effectList.Remove(effect);
        }
        Destroy(effect.gameObject);
    }

    public void SetAllActive(string assetName, bool isActive)
    {
        if (_effectTable.TryGetValue(assetName, out var effectList))
        {
            foreach (var effect in effectList)
            {
                effect.gameObject.SetActive(false);
            }
        }
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
