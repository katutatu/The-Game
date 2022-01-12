using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotManager
{
    private List<Pilot> _pilots = new List<Pilot>();


    public Pilot CreatePlayerPilot(Plane plane)
    {
        Debug.Assert(plane.IsPlayerPlane);
        var pilot = new PlayerPilot();
        pilot.Setup(plane);
        _pilots.Add(pilot);
        return pilot;
    }

    public Pilot CreateComPilot(Plane plane, IPlaneReadOnly playerPlane)
    {
        Debug.Assert(!plane.IsPlayerPlane);
        var pilot = new ComPilot();
        pilot.Setup(plane);
        pilot.SetPlayerPlane(playerPlane);
        _pilots.Add(pilot);
        return pilot;
    }

    public void Tick()
    {
        foreach (var pilot in _pilots)
        {
            pilot.Tick();
        }
    }
}
