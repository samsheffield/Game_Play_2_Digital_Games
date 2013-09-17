package;

import org.flixel.FlxG;
import org.flixel.FlxSprite;
import org.flixel.FlxState;
import org.flixel.FlxText;

class Screen1 extends FlxState {

	var ball:Ball;
	var p1:Player1;
	var p1ScoreText:FlxText;
	var p1Score:Int;
	var bgImage:FlxSprite;

	// Function called when screen is created. Generally used to set things up
	override public function create():Void {
		bgImage = new FlxSprite(0,0,"assets/bgImage.png");
		add(bgImage);

		p1Score = 0;

		p1ScoreText = new FlxText(0,0,640,"SCORE: 0");
		p1ScoreText.size = 20;
		p1ScoreText.alignment = "center";
		add(p1ScoreText);

		ball = new Ball();
		add(ball);

		p1 = new Player1();
		add(p1);

		super.create();
	}
	
	// Function called every frame
	override public function update():Void {
		if(FlxG.overlap(p1, ball) == true){
			ball.directionX = -1;
		}

		if(ball.done == true){
			if(ball.x < 0){
				p1Score++;
			}
			else{
				p1Score--;
			}

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