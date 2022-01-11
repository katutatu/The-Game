using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>神クラス</summary>
public class GODClass : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManagerPrefab;


    private UIManager _uiManager;


    private void Start()
    {
        _uiManager = Instantiate(_uiManagerPrefab);
        _uiManager.Setup();
    }
}
