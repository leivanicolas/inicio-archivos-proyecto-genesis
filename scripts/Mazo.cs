using Godot;
using System;

public partial class Mazo : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnnBodyEntered(CharacterBody2D body)
	{
		if(body.Name == "Player")
		{
			GD.Print("Le pegue al player");
		}
	}
}
