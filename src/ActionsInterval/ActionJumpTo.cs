using System;
using System.Collections.Generic;
using UnityEngine;

class ActionJumpTo : ActionSequence
{
    protected Vector3 point;
    float height;
    int jumps;

    public ActionJumpTo(Vector3 tgtPoint, float tgtHeight, int tgtJumps, float tgtDuration)
        : base(new Action[tgtJumps])
    {
        point = tgtPoint;
        jumps = tgtJumps;
        height = tgtHeight;
        duration = tgtDuration;
    }

    public ActionJumpTo(Vector2 tgtPoint, float tgtHeight, int tgtJumps, float tgtDuration)
        : this((Vector3)tgtPoint, tgtHeight, tgtJumps, tgtDuration)
    {
        is2d = true;
    }

    public override Action clone()
    {
        return new ActionJumpTo(point, height, jumps, duration);
    }

    public override void start()
    {
        float coeff = 1F / jumps;
        if (is2d)
            point.z = transform.position.z;
        Vector3 start = target.gameObject.transform.position;
        Vector3 end = (point - start) * coeff;
        Vector3 cp1 = Vector3.up * height;
        Vector3 cp2 = end + cp1;
        ActionBezierRel singleJump = new ActionBezierRel(cp1, cp2, end, duration * coeff);
        for (int i = 0; i < jumps; i++)
        {
            actions[i] = singleJump;
        }
        base.start();
    }
}