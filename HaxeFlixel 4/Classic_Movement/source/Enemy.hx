// Basic enemy

package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Enemy extends FlxSprite {

	public var directionX:Float;
	public var speedX:Float;
	var originalX:Float;
	var originalY:Float;

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(60, 60, 0xff00ff00);
		originalX = startX;
		originalY = startY;
		directionX = 1;
		speedX = 20;
		
	}

	override public function update():Void {
		super.update();

		velocity.y = 0;
		if (x > originalX + 80 || x < originalX -80){
			directionX *= -1;
			y += 20;
			speedX += 10;
		}
		
		velocity.x = speedX * directionX;
	}
}