package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Block extends FlxSprite {

	// We can give our objects arguments like this
	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(20, FlxG.height, 0xff00ff00);
	}

	override public function update():Void {
		super.update();
	}
}