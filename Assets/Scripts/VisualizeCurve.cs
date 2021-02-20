// +----------------------+------------------------------------------------------------------
// |   Acknowledgements   |
// +----------------------+
// Written by: Michael Spicer

// Following a Bezier Curve: https://www.youtube.com/watch?v=11ofnLOE8pw&feature=emb_title


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VisualizeCurve : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;

    private Vector2 gizmoPosition;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += .05f)
        {
            gizmoPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                            3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                            3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                            Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmoPosition, .25f);
        }

        Gizmos.DrawLine(controlPoints[0].position, controlPoints[1].position);
        Gizmos.DrawLine(controlPoints[2].position, controlPoints[3].position);
    }
}
