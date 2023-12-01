using Godot;
using System;

public partial class MenuPrincipal : ColorRect
{
	
	public override void _Ready()
	{
		GetNode<Button>("CenterContainer/VBoxContainer/Play").Pressed +=
			() => GetNode<CargadorEscena>("/root/CargadorEscena").ChangeToScene("Level/level_2.tscn");
	}

	public void ExitGame()
	{
		GetTree().Quit();
	}
}
