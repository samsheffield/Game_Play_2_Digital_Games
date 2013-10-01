package ;

class Enemy2 extends Enemy {

	public function new(startX:Float, startY:Float):Void {
		super(startX, startY);
		makeGraphic(60, 60, 0xffff0000);
		points = 5;
	}

	override public function update():Void {
		super.update();
	}
}