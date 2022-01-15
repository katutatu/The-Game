using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>神クラス</summary>
public class GODClass : MonoBehaviour
{
    [SerializeField]
    private Plane _planeRigPrefab = null;
    [SerializeField]
    private GameObject _playerPlaneModelPrefab = null;
    [SerializeField]
    private GameObject _comPlaneModelPrefab = null;


    private PlaneManager _planeManager = new PlaneManager();
    private PilotManager _pilotManager = new PilotManager();
    private BulletManager _bulletManager = new BulletManager();
    private ScoreManager _scoreManager = new ScoreManager();

    private Plane _plaerPlane;


    private void Start()
    {
        UIManager.Instance.Setup();
        _planeManager.Setup(_planeRigPrefab);

        UIController.UpdateScoreUI(0);

        // 自機
        var pPlane = _planeManager.CreatePlane(_playerPlaneModelPrefab, MasterData.Instance.FindPlaneData("PLANE_DATA_0001"), _bulletManager, true);
        _pilotManager.CreatePlayerPilot(pPlane);

        // 敵
        var planeSpawnInfoList = FindObjectsOfType<PlaneSpawnInfo>();
        if (planeSpawnInfoList != null)
        {
            foreach (var planeSpawnInfo in planeSpawnInfoList)
            {
                var cPlane = _planeManager.CreatePlane(_comPlaneModelPrefab, MasterData.Instance.FindPlaneData(planeSpawnInfo.Id), _bulletManager, false);
                cPlane.OnDied += () => { _scoreManager.UpdateScore(cPlane.Score); };
                cPlane.transform.position = planeSpawnInfo.transform.position;
                cPlane.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _pilotManager.CreateComPilot(cPlane, pPlane);
            }
        }

        _scoreManager.OnScoreChanged += (int score) => { UIController.UpdateScoreUI(score); };

        _plaerPlane = pPlane;
    }

    private void Update()
    {
        _pilotManager.Tick();
        _planeManager.Tick();
        _bulletManager.Tick();
    }

    public bool IsEnd()
    {
        return _plaerPlane != null && _plaerPlane.IsDead;
    }
}
