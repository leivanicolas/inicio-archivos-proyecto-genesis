using Godot;
using System;

public partial class CargadorEscena : Node
{
	[Export] private string _sceneFolder;
	public void ChangeToScene(string sceneName)
	{
		string f = _sceneFolder == "" ? "" : $"{_sceneFolder}/";
		GetTree().ChangeSceneToFile($"res://{f}{sceneName}");
	}
}
