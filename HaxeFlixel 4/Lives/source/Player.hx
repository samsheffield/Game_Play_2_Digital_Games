package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Player extends FlxSprite {

	var currentState:PlayState;
	public var life:Int;
	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		loadGraphic("assets/ships.png", true, false, 32, 32); // TRUE indicates that it is an animation. FALSE indicates not to allow reversing facing direction. Cell width, cell height
		addAnimation("idle_good", [0]);
		addAnimation("left_good", [1]);
		addAnimation("right_good", [2]);
		addAnimation("idle_fair", [3]);
		addAnimation("left_fair", [4]);
		addAnimation("right_fair", [5]);
		addAnimation("idle_poor", [6]);
		addAnimation("left_poor", [7]);
		addAnimation("right_poor", [8]);

		currentState = cast(FlxG.state, PlayState);
		life = 3;
	}

	override public function update():Void {
		super.update();

		
		currentState.lThruster.x = x;
		currentState.lThruster.y = y + height;

		currentState.rThruster.x = x + 20;
		currentState.rThruster.y = y + height;

		velocity.x = 0;

		// Keyboard input
		if (FlxG.keys.LEFT == true){
			velocity.x = -100;
			if(life == 3){
				play("left_good");
			}
			else if(life == 2){
				play("left_fair");
			}
			else if(life == 1){
				play("left_poor");
			}
			currentState.lThruster.play("idle");
			currentState.rThruster.play("fire");
		} 
		else if (FlxG.keys.RIGHT == true){
			velocity.x = 100;
			if(life == 3){
				play("right_good");
			}
			else if(life == 2){
				play("right_fair");
			}
			else if(life == 1){
				play("right_poor");
			}
			currentState.rThruster.play("idle");
			currentState.lThruster.play("fire");
		}
		else {
			if(life == 3){
				play("idle_good");
			}
			else if(life == 2){
				play("idle_fair");
			}
			else if(life == 1){
				play("idle_poor");
			}
			currentState.lThruster.play("idle");
			currentState.rThruster.play("idle");
		}

		if(life == 0){
			kill();
			currentState.lThruster.kill();
			currentState.rThruster.kill();
		}

		if(FlxG.keys.justPressed("SPACE") == true){
			currentState.bullets.add(new Bullet(x+9, y-20));
		}

		// Restrict movement
		if (x < 0){
			x = 0;
		}
		if (x > FlxG.width-width){
			x = FlxG.width-width;
		}
	}
}