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
    protected ActionInstant action;
    private bool paused = false;
    protected Vector3 angles1prev = Vector3.zero;
    protected Vector3 angles2prev = Vector3.zero;
    protected const float coeff = Mathf.PI / 180;
    protected Vector3[] initialState;
    [HideInInspector]
    public Transform transformCached;
    [HideInInspector]
    public Renderer rendererCached;
    [HideInInspector]
    public Mesh meshCached;
    [HideInInspector]
    public Vector3 skewAngles1;
    [HideInInspector]
    public Vector3 skewAngles2;

    /// <summary>
    /// This method is called when the script instance is being loaded.
    /// </summary>
    protected void Awake()
    {
        transformCached = gameObject.transform;
        rendererCached = gameObject.renderer;

        Component component = gameObject.GetComponent<MeshFilter>();
        if (component != null)
        {
            meshCached = ((MeshFilter)component).mesh;
            initialState = meshCached.vertices;
        }
    }

    /// <summary>
    /// This method is called at every frame update.
    /// </summary>
    protected void Update()
    {
        if (paused || action == null)
            return;
        if (action.running)
            action.step(Time.deltaTime);
        if (skewAngles1 != angles1prev || skewAngles2 != angles2prev)
            updateSkew();
    }

    /// <summary>
    /// Updates the skew for the mesh.
    /// </summary>
    void updateSkew()
    {
        if (meshCached == null)
            return;

        Matrix4x4 m = Matrix4x4.zero;
        m[0, 0] = 1;
        m[1, 1] = 1;
        m[2, 2] = 1;
        m[3, 3] = 1;
        m[0, 1] = Mathf.Tan(skewAngles1.x * coeff); // skewing in xy
        m[0, 2] = Mathf.Tan(skewAngles2.x * coeff); // skewing in xz
        m[1, 0] = Mathf.Tan(skewAngles1.y * coeff); // skewing in yx
        m[1, 2] = Mathf.Tan(skewAngles2.y * coeff); // skewing in yz
        m[2, 0] = Mathf.Tan(skewAngles1.z * coeff); // skewing in zx
        m[2, 1] = Mathf.Tan(skewAngles2.z * coeff); // skewing in zy

        Vector3[] verts = new Vector3[initialState.Length];
        int i = 0;
        while (i < verts.Length)
        {
            verts[i] = m.MultiplyPoint3x4(initialState[i]);
            i++;
        }

        meshCached.vertices = verts;
        angles1prev = skewAngles1;
        angles2prev = skewAngles2;
    }

    /// <summary>
    /// Attaches and starts the action.
    /// </summary>
    public void AttachAction(ActionInstant tgtAction)
    {
        if (action != null)
        {
            action.stop();
        }
        action = tgtAction;
        action.setActor(this);
        action.start();
    }

    /// <summary>
    /// Stops all running actions for this actor.
    /// </summary>
    public void StopAction()
    {
        if (action == null)
            return;
        if (action.running)
            action.stop();
        action = null;
    }

    /// <summary>
    /// Pauses actions for this actor.
    /// </summary>
    public void PauseAction()
    {
        paused = true;
    }

    /// <summary>
    /// Unpauses actions for this actor.
    /// </summary>
    public void UnpauseAction()
    {
        paused = false;
    }

    /// <summary>
    /// Sets the timescale for current action.
    /// </summary>
    public void SetTimeScale(float ts)
    {
        if (action is ActionInterval)
        {
            ((ActionInterval)action).setTimeScale(ts);
        }
    }

    /// <summary>
    /// Adds method to cache to speed-up the ActionSendMessage.
    /// </summary>
    public void AddMethodToCache(Action method)
    {
        methodsCache.Add(method.Method.Name, new MethodHolder(method));
    }

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


    public void ReceiveMessage(string key, object param = null, SendMessageOptions options = SendMessageOptions.DontRequireReceiver)
    {
        if (methodsCache.ContainsKey(key))
        {
            if (param == null)
                methodsCache[key].run();
            else
                methodsCache[key].run(param);
        }
        else
        {
            gameObject.SendMessage(key, param, options);
        }
    }
}
