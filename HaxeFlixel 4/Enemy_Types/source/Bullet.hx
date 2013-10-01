// Basic bullet. Fires upward.

package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Bullet extends FlxSprite {

	public var startX:Float;
	public var startY:Float;

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(20, 20, 0xffffff00);
	}

	override public function update():Void {
		velocity.y = -300;

		if (y < -height){
			kill();
		}
		
		super.update();
	}
}