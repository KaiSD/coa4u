using System;
using System.Collections.Generic;
using UnityEngine;

class ActionLog : Action
{
    string message;

    public ActionLog(string tgtMessage)
        : base()
    {
        message = tgtMessage;
    }

    public override void start()
    {
        base.start();
        Debug.Log(message);
    }
}