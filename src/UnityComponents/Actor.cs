using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour
{
    protected Action action;
    private bool paused = false;

    protected void Update()
    {
        if (paused || action == null)
            return;
        if (action.isRunning())
            action.step(Time.deltaTime);
    }

    public void AttachAction(Action tgtAction)
    {
        action = tgtAction;
        action.setActor(this);
        action.start();
    }

    public void StopAction()
    {
        action.stop();
        action = null;
    }

    public void PauseAction()
    {
        paused = true;
    }

    public void UnpauseAction()
    {
        paused = false;
    }

    public void SetTimeScale(float ts)
    {
        if (action is ActionInterval)
        {
            ((ActionInterval)action).setTimeScale(ts);
        }
    }
}
