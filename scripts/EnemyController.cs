using Godot;
using System;

public partial class EnemyController : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]public float speed = 100.0f; // Velocidad de movimiento
	[Export]public float _destiny; // Ubicacion en pixel debe ser simepre menor a la position
	
	private Vector2 _initialPosition;
	private bool _isMovingtoTheLeft = true;
	private AnimatedSprite2D _animatedSprite2D;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_initialPosition = Position;
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		// Asignamos la velocidad
		float move = speed * (float)delta;

		// Si esta en movimiento verifica
		if(_isMovingtoTheLeft)
		{
			MoveLocalX(-move);
			_animatedSprite2D.Play("walk");
			_animatedSprite2D.FlipH = false;

			// Verificacion de la posicion y cambia el movimento a la izquierda a false al completar
			if(Position.X <= _destiny)
			{
				Position = new Vector2(_destiny,Position.Y);
				_isMovingtoTheLeft = false;
			}
		}
		else
		{
			MoveLocalX(move);
			_animatedSprite2D.FlipH = true;

			// Verificacion de la posicion y cambia el movimiento a la izquierda a true al completar
			if(Position.X >= _initialPosition.X)
			{
				Position = new Vector2(_initialPosition.X, Position.Y);
				_isMovingtoTheLeft = true;
			}
		}
	}

	private void OnBodyEntered(CharacterBody2D body)
	{
		if(body.Name == "Player")
		{
			GD.Print("Me ha matado el jugador");
			QueueFree();
		}
	}

}
