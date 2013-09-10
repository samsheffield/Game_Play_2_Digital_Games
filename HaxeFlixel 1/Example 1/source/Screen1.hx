package;

// We have to add the functionality we want to use from haxeFlixel. This is confusing at first, so just ignore for now
		
import org.flixel.FlxState;
import org.flixel.FlxG;	
import org.flixel.FlxText;

// A class is a type of object. Screen can do everything FlxState can do... and more! That's why we "extend" it.
class Screen1 extends FlxState {
	// Put variable declarations up here!

	// Variables start with the keyword var. After the variable name: the type of variable (data type). Data types in Haxe are typically capitalized.
	// This variable is called justPressed and it holds a Boolean value. Booleans are true or false.
	var justPressed:Bool;

	// To use text, we use a FlxText object
	var t:FlxText;

	// Variable which will hold a whole number (Int). 
	var presses:Int;

	// Function called when screen is created. Generally used to set things up
	override public function create():Void {

		// Set a background color. Color is a hexadecimal value: 0xAARRGGBB
		FlxG.bgColor = 0xff000000;

		// We need to create an "instance" of an object with the keyword new. 
		t = new FlxText(0,216,640,"0");

		// We can manipulate 
		t.size = 48;
		t.color = 0xff00ffff;
		t.alignment = "center"; // other options: "left" or "right"

		// Objects are added with the add(); function. This will allow them to be drawn to the screen.
		add(t);

		presses = 0;

		// Do everything else that FlxState normally does when created
		super.create();
	}
	
	// Function called every frame
	override public function update():Void {
		
		// Check if the mouse was clicked and put the result (true or false) into the variable justPressed
		justPressed = FlxG.mouse.justPressed();

		// If the mouse was clicked, do something. (Notice the ==. This means that we are comparing two things)
		if(justPressed == true){

			// add 1 to whatever presses currently is.
			presses++;

			// presses += 5; // You can also add more than 1 like this.
		}
		
		// Set the text property of t to score. We need to convert presses (Int) to a (String)!
		t.text = Std.string(presses);

		// Do everything which FlxState normally does every frame
		super.update();
	}	
}