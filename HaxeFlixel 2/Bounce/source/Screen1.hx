package;

import org.flixel.FlxG;
import org.flixel.FlxSprite;
import org.flixel.FlxState;

class Screen1 extends FlxState {

	var ball:Ball;

	// Function called when screen is created. Generally used to set things up
	override public function create():Void {
		FlxG.bgColor = 0xff000000;

		ball = new Ball();
		add(ball);

		super.create();
	}
	
	// Function called every frame
	override public function update():Void {
		// Do everything which FlxState normally does every frame
		super.update();
	}	
}