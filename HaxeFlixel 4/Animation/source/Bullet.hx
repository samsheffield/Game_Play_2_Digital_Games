// Basic bullet. Fires upward.

package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Bullet extends FlxSprite {

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		loadGraphic("assets/bullets.png", true, false, 12, 24); // Loop, don't mirror, width, height
		addAnimation("loop",[0,1,2,3]); // Play frames 0-3 at 30 fps
		//addAnimation("loop",[0,1,2,3], 10); // Play frames at 10 fps
		play("loop"); // Automatically loop
	}

	override public function update():Void {
		velocity.y = -300;

		if (y < -height){
			kill();
		}
		
		super.update();
	}
}