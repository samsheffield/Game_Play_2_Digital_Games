package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Player1 extends FlxSprite {

	// If we add the keyword public, we can change these vaiables from Screen1
	public var startX:Float;
	public var startY:Float;

	// Player1 does this when created
	public function new():Void {

		// Starting positions
		startX = FlxG.width-20;
		startY = FlxG.height/2 - height/2;

		super(startX, startY);
		makeGraphic(20, 40, 0xffffffff);
	}

	// Player1 does this every frame
	override public function update():Void {
		
		// Not at bottom? See what happens when you move it...
		super.update();

		// Slow down when no button is pressed
		//drag.y = 200;

		velocity.y = 0;

		// Keyboard input
		if (FlxG.keys.UP == true){
			velocity.y = -300;
		}
		if (FlxG.keys.DOWN == true){
			velocity.y = 300;
		}

		// Restrict movement
		if (y < 0){
			y = 0;
		}
		if (y > FlxG.height-height){
			y = FlxG.height-height;
		}
	}
}