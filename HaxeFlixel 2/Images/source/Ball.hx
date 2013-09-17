package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Ball extends FlxSprite{

	public var directionX:Int;
	public var directionY:Int;

	public var speedX:Float;
	public var speedY:Float;
	public var done:Bool;

	// If we add the keyword public, we can change these vaiables from Screen1
	public var startX:Float;
	public var startY:Float;

	public function new():Void {
		startX = FlxG.width/2;
		startY = FlxG.height/2;

		super(startX, startY, "assets/ball.png");

		directionX = Std.int(FlxG.random()*2);
		if (directionX == 0){
			directionX = -1;
		}

		directionY = Std.int(FlxG.random()*2);
		if (directionY == 0){
			directionY = -1;
		}

		done = false;

		speedY = (FlxG.random()*600)-300;
		speedX = 200;
	}

	override public function update():Void {

		if(x > FlxG.width - width){
			done = true;
		}
		if (x < 0){
			done = true;
		}

		if(y > FlxG.height - height){
			directionY *= -1;
		}
		else if (y < 0){
			directionY *= -1;
		}
		
		velocity.x = speedX * directionX;
		velocity.y = speedY * directionY;

		super.update();
	}
}