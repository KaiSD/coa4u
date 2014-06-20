coa4u
=====
## Cocos2d-like Actions for Unity3d

Unity3d is a very good game engine. It's almost perfect for quick prototyping.
After switching from Cocos2D to Unity3d, i'm still missing just one cocos's feature - actions.
It's a great combination of simplicity and flexibility, and i haven't found the suitable replacement for it.
Since actions are quite simple, i implemented them myself.

### How to use

 1. Put the src folder into your assets folder.
Then attach the Actor.cs script to the object you want.
See the examples folder, there's a sample script there.

You can also subclass the Actor and add all the actions you want to the Start() method.

### Included actions (ready and WIP) 
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
- [x] Random *Randomly choises and does one action from the given list.*

Interval actions
*These two actions requires the using of MeshActor script instead of Actor.*
- [x]  SkewBy
- [ ]  SkewTo

Instant actions
- [x] SetRotation
- [x] SetTint

### Future plans
After completing these actions, i'm going to add some more to the list.

## License
Just like Cocos2D, this code licensed under the [MIT License](http://en.wikipedia.org/wiki/MIT_License)

## Help and donations
I'm not doing it to make profit, but if you want, [you can send me a couple of bucks via PayPal](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Z64675TKXFRFU).

Also, if you'll write some action based on mine, feel free to send it to me, if you want me to add it to the library. I'll put your name on this page.
