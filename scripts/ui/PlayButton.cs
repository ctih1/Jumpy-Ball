using Godot;
using System;
using System.Numerics;

public partial class PlayButton : Godot.Button
{
	// Called when the node enters the scene tree for the first time.
	Godot.Button button;
	PackedScene gameScene;
	Godot.Vector2 position;

	public override void _Ready()
	{
		button = this;
		button.Pressed += this._Clicked;
		gameScene = GD.Load<PackedScene>("res://game.tscn");
		RePosition();
	}
	public void RePosition() {
		this.SetSize(new Godot.Vector2(GetWindow().Size.X, 100));
		position = new Godot.Vector2(0, GetWindow().Size.Y-250);
		Position = position;
	}

    public void _Clicked() {
		GetTree().ChangeSceneToPacked(gameScene);
	}

}
