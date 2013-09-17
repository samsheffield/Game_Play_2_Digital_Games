package;

import org.flixel.FlxG;
import org.flixel.FlxState;
import org.flixel.FlxText;

class Screen2 extends FlxState {

	var t:FlxText;

	override public function create():Void {
		t = new FlxText(0,220,640, "YOU LOSE!");
		t.size = 40;
		t.alignment = "center";
		add(t);

		super.create();
	}
	
	// Function called every frame
	override public function update():Void {
		super.update();
	}	
}