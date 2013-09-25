package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Player extends FlxSprite {

	public var startX:Float;
	public var startY:Float;

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(60, 20, 0xffffffff);
	}

	override public function update():Void {
		super.update();

		velocity.x = 0;

		if (FlxG.keys.LEFT == true){
			velocity.x = -300;
		}
		if (FlxG.keys.RIGHT == true){
			velocity.x = 300;
		}

		if(FlxG.keys.justPressed("SPACE") == true){

			// Play the sound with the id "Shoot" from Template.xml
			FlxG.play("Shoot");
			cast(FlxG.state, Screen1).bullets.add(new Bullet(x+20, y-20));
		}

		if (x < 0){
			x = 0;
		}
		if (x > FlxG.width-width){
			x = FlxG.width-width;
		}
	}
}