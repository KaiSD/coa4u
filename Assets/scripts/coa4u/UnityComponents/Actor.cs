using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using coa4u;

/// <summary>
/// The default Actor class for the Action system.
/// </summary>
public class Actor : MonoBehaviour
{
    protected Dictionary<string, MethodHolder> methodsCache = new Dictionary<string, MethodHolder>();
    protected List<ActionInstant> actions = new List<ActionInstant>();
    protected List<ActionInstant> actionsToDelete = new List<ActionInstant>();
    protected List<ActionInstant> actionsToAdd = new List<ActionInstant>();
    private bool paused = false;
    private bool running = false;
    protected const float coeff = Mathf.PI / 180;
    [HideInInspector]
    public Transform transformCached;
    [HideInInspector]
    public Renderer rendererCached;

    /// <summary>
    /// This method is called when the script instance is being loaded.
    /// </summary>
    protected void Awake()
    {
        transformCached = gameObject.transform;
        rendererCached = gameObject.renderer;
    }

    /// <summary>
    /// This method is called at every frame update.
    /// </summary>
    protected void Update()
    {
        if (paused)
            return;
        
        foreach (ActionInstant action in actions)
        {
            if (action.running)
                action.StepTimer(Time.deltaTime);
            if (!action.running)
                actionsToDelete.Add(action);
        }
    }

    /// <summary>
    /// This method is called after the every frame update.
    /// </summary>
    protected void LateUpdate()
    {
        foreach (ActionInstant action in actionsToAdd)
        {
            if (action.running)
                actions.Add(action);
        }
        foreach (ActionInstant action in actionsToDelete)
        {
            if (!action.running)
                actions.Remove(action);
        }
        actionsToDelete.Clear();
        actionsToAdd.Clear();
        running = actions.Count > 0;
    }

    /// <summary>
    /// Attaches and starts the action.
    /// </summary>
    public void AttachAction(ActionInstant targetAction)
    {
        targetAction.SetActor(this);
        targetAction.Start();
        if (targetAction.running)
        {
            actionsToAdd.Add(targetAction);
        }
    }

    /// <summary>
    /// Stopes and removes the given action.
    /// </summary>
    public void RemoveAction(ActionInstant targetAction)
    {
        if (targetAction.running)
            targetAction.Stop();
    }

    /// <summary>
    /// Stops all running actions for this actor.
    /// </summary>
    public void StopAllActions()
    {
        foreach (ActionInstant action in actions)
        {
            if (action.running &! action.unstopable)
                action.Stop();
        }
    }

    /// <summary>
    /// Pauses actions for this actor.
    /// </summary>
    public void PauseActions()
    {
        paused = true;
    }

    /// <summary>
    /// Unpauses actions for this actor.
    /// </summary>
    public void UnpauseActions()
    {
        paused = false;
    }

    /// <summary>
    /// Sets the timescale for current action.
    /// </summary>
    public void SetTimeScale(float ts)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            ActionInstant action = actions[i];
            if (action is ActionInterval)
            {
                ((ActionInterval)action).SetTimeScale(ts);
            }
        }
    }

    /// <summary>
    /// Adds method to cache to speed-up the ActionSendMessage.
    /// </summary>
    public void AddMethodToCache(Action method)
    {
        methodsCache.Add(method.Method.Name, new MethodHolder(method));
    }

    /// <summary>
    /// Adds method to cache to speed-up the ActionSendMessage.
    /// </summary>
    public void AddMethodToCache<T>(Action<T> method)
    {
        methodsCache.Add(method.Method.Name, new MethodHolder<T>(method));
    }

    /// <summary>
    /// Adds method from cache.
    /// </summary>
    public void RemoveMethodFromCache(string key)
    {
        if (methodsCache.ContainsKey(key))
        {
            methodsCache.Remove(key);
        }
        else
        {
            throw new Exception("Method " + key + " not found in cache.");
        }
    }

    /// <summary>
    /// Proxy method to receive messages. WARNING: If the message can be handled by the actor, it will be handled and will not be passed to the Unity3D gameobject.
    /// </summary>
    public void ReceiveMessage(string key, object param = null, SendMessageOptions options = SendMessageOptions.DontRequireReceiver)
    {
        if (methodsCache.ContainsKey(key))
        {
            if (param == null)
                methodsCache[key].Run();
            else
                methodsCache[key].Run(param);
        }
        else
        {
            gameObject.SendMessage(key, param, options);
        }
    }

    /// <summary>
    /// Shows if the actor has any running actions.
    /// </summary>
    public bool hasRunningActions
    {
        get
        {
            return running;
        }
    }
}
