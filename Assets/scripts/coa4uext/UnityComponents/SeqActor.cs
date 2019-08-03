using System;
using System.Collections.Generic;
using UnityEngine;
using coa4u;

[System.Serializable]
public class SeqActor : Actor
{
    protected State[] states;
    protected int index;
    protected List<int> stateLog = new List<int>();
    protected ActionInstant currentStateAction;

    public void SetState(int idx)
    {
        if (idx < states.Length)
        {
            stateLog.Add(idx);
            index = idx;
            if (currentStateAction != null)
                RemoveAction(currentStateAction);
            currentStateAction = states[idx].action;
            AttachAction(currentStateAction);
        }
        else
        {
            throw new Exception("Actor doesn't have the state " + idx.ToString());
        }
    }

    public void SetState(string name)
    {
        SetState(Array.FindIndex<State>(states, x => x.name == name));
    }

    public int currentStateIndex
    {
        get
        {
            return index;
        }
    }

    public string currentStateName
    {
        get
        {
            return states[index].name;
        }
    }

    public List<int> log
    {
        get
        {
            return stateLog;
        }
    }
}
