using UnityEngine;
using System.Collections;

public class SampleActions : MonoBehaviour
{
    public void Start()
    {
        Action seq = new ActionRepeat (new ActionSequence(new Action[] 
        {
            new ActionFadeIn(2),
            new ActionParallel(new Action[] {
                new ActionMoveBy(new Vector3(10, 10, 0), 1),
                new ActionRotateBy(new Vector3(90, 0, 0), 1),
                new ActionTintBy(new Vector4(-50, 50, -150), 1)
            }),
            new ActionScaleBy(new Vector3(2, 2, 1), 1),
            new ActionScaleBy(new Vector3(0.5F, 0.5F, 2), 1),
            new ActionDelay(1),
            new ActionRepeat(new ActionSequence(new Action[] {
                new ActionHide(),
                new ActionDelay(0F, 0.2F),
                new ActionShow(),
                new ActionDelay(0F, 0.2F),
            }), 5),
            new ActionDelay(1),
            new ActionJumpBy(new Vector3(-10, 0, 0), 1, 4, 1),
            new ActionJumpTo(new Vector3(10, 10, 10), 1, 3, 1),
            new ActionJumpBy(new Vector3(-10, 0, 0), 1, 2, 1),
            new ActionDelay(0.5F),
            new ActionBezierRel(new Vector3 (5, 0, 0), new Vector3(5, -10, 0), new Vector3 (0, -10, 0), 2),
            new ActionScaleTo(new Vector3(2, 2, 2), 1),
            new ActionRotateTo(new Vector3(0, 0, 0), 1),
            new ActionBlink(2, 1),
            new ActionFadeOut(2),
            new ActionSetTint(new Vector4(67, 105, 181))
        }), 5);
        gameObject.SendMessage("AttachAction", seq);
    }
}
