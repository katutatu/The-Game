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
    private static readonly PlaneData ComPlaneData1 = new PlaneData()
    {
        stock = 1,
        move_speed = 0.0f,
    };
    private static readonly PlaneData ComPlaneData2 = new PlaneData()
    {
        stock = 1,
        move_speed = 2.5f,
    };



    [SerializeField]
    private Plane _playerPlanePrefab = null;
    [SerializeField]
    private Plane _comPlanePrefab = null;


    private PlaneManager _planeManager = new PlaneManager();
    private PilotManager _pilotManager = new PilotManager();


    private void Start()
    {
        UIManager.Instance.Setup();

        UIController.UpdateScoreUI(0);

        var pPlane = _planeManager.CreatePlane(_playerPlanePrefab, PlayerPlaneData, true);
        var cPlane1 = _planeManager.CreatePlane(_comPlanePrefab, ComPlaneData1, false);
        var cPlane2 = _planeManager.CreatePlane(_comPlanePrefab, ComPlaneData2, false);
        _pilotManager.CreatePlayerPilot(pPlane);
        _pilotManager.CreateComPilot(cPlane1, pPlane);
        _pilotManager.CreateComPilot(cPlane2, pPlane);
    }

    private void Update()
    {
        _pilotManager.Tick();
        _planeManager.Tick();
    }
}
