using System;
using System.Collections.Generic;
using UnityEngine;

class ActionBezierAbs : ActionInterval
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public Vector3 startControlPoint;
    public Vector3 endControlPoint;

    public ActionBezierAbs(Vector3 tgtStart, Vector3 tgtSCP, Vector3 tgtECP, Vector3 tgtEnd, float tgtDuration)
        : base(tgtDuration)
    {
        startPoint = tgtStart;
        endPoint = tgtEnd;
        startControlPoint = tgtSCP;
        endControlPoint = tgtECP;
    }

    public override Action clone()
    {
        return new ActionBezierAbs(startPoint, startControlPoint, endControlPoint, endPoint, duration);
    }

    public override Action reverse()
    {
        return new ActionBezierAbs(endPoint, endControlPoint, startControlPoint, startPoint, duration);
    }

    public override void start()
    {
        base.start();
    }

    public override void stepInterval(float dt)
    {
        float t = timer / duration;
        Vector3 newPosition = (((-startPoint
            + 3 * (startControlPoint - endControlPoint) + endPoint) * t
            + (3 * (startPoint + endControlPoint) - 6 * startControlPoint)) * t +
            3 * (startControlPoint - startPoint)) * t + startPoint;
        target.gameObject.transform.position = newPosition;
    }
}