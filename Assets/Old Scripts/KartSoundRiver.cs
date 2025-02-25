using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartSoundRiver : MonoBehaviour
{
    public Cinemachine.CinemachinePathBase path;
    public GameObject player;

    float m_pos;
    private Cinemachine.CinemachinePathBase.PositionUnits PositionUnits = Cinemachine.CinemachinePathBase.PositionUnits.PathUnits;
    // Update is called once per frame
    void Update()
    {
        SetCartPosition(path.FindClosestPoint(player.transform.position,0,-1,10));
    }
    void SetCartPosition(float distanceAlongThePath)
    {
        m_pos = path.StandardizeUnit(distanceAlongThePath, PositionUnits);
        transform.position = path.EvaluatePositionAtUnit(m_pos, PositionUnits);
        transform.rotation = path.EvaluateOrientationAtUnit(m_pos, PositionUnits);
    }
}
