using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Game : Node2D
{
	TextureRect background;
	Player player;
	Enemy enemy;
	Score score;
	Vector2 newSize;
	Node newEnemy;
	List<Vector2> positions;
	int progressUntilNextGen;
	int lastGenerationHeight = 0;
	public override void _Ready() {
		background = GetNode<TextureRect>("Background");	
		player = GetNode<Player>("Player");
		enemy = GetNode<Enemy>("Enemy");
		
		score = GetNode<Score>("Score");

		GetTree().Root.SizeChanged += OnResize;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		background.Position = new Vector2(0,(player.Position.Y-GetWindow().Size.Y/2)-150);
		background.SetSize(GetWindow().Size*2);
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventScreenTouch screenTouch) {
			score.Text = ""+screenTouch.Position.X+","+screenTouch.Position.Y;
		} 
    }

    public override void _PhysicsProcess(double delta)
    {
		progressUntilNextGen = (int)(player.Position.Y*-1) - lastGenerationHeight;
        if(progressUntilNextGen>=player.positions.LastOrDefault(0)+50) {
			for(int i=0; i<15; i++) {
				newEnemy = enemy.Duplicate();
				AddChild(newEnemy);
			}
			lastGenerationHeight = (int)player.Position.Y;
		}
    }


    public void OnResize() {
		player.RePosition();
		score.RePosition();
		background.SetSize(GetWindow().Size);
	}
}
