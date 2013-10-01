package ;

import org.flixel.FlxG;
import org.flixel.FlxSprite;

class Enemy extends FlxSprite {

	public var life:Int;
	var bulletTimer:Float;
	var currentState:PlayState;

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		loadGraphic("assets/enemy.png",true,false,64,64);
		addAnimation("good",[0,1],15);
		addAnimation("fair",[2,3],15);
		addAnimation("poor",[4,5],15);
		currentState = cast(FlxG.state, PlayState);
		life = 3;
		bulletTimer = 3;
	}

	// Player1 does this every frame
	override public function update():Void {
		if(life == 3){
			play("good");
		}
		else if(life == 2){
			play("fair");
		}
		else if(life == 1){
			play("poor");
		}
		else{
			kill();
		}

		bulletTimer -= FlxG.elapsed;

		if(bulletTimer < 0){
			currentState.enemyBullets.add(new EnemyBullet(x+26, y+height));
			bulletTimer = 3;
		}

		super.update();
	}
}