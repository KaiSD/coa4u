using System;
using System.Collections.Generic;
using UnityEngine;

class ActionSendMessage : Action
{
    protected string message;
    protected object param;
    protected SendMessageOptions options = SendMessageOptions.DontRequireReceiver;

    public ActionSendMessage(string tgtMessage)
        : base()
    {
        message = tgtMessage;
    }

    public ActionSendMessage(string tgtMessage, object tgtParam)
        : base()
    {
        message = tgtMessage;
        param = tgtParam;
    }

    public ActionSendMessage(string tgtMessage, object tgtParam, SendMessageOptions tgtOptions)
        : base()
    {
        message = tgtMessage;
        param = tgtParam;
        options = tgtOptions;
    }

    public override void start()
    {
        base.start();
        if (param != null)
        {
            target.SendMessage(message, param);
        }
        else
        {
            target.SendMessage(message);
        }
    }
}