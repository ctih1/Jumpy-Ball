using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	Vector2 position;
	Random random;
	Player player;
	private int enemyMargin = 50;
	private int minY;
	private int maxY;
	public override void _Ready()
	{
		random = new Random();
		player = GetNode<Player>("../Player");
		position = GeneratePosition();
	}

	public Vector2 GeneratePosition() {
		minY = player.GetValues();
		maxY = player.GetValues()+300;
		position = new Vector2(
			random.Next(enemyMargin,GetWindow().Size.X - enemyMargin), // x
			random.Next(minY,maxY) // y
		);
		player.SetValue((int)position.Y);
		position.Y = position.Y * -1;
		return position;
	}

	public override void _Process(double delta)
	{
		MoveAndSlide();
	}

	public override void _PhysicsProcess(double delta)
	{
		Position = position;
	}
}
