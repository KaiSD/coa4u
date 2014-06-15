using UnityEngine;
using System.Collections;

public class SampleActions : MonoBehaviour
{
    public void Start()
    {
        Action seq = new ActionRepeat (new ActionSequence(new Action[] 
        {
            new ActionTintBy(new Vector4(-50,50,-50,-50),1),
            new ActionParallel(new Action[] {
                new ActionMoveBy(new Vector3(10, 0, 0), 1),
                new ActionMoveBy(new Vector3(0, 10, 0), 1),
  //              new ActionRotateBy(new Vector3(90, 0, 0), 1)
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
            new ActionMoveBy(new Vector3(-10, 0, 0), 1),
            new ActionDelay(0.5F),
            new ActionMoveTo(new Vector3(0, 0, 10), 1),
            new ActionScaleTo(new Vector3(2, 2, 2), 1),
            new ActionRotateTo(new Vector3(0, 0, 0), 1),
            new ActionTintBy(new Vector4(50,-50,50,50),3)
        }), 5);
        gameObject.SendMessage("AttachAction", seq);
    }
}
