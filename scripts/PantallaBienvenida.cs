using Godot;
using System;

public partial class PantallaBienvenida : ColorRect
{
	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout +=
			() => GetNode<CargadorEscena>("/root/CargadorEscena").ChangeToScene("Level/menu_principal.tscn");
	}

}
