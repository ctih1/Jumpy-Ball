using Godot;
using System;

public partial class Game : Node2D
{
	TextureRect background;
	Player player;
	Score score;
	Vector2 newSize;
	public override void _Ready() {
		background = GetNode<TextureRect>("Background");	
		player = GetNode<Player>("Player");
		score = GetNode<Score>("Score");
		GetTree().Root.SizeChanged += OnResize;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public void OnResize() {
		player.RePosition();
		score.RePosition();
		background.SetSize(GetWindow().Size);
	}
}
