using System;
using System.Collections.Generic;
using UnityEngine;

class ActionJumpBy : ActionSequence
{
    protected Vector3 point;
    float height;
    int jumps;

    public ActionJumpBy(Vector3 tgtPoint, float tgtHeight, int tgtJumps, float tgtDuration)
        : base(new Action[tgtJumps])
    {
        point = tgtPoint;
        jumps = tgtJumps;
        height = tgtHeight;
        duration = tgtDuration;
    }

    public override Action clone()
    {
        return new ActionJumpBy(point, height, jumps, duration);
    }

    public override Action reverse()
    {
        return new ActionJumpBy(-point, height, jumps, duration);
    }

    public override void start()
    {
        float coeff = 1F / jumps;
        Vector3 end = point * coeff;
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