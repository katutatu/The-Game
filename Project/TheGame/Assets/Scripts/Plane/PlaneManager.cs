using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager
{
    private bool _isCreatedPlayerPlane;

    private Plane _planeRigPrefab;

    private List<Plane> _planes = new List<Plane>();


    /// <summary>機体を作成</summary>
    public Plane CreatePlane(GameObject planeModelPrefab, PlaneData planeData, IBulletShootSystem bulletShootSystem, bool isPlayerPlane)
    {
        // 2つ以上自機を作ろうとしている
        if (_isCreatedPlayerPlane && isPlayerPlane)
        {
            return null;
        }

        var plane = Object.Instantiate(_planeRigPrefab);
        var planeModel = Object.Instantiate(planeModelPrefab);

        // 
        planeModel.transform.SetParent(plane.transform);

        // セットアップ
        plane.Setup(planeData, bulletShootSystem, isPlayerPlane);

        // 自機の場合の処理
        if (plane.IsPlayerPlane)
        {
            _isCreatedPlayerPlane = true;
            plane.Spawn();

            UIController.UpdateStockUI(plane.Stock);

            plane.OnDamaged += (int stock) =>
            {
                UIController.UpdateStockUI(stock);
            };

            // 仮
            plane.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
        }

        _planes.Add(plane);

        return plane;
    }

    public void Setup(Plane planeRigPrefab)
    {
        _planeRigPrefab = planeRigPrefab;
    }

    public void Tick()
    {
        foreach (var plane in _planes)
        {
            plane.Tick();
        }
    }
}
