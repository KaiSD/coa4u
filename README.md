coa4u
=====
## Cocos2d-like Actions for Unity3d

Unity3d is a very good game engine. It's almost perfect for quick prototyping.
After switching from Cocos2D to Unity3d, i'm still missing just one cocos's feature - actions.
It's a great combination of simplicity and flexibility, and i haven't found the suitable replacement for it.
Since actions are quite simple, i implemented them myself.

### How to use

Just put the src folder into your assets folder.
Then attach the Actor.cs script to the object you want.
See the examples folder, there's a sample script there.

You can also subclass the Actor and add all the actions you want to the Start() method.

### Included actions (ready and WIP)

Base actions
- [x]  Sequence
- [x]  Parallel
- [x]  Repeat and Loop *implemented in one action*
- [ ]  Reverse

Interval actions
- [x]  MoveTo
- [x]  MoveBy
- [x]  RotateTo
- [x]  RotateBy
- [x]  ScaleTo
- [x]  ScaleBy
- [x]  TintBy
- [x]  Delay and RandomDelay *implemented in one action*
- [ ]  TintTo
- [ ]  FadeOut
- [ ]  FadeIn
- [ ]  FadeTo
- [ ]  JumpTo 
- [ ]  JumpBy
- [ ]  Bezier
- [ ]  Blink

Instant actions
- [x]  Place *renamed to SetPlace*
- [x]  CallFunc *renamed to SendMessage*
- [x]  Hide
- [x]  Show
- [x]  ToggleVisibility

### Some additional actions

Interval actions
- [ ]  SkewBy
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
