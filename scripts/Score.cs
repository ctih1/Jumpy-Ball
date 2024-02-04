using Godot;
using System;

public partial class Score : Label
{
	// Called when the node enters the scene tree for the first time.
	Vector2 position;
	public override void _Ready()
	{
		RePosition();
	}

	public void RePosition() {
		SetSize(new Vector2(GetWindow().Size.X, 60));
		position = new Vector2(0, (GetWindow().Size.Y/2)-90);
		Position = position;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
