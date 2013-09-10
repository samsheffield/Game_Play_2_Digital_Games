package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Player1 extends FlxSprite {

	// If we add the public keyword, we can change these vaiables from Screen1
	public var startX:Int;
	public var startY:Int;

	// FlxSprite uses a different function when created
	public function new() {

		// Starting positions
		startX = 20;
		startY = 20;

		// We set the x and y position of the FlxSprite. Do this before makeGraphic!
		super(startX, startY);

		// This function is used to create a simple rectangle
		makeGraphic(10, 20, 0xffff0000);
	}

	override public function update():Void {
		
		// FlxSprite's velocity property controls speed in either x or y direction
		// Setting this back to 0 stops player when no input is received
		velocity.x = 0;
		velocity.y = 0;

		// Keyboard input
		if (FlxG.keys.A == true){
			velocity.x -= 100;
		}
		if (FlxG.keys.D == true){
			velocity.x += 100;
		}
		if (FlxG.keys.W == true){
			velocity.y -= 100;
		}
		if (FlxG.keys.S == true){
			velocity.y += 100;
		}
		
		// Do the normal stuff FlxSprite does
		super.update();

	}
}