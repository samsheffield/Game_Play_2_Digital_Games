package;

import org.flixel.FlxG;
import org.flixel.FlxState;
import org.flixel.FlxGroup;
import org.flixel.FlxText;

class PlayState extends FlxState {

	public var bullets:FlxGroup;
	var enemies:FlxGroup; // Store Enemy objects in this FlxGroup
	var player:Player;

	var scoreText:FlxText;
	var score:Int;

	override public function create():Void {
		scoreText = new FlxText(0,0,FlxG.width,"Score: 0");
		scoreText.size = 20;
		scoreText.alignment = "center";
		add(scoreText);

		bullets = new FlxGroup();
		add(bullets);

		enemies = new FlxGroup();

		for (i in 0...8) {
			enemies.add(new Enemy1(20 + (i*80), 40)); // Add the Enemy objects to the enemies group
		}
		for (i in 0...8) {
			enemies.add(new Enemy2(20 + (i*80), 120)); // Add the Enemy objects to the enemies group
		}
		add(enemies);

		player = new Player(FlxG.width/2-20, FlxG.height-20);
		add(player);

		score = 0;

		FlxG.playMusic("BackgroundMusic");

		super.create();
	}
	
	override public function update():Void {
		FlxG.overlap(enemies, bullets, hitEnemy);
		super.update();
	}	

	public function hitEnemy(enemy:Enemy, bullet:Bullet):Void{
		score += enemy.points;
		scoreText.text = "Score: " + Std.string(score);

		enemy.kill();
		bullet.kill();
	}
}