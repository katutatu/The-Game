using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : SingletonMonoBehaviour<FPSCounter>
{
    [SerializeField]
    private float _updateInterval = 0.25f;

    private float _accum;
    private int _frames;
    private float _timeleft;
    private float _fps;

    private void Update()
    {
        _timeleft -= Time.deltaTime;
        _accum += Time.timeScale / Time.deltaTime;
        _frames++;

        if (0 < _timeleft) return;

        _fps = _accum / _frames;
        _timeleft = _updateInterval;
        _accum = 0;
        _frames = 0;
    }

    private void OnGUI()
    {
        var hw = 20;
        var h = Screen.height - hw;
        var label = "FPS: " + _fps.ToString("f2");
        GUI.Label(new Rect(0, h, 128, hw), label);
    }
}
