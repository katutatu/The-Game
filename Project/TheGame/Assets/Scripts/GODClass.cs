using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>神クラス</summary>
public class GODClass : MonoBehaviour
{
    private static readonly PlaneData PlayerPlaneData = new PlaneData()
    {
        stock = 5,
        move_speed = 5.0f,
    };
    private static readonly PlaneData ComPlaneData = new PlaneData()
    {
        stock = 1,
        move_speed = 2.5f,
    };



    [SerializeField]
    private Plane _playerPlanePrefab = null;
    [SerializeField]
    private Plane _comPlanePrefab = null;


    private PlayerPilot _playerPilot;
    private ComPilot _comPilot;

    private Plane _playerPlane;
    private Plane _comPlane;


    private void Start()
    {
        UIManager.Instance.Setup();

        _playerPlane = CreatePlane(_playerPlanePrefab, PlayerPlaneData, true);
        _comPlane = CreatePlane(_comPlanePrefab, ComPlaneData, false);

        _playerPilot = new PlayerPilot();
        _comPilot = new ComPilot();

        _playerPilot.Setup(_playerPlane);
        _comPilot.Setup(_comPlane);
    }

    private void Update()
    {
        _playerPilot.Tick();
        _comPilot.Tick();

        // ダメージテスト
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            _playerPlane.ReceiveDamage();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _comPlane.ReceiveDamage();
        }
    }

    /// <summary>機体を作成</summary>
    private Plane CreatePlane(Plane planePrefab, PlaneData planeData, bool isPlayerPlane)
    {
        var plane = Instantiate(planePrefab);

        // セットアップ
        plane.Setup(planeData);

        // 自機の場合の処理
        if (isPlayerPlane)
        {
            UIController.UpdateStockUI(plane.Stock);

            plane.OnDamaged += (int stock) =>
            {
                UIController.UpdateStockUI(stock);
            };
        }

        return plane;
    }
}
