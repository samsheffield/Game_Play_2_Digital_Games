package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class EnemyBullet extends FlxSprite {

	public var startX:Float;
	public var startY:Float;

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		loadGraphic("assets/bullets.png", true, false, 12, 24); // Loop, don't mirror, width, height
		addAnimation("loop",[0,1,2,3]); // Play frames 0-3 at 30 fps
		play("loop"); // Automatically loop
	}

	override public function update():Void {
		velocity.y = 300;

		if (y > FlxG.height){
			kill();
		}
		
		super.update();
	}
}