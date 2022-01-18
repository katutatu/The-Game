using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundNames
{
    public const string SE_Enter = "Enter";
    public const string SE_Cancel = "Cancel";
    public const string SE_DestroyEnemy = "DestroyEnemy";
    public const string SE_DestroyRock = "DestroyRock";
    public const string BGM_Game = "GameBGM";
}

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField]
    private AudioSource[] _sePrefabs = null;
    [SerializeField]
    private AudioSource[] _bgmPrefabs = null;


    private Dictionary<string, List<AudioSource>> _seTable = new Dictionary<string, List<AudioSource>>();
    private Dictionary<string, AudioSource> _bgmDict = new Dictionary<string, AudioSource>();


    public void Setup()
    {
        foreach (var sePrefab in _sePrefabs)
        {
            var seList = new List<AudioSource>();
            seList.Add(Instantiate(sePrefab, transform));
            _seTable.Add(sePrefab.name, seList);
        }

        foreach (var bgmPrefab in _bgmPrefabs)
        {
            var seList = new List<AudioSource>();
            _bgmDict.Add(bgmPrefab.name, Instantiate(bgmPrefab, transform));
        }
    }

    public void Play(string assetName)
    {
        if (_seTable.TryGetValue(assetName, out var seList))
        {
            seList[0].Play();
        }
        else if (_bgmDict.TryGetValue(assetName, out var bgm))
        {
            bgm.Play();
        }
    }
    
    public void Stop(string assetName)
    {
        if (_seTable.TryGetValue(assetName, out var seList))
        {
            seList[0].Stop();
        }
        else if (_bgmDict.TryGetValue(assetName, out var bgm))
        {
            bgm.Stop();
        }
    }
}
