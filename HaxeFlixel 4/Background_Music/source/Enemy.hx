package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Enemy extends FlxSprite {

	public var points:Int;

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(60, 60, 0xffff0000);
	}

	// Player1 does this every frame
	override public function update():Void {
		super.update();
	}
}