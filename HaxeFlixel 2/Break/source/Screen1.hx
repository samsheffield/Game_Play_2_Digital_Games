package;

import org.flixel.FlxG;
import org.flixel.FlxSprite;
import org.flixel.FlxState;
import org.flixel.FlxText;

class Screen1 extends FlxState {

	var ball:Ball;
	var p1:Player1;
	var p1Score:Int;
	var p1ScoreText:FlxText;
	var block1:Block;
	var block2:Block;
	var block3:Block;

	// Function called when screen is created. Generally used to set things up
	override public function create():Void {
		FlxG.bgColor = 0xff000000;

		p1Score = 0;

		p1ScoreText = new FlxText(0,0,640,"SCORE: 0");
		p1ScoreText.size = 20;
		p1ScoreText.alignment = "center";
		add(p1ScoreText);

		ball = new Ball();
		add(ball);

		p1 = new Player1();
		add(p1);

		// We can give our objects arguments. This would allow us to make multiple versions in different locations.
		block1 = new Block(0, 0);
		add(block1);

		block2 = new Block(20, 0);
		add(block2);

		block3 = new Block(40, 0);
		add(block3);

		super.create();
	}
	
	// Function called every frame
	override public function update():Void {
		if(FlxG.overlap(p1, ball) == true){
			ball.directionX = -1;
		}

		if(FlxG.overlap(block1, ball) == true){
			p1Score++;
			block1.kill(); // kill() removes FlxSprite objects
			ball.directionX *= -1;
		}
		if(FlxG.overlap(block2, ball) == true){
			p1Score++;
			block2.kill(); // kill() removes FlxSprite objects
			ball.directionX *= -1;
		}
		if(FlxG.overlap(block3, ball) == true){
			p1Score++;
			block3.kill(); // kill() removes FlxSprite objects
			ball.directionX *= -1;
		}

		if(ball.done == true){
			ball.x = ball.startX;
			ball.y = ball.startY;
			ball.directionX = 1;
			ball.done = false;
		}

		p1ScoreText.text = Std.string(p1Score);

		// Do everything which FlxState normally does every frame
		super.update();
	}	
}