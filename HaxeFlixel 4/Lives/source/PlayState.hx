package;

import org.flixel.FlxG;
import org.flixel.FlxState;
import org.flixel.FlxGroup;

class PlayState extends FlxState {

	var player:Player;
	var enemy:Enemy;
	var playerLife:FlxGroup;
	public var bullets:FlxGroup;
	public var enemyBullets:FlxGroup;
	public var lThruster:Thrust;
	public var rThruster:Thrust;

	override public function create():Void {
		bullets = new FlxGroup();
		add(bullets);

		enemyBullets = new FlxGroup();
		add(enemyBullets);

		player = new Player(FlxG.width/2-20, FlxG.height-60);
		add(player);

		enemy = new Enemy(FlxG.width/2, 100);
		add(enemy);

		lThruster = new Thrust();
		add(lThruster);
		rThruster = new Thrust();
		add(rThruster);

		playerLife = new FlxGroup();
		for(i in 0...player.life){
			playerLife.add(new PlayerLife(i*18, 4));
		}
		add(playerLife);

		super.create();
	}
	
	override public function update():Void {
		FlxG.overlap(bullets,enemy, hitEnemy);
		FlxG.overlap(enemyBullets,player, hitPlayer);
		super.update();
	}	

	public function hitEnemy(b:Bullet, e:Enemy){
		b.kill();
		e.life--;
	}

	public function hitPlayer(eb:EnemyBullet, p:Player){
		playerLife.remove(playerLife.members[player.life-1]);
		eb.kill();
		p.life--;
	}

}