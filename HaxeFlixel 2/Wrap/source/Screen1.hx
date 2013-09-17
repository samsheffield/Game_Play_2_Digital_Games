package;

import org.flixel.FlxG;
import org.flixel.FlxState;

class Screen1 extends FlxState {

	var ball:Ball;
	
	override public function create():Void {
		FlxG.bgColor = 0xff000000;

		ball = new Ball();
		add(ball);

		super.create();
	}
	
	override public function update():Void {
		super.update();
	}	
}