using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager
{
    private bool _isCreatedPlayerPlane;

    private List<Plane> _planes = new List<Plane>();


    /// <summary>機体を作成</summary>
    public Plane CreatePlane(Plane planePrefab, PlaneData planeData, bool isPlayerPlane)
    {
        // 2つ以上自機を作ろうとしている
        if (_isCreatedPlayerPlane && isPlayerPlane)
        {
            return null;
        }

        var plane = Object.Instantiate(planePrefab);

        // セットアップ
        plane.Setup(planeData, isPlayerPlane);

        // 自機の場合の処理
        if (plane.IsPlayerPlane)
        {
            _isCreatedPlayerPlane = true;

            UIController.UpdateStockUI(plane.Stock);

            plane.OnDamaged += (int stock) =>
            {
                UIController.UpdateStockUI(stock);
            };
        }
        else
        {
            // 仮
            plane.transform.position = new Vector3(0.0f, 0.0f, 15.0f);
            plane.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }

        _planes.Add(plane);

        return plane;
    }
}
