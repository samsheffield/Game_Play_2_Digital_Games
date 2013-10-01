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
	public var lThruster:Thrust;
	public var rThruster:Thrust;
	var totalEnemies:Int;

	override public function create():Void {
		bullets = new FlxGroup();
		add(bullets);

		totalEnemies = 6;
		enemies = new FlxGroup();

		for (i in 0...totalEnemies) {
			enemies.add(new Enemy(100 + (i*80), 40)); // Add the Enemy objects to the enemies group
		}
		add(enemies);

		player = new Player(FlxG.width/2-20, FlxG.height-60);
		add(player);

		lThruster = new Thrust();
		add(lThruster);
		rThruster = new Thrust();
		add(rThruster);

		Reg.score = 0;
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
			FlxG.switchState(new EndState());
		}

		enemy.kill();
		bullet.kill();
	}
}