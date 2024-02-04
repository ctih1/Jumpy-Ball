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
		GD.Print(player);
		Position = GeneratePosition();
		MoveAndSlide();
	}

	public Vector2 GeneratePosition() {
		minY = (int) Math.Round((double)(player.GetPosition().Y+GetWindow().Size.Y/2+100),0);
		maxY = (int) Math.Round((double)(player.GetPosition().Y+GetWindow().Size.Y/2+300));
		position = new Vector2(
			random.Next(enemyMargin,GetWindow().Size.X - enemyMargin), // x
			random.Next(minY,maxY) // y
		);
		position.Y = position.Y * -1;
		return position;
	}
}
