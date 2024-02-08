using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Player : CharacterBody2D
{
    Vector2 position;
    [Export]
    public float JumpForce = 8f;
    [Export]
    public float downForceModifier = 0.01f;
    [Export]
    public float downForce = 4.1f;
    [Export]
    public int playerMargin = 50;
    private Label tap;
    private float velY;
    private bool started = false;
    private bool clickDown = false;
    private Vector2 mousePos;
    float targetAngle;
    public List<int> positions;

    public override void _Ready() {
        RePosition();
        positions = new List<int>(0);
        tap = GetNode<Label>("../Tap");
    }   
    public void RePosition() {
        position = new Vector2(GetWindow().Size.X / 2, GetWindow().Size.Y / 2);
        Position = position;
    }

    public Vector2 GetPosition() {
        return Position;
    }

    public void SetValue(int y) {
        positions.Clear();
        positions.Add(y+300);
    }

    public int GetValues() {
        return positions.LastOrDefault(15);
    }

    public override void _Process(double delta)
    {
        MoveAndSlide();
    }
    public override void _PhysicsProcess(double delta) {   
        if(Input.IsActionPressed("jump") && !clickDown) {
            velY = 0f;
            velY += JumpForce;
            clickDown = true;
            if(!started) {
                started=true;
                tap.Free();
            }
            targetAngle = GetWindow().GetMousePosition().X-Position.X;
        }
        else if(started) {velY -= downForce*downForceModifier;}
        if(Input.IsActionJustReleased("jump")&&clickDown) {
            clickDown = false;
        }
        if(position.X>GetWindow().Size.X-playerMargin||position.X<=0+playerMargin) {
            targetAngle = targetAngle*-1;
        }
        position.X = position.X - targetAngle/25;
        position.Y -= velY*(float)delta;
        Position = position;
        
    }

    internal void SetValue(double v)
    {
        throw new NotImplementedException();
    }

}
