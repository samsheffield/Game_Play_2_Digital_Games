package ;

class Enemy2 extends Enemy {

	public function new(startX:Float, startY:Float):Void {
		super(startX+10, startY);
		makeGraphic(40, 40, 0xffff0000);
		points = 5;
	}

	// Player1 does this every frame
	override public function update():Void {
		super.update();
	}
}