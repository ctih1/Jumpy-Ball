using Godot;
using System;

public partial class Camera : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	Player player;
	Vector2 position;
	float acceleration;
	float lastPosition = 0f;
	public override void _Ready()
	{
		player = GetNode<Player>("../Player");
	}

	float Lerp(float firstFloat, float secondFloat, float by)
	{
		return firstFloat * (1 - by) + secondFloat * by;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		position = new Vector2(GetWindow().Size.X/2, Lerp(lastPosition, Position.Y,0.5f));
		Position = position;
		lastPosition = player.Position.Y;
	}
}
