README.txt

Requested examples from students this past week, with the exception of player select and moving platforms, which we are probably better off discussing later in the semester.

Jumping example:
- Look at the changes to MovePlayer script; they are heavily commented.
- You will need to tag platforms as Ground for this to work properly
- Player has a child object with a trigger collider attached. This example is very basic, and will only work if there are no other trigger colliders on the Player. We'll discuss Layer Masks in the future.
- Added 3 states of animation (idle, walking, and jumping) to demonstrate how you might successfully trigger between the states from a script.
- Platform object in the scene has a child called Slippery Side with a Physics2D material attached to the collider. If you omit this, your player will stick to the sides of floating platforms.

Checkpoint example:
- Basic checkpoint system which resets the player's position to the highest ranked checkpoint when hit. It does not reset the scene or anything else.
- The system is extremely limited, but should work in simple situations. 
- This is a combined effort between Checkpoint, GameControl, and PlayerReset
- Checkpoints are just empty gameobjects with trigger colliders and Checkpoint scripts attached.

Mute background music example:
- Check BackgroundMusic script
- NOTE: You only have 2 inputs for this game, so make sure that this fits!