using System;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    protected Actor target;
    public float duration = 0;
    protected Transform transform;
    protected Renderer renderer;
    protected bool is2d = false;

    public Action()
    {
    }

    public virtual Action clone()
    {
        return new Action();
    }

    public virtual bool isRunning()
    {
        return false;
    }

    /// <summary>
    /// This method is called at the action start. Usable for instant and interval actions.
    /// </summary>
    public virtual Action reverse()
    {
        throw new Exception("Can reverse only the reversable interval actions");
    }

    /// <summary>
    /// This method is called at the action start. Usable for instant and interval actions.
    /// </summary>
    public virtual void start()
    {
        if (target == null)
            throw new Exception("Can start the action only after it's atached to the actor");
        transform = target.gameObject.transform;
        renderer = target.gameObject.renderer;
    }

    /// <summary>
    /// This method is called at every frame update. Not usable for instant actions.
    /// </summary>
    public virtual void step(float dt)
    {
        if (target == null)
            throw new Exception("Can update the action only after it's atached to the actor");
    }

    /// <summary>
    /// This method is called after the interval action is stopped. Not usable for instant actions.
    /// </summary>
    public virtual void stop()
    {
        if (target == null)
            throw new Exception("Can stop the action only after it's atached to the actor");
    }

    public void setActor(Actor actor)
    {
        target = actor;
    }

    public virtual float dtr
    {
        get
        {
            return 0;
        }

        protected set
        {
        }
    }

}