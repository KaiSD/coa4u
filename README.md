coa4u
=====
## Cocos2d-like Actions for Unity3d

Unity3d is a very good game engine. It's almost perfect for quick prototyping.
After switching from Cocos2D to Unity3d, i'm still missing just one cocos's feature - actions.
It's a great combination of simplicity and flexibility, and i haven't found the suitable replacement for it.
Since actions are quite simple, i implemented them myself.

### How to use

1. Place the coa4u folder from Assets/scripts in your Assets/scripts folder.
2. Then attach the Actor.cs script to the object you want.
3. See the ActorSampleActions.cs class, if you need examples.

You can also add actions on the fly, by using the AttachAction method of the Actor class.

### Included actions
All actions are capable to work both in 3D (use Vector3) and 2D (use Vector2) scenes.

Base actions
- [x]  Sequence
- [x]  Parallel
- [x]  Repeat and Loop *implemented in one action*

*Every reversable action has a reverse() method. So, no plans for Reverse action right now.*

Interval actions
- [x]  Delay and RandomDelay *implemented in one action*
- [x]  MoveTo
- [x]  MoveBy
- [x]  RotateTo
- [x]  RotateBy
- [x]  ScaleTo
- [x]  ScaleBy
- [x]  BezierAbs
- [x]  BezierRel
- [x]  JumpTo *uses Bezier action to move the object*
- [x]  JumpBy *uses Bezier action to move the object*
- [x]  Blink

*if you want to manipulate alpha with the following actions, your material should support transparency (i.e. use Transparent shader)*
- [x]  TintBy 
- [x]  TintTo
- [x]  FadeOut
- [x]  FadeIn
- [x]  FadeTo
- [x]  FadeBy

Instant actions
- [x]  Place *renamed to SetPlace*
- [x]  CallFunc *renamed to SendMessage*
- [x]  Hide
- [x]  Show
- [x]  ToggleVisibility

There's no plans for 3DGrid actions. You can use the 3D actions instead.

### Some additional actions
Base actions
- [x] Random - randomly choises and does one action from the given list.

Instant actions
- [x] SetRotation - instantly rotates the object to the given euler angles.
- [x] SetTint - instantly tints the object to the given color.
- [x] SetDirection - instantly rotates the object to look at the given actor.
- [x] Stop - stops all actions for this object.

### Future plans
No future plans.

There were some ideas (you can find in coa4uext), but no plans to develop them further.

## License
Just like Cocos2D, this code licensed under the [MIT License](http://en.wikipedia.org/wiki/MIT_License)