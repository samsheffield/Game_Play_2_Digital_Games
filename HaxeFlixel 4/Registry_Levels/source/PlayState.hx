// PlayState is our main game.

package;

import org.flixel.FlxG;
import org.flixel.FlxState;
import org.flixel.FlxGroup;
import org.flixel.FlxText;

class PlayState extends FlxState {

	public var bullets:FlxGroup;

	var enemies:FlxGroup;
	var player:Player;
	var scoreText:FlxText;

	var totalEnemies:Int;

	override public function create():Void {
		bullets = new FlxGroup();
		add(bullets);

		totalEnemies = 18;
		enemies = new FlxGroup();

		for (x in 0...6) {
			for (y in 0...3){
				enemies.add(new Enemy(100 + (x*80), 40 + (y*80))); 
			}
		}
		add(enemies);

		player = new Player(FlxG.width/2-20, FlxG.height-20);
		add(player);

		scoreText = new FlxText(0,0,FlxG.width,"Score: " + Std.string(Reg.score));
		scoreText.size = 20;
		scoreText.alignment = "center";
		add(scoreText);

		super.create();
	}
	
	override public function update():Void {
		FlxG.overlap(enemies, bullets, hitEnemy);
		super.update();
	}	

	public function hitEnemy(enemy:Enemy, bullet:Bullet):Void{
		FlxG.play("Explode");
		Reg.score++;
		scoreText.text = "Score: " + Std.string(Reg.score);

		totalEnemies--;
		if (totalEnemies == 0){
			Reg.level++;
			FlxG.switchState(new PlayState());
		}

		enemy.kill();
		bullet.kill();
	}
}