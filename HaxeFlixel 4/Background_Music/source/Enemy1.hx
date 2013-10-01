package ;

class Enemy1 extends Enemy {

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(60, 60, 0xff00ff00);
		points = 10;
	}

	// Player1 does this every frame
	override public function update():Void {
		super.update();
	}
}