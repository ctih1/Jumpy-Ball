using Godot;
using System;

public partial class mainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	PlayButton playButton;
	TextureRect background;
	public override void _Ready()
	{
		playButton = GetNode<PlayButton>("PlayButton");
		background = GetNode<TextureRect>("Backgroud");
		GetTree().Root.SizeChanged += OnResize;
	}
	public void OnResize() {
		playButton.RePosition();
		background.SetSize(GetWindow().Size);
	}
}
