using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>神クラス</summary>
public class GODClass : MonoBehaviour
{
    private static readonly PlaneData[] PlaneDataList = new PlaneData[]
    {
        new PlaneData()
        {
            id = "PLANE_DATA_0001",
            stock = 5,
            move_speed = 5.0f,
            bullet_shoot_interval = 0.1f,
        },
        new PlaneData()
        {
            id = "PLANE_DATA_1001",
            stock = 1,
            move_speed = 0.0f,
            bullet_shoot_interval = 0.25f,
        },
        new PlaneData()
        {
            id = "PLANE_DATA_1002",
            stock = 1,
            move_speed = 2.5f,
            bullet_shoot_interval = 0.5f,
        },
    };



    [SerializeField]
    private Plane _playerPlanePrefab = null;
    [SerializeField]
    private Plane _comPlanePrefab = null;


    private PlaneManager _planeManager = new PlaneManager();
    private PilotManager _pilotManager = new PilotManager();
    private BulletManager _bulletManager = new BulletManager();


    private void Start()
    {
        UIManager.Instance.Setup();

        UIController.UpdateScoreUI(0);

        // 自機
        var pPlane = _planeManager.CreatePlane(_playerPlanePrefab, PlaneDataList.FirstOrDefault(it => it.id == "PLANE_DATA_0001"), _bulletManager, true);
        _pilotManager.CreatePlayerPilot(pPlane);

        // 敵
        var planeSpawnInfoList = FindObjectsOfType<PlaneSpawnInfo>();
        if (planeSpawnInfoList != null)
        {
            foreach (var planeSpawnInfo in planeSpawnInfoList)
            {
                var cPlane = _planeManager.CreatePlane(_comPlanePrefab, PlaneDataList.FirstOrDefault(it => it.id == planeSpawnInfo.Id), _bulletManager, false);
                cPlane.transform.position = planeSpawnInfo.transform.position;
                cPlane.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _pilotManager.CreateComPilot(cPlane, pPlane);
            }
        }
    }

    private void Update()
    {
        _pilotManager.Tick();
        _planeManager.Tick();
        _bulletManager.Tick();
    }
}
