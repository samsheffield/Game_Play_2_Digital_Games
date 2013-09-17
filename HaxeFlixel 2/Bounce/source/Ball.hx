package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Ball extends FlxSprite{

	var directionX:Int;
	var directionY:Int;

	var speedX:Float;
	var speedY:Float;

	public function new():Void {
		super(FlxG.width/2, FlxG.height/2);

		makeGraphic(20, 20, 0xff0000ff);

		directionX = Std.int(FlxG.random()*2);
		if (directionX == 0){
			directionX = -1;
		}

		directionY = Std.int(FlxG.random()*2);
		if (directionY == 0){
			directionY = -1;
		}

		speedX = 200;
		speedY = (FlxG.random()*600)-300;
	}

	override public function update():Void {

		// If the ball reaches the edge, reverse direction by multiplying it by -1
		if(x > FlxG.width - width){
			directionX *= -1;
		}
		if (x < 0){
			directionX *= -1;
		}

		if(y > FlxG.height - height){
			directionY *= -1;
		}
		if (y < 0){
			directionY *= -1;
		}
		
		velocity.x = speedX * directionX;
		velocity.y = speedY * directionY;

		super.update();
	}
}