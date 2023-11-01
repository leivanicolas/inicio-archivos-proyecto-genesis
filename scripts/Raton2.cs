using Godot;
using System;

public partial class Raton2 : CharacterBody2D
{
	private void OnArea2dAreaEntered(Area2D other)
	{
		GD.Print("Menos 1 vida");
	}
	private void OnArea2dBodyEntered(CharacterBody2D other)
	{
		GD.Print("Mobs muere");
		//QueueFree();
	}
}
