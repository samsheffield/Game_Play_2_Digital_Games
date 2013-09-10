package;

// We have to add the functionality we want to use from haxeFlixel. This is confusing at first, so just ignore for now
		
import org.flixel.FlxState;
import org.flixel.FlxG;	
import org.flixel.FlxText;

// A class is a type of object. Screen can do everything FlxState can do... and more! That's why we "extend" it.
class Screen1 extends FlxState {

	// To use text, we use a FlxText object
	var t:FlxText;

	// Variable which will hold a decimal number (Float). 
	var counter:Float;

	// Player objects
	var player1:Player1;
	var player2:Player2;

	// Function called when screen is created. Generally used to set things up
	override public function create():Void {

		// Set a background color. Color is a hexadecimal value: 0xAARRGGBB
		FlxG.bgColor = 0xff000000;

		// We need to create an "instance" of an object with the keyword new. 
		t = new FlxText(0,216,640,"0");

		// We can manipulate t's properties
		t.size = 48;
		t.color = 0xff00ffff;
		t.alignment = "center"; // other options: "left" or "right"

		// Objects are added with the add(); function. This will allow them to be drawn to the screen.
		add(t);

		// Start the counter at 20
		counter = 20;

		player1 = new Player1();
		add(player1);

		player2 = new Player2();
		add(player2);

		// Do everything else that FlxState normally does when created
		super.create();
	}
	
	// Function called every frame
	override public function update():Void {
		
		// Subtract 1 from the counter every second
		counter -= FlxG.elapsed;

		// After counter has reached 0, the timer will reset and players will reset location.
		if (counter < 0){
			counter = 20;

			player1.x = player1.startX;
			player1.y = player1.startY;

			player2.x = player2.startX;
			player2.y = player2.startY;
		}


		if(FlxG.overlap(player1, player2) == true){
			// Add to score here!
		}
		
		// Set the text property of t to score. We need to convert presses (Int) to a (String)!
		t.text = Std.string(Std.int(counter));

		// Do everything which FlxState normally does every frame
		super.update();
	}	
}