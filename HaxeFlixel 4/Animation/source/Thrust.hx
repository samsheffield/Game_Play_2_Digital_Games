package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Thrust extends FlxSprite {

	public function new():Void {
		super(-100,-100); // Hide off screen
		loadGraphic("assets/thrust.png", true, false, 12, 24); // Animation, don't mirror, width, height
		addAnimation("fire",[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15], 30, false); // Play frames 0-3 at 30 fps, no loop
		//addAnimation("loop",[0,1,2,3], 10); // Play frames at 10 fps
		addAnimation("idle", [16,17,18,19,18,17,16]); // Play frames at 30fps, looping
	}

	override public function update():Void {		
		super.update();
	}
}