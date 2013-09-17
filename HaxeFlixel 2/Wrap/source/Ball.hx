package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Ball extends FlxSprite{

	// Variables to hold the direction the ball is moving (either -1 for left, or 1 for right)
	var directionX:Int;
	var directionY:Int;

	// How fast the ball is moving in each direction
	var speedX:Float;
	var speedY:Float;

	public function new():Void {
		//FlxG.width & FlxG.height can be used to get window dimensions
		super(FlxG.width/2, FlxG.height/2);

		makeGraphic(20, 20, 0xff0000ff);

		// FlxG.random() produces a float between 0.0 and 1.0, so we need to multiply random by a number representing our range
		// We want whole numbers, so we need to convert the random number to an Int
		directionX = Std.int(FlxG.random()*2);

		// Log can be used to debug messages in the console (Click ` to toggle console while game is running)
		FlxG.log("x direction: " + directionX);

		// We want a direction which is either -1 or 1, so we replace a 0 with -1
		if (directionX == 0){
			directionX = -1;
		}

		directionY = Std.int(FlxG.random()*2);
		if (directionY == 0){
			directionY = -1;
		}

		speedX = 200;

		// When combined with speedX, this creates angular movement
		speedY = (FlxG.random()*600)-300; // Random number between -300 and 300
	}

	override public function update():Void {
		// If the ball exceeds the window boundaries, we set it to the opposite side of the window
		if(x > FlxG.width){
			x = 0;
		}
		if (x < -width){
			x = FlxG.width;
		}

		if(y > FlxG.height){
			y = 0;
		}
		if (y < -height){
			y = FlxG.height;
		}

		// Velocity is the speed multiplied by the direction
		velocity.x = speedX * directionX;
		velocity.y = speedY * directionY;

		super.update();
	}
}