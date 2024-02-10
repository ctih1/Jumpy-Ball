using Godot;
using System;

public partial class Score : Label
{
	// Called when the node enters the scene tree for the first time.
	Vector2 position;
	Player player;
	public override void _Ready()
	{
		RePosition();
	}

	public void RePosition() {
		SetSize(new Vector2(GetWindow().Size.X, 60));
		position = new Vector2(0, (GetWindow().Size.Y/2)-90);
		Position = position;
		player = GetNode<Player>("../Player");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		position.Y = player.Position.Y;
		Position = position;
		//Text = Math.Round((player.Position.Y / 100)*-1,0).ToString();
	}
}
