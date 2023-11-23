using Godot;
using System;

public partial class Character2 : CharacterBody2D
{
	// Fisica de movimiento
	[Export] public float speed = 300.0f;
	[Export] public float jumpVelocity = -400.0f;	
	// Obtener gravedad desde la configuracion de godot
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	// Animacion 
	private AnimatedSprite2D _animationController;

	// Ataque
	private bool _isAttacking = false;


    public override void _Ready()
    {
		// Obtener referencia al nodo
        _animationController = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		//Actualizamos animaciones segun velocidad x idle o walk
		UpdateSpriteRenderer(velocity.X);

		// Aplicamos gravedad al personaje 
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}

		// Aplicamos fuerza para saltar
		if(Input.IsActionPressed("jump") && IsOnFloor())
		{
			velocity.Y = jumpVelocity;
		}

		// Aplicamos movimiento izq y der personaje
		velocity.X = 0;
		if(Input.IsActionPressed("left"))
		{
			velocity.X = -speed;
		}
		else if(Input.IsActionPressed("right"))
		{
			velocity.X = speed;
		}

		// Ataque
		HandleAttack();

		Velocity = velocity;
		MoveAndSlide();
	} 

	private void UpdateSpriteRenderer(float velocityX)
	{
		bool walking = velocityX != 0;

		if(_isAttacking == false)
		{
			if(walking)
			{
				_animationController.Play("walk");
				_animationController.FlipH = velocityX < 0;
			}
			else
			{
				_animationController.Play("idle");
			}
		}
	}

	private void HandleAttack()
	{

		if(Input.IsActionPressed("attack"))
		{
			
			_animationController.Play("attack");
			_isAttacking = true;
		}
		else
		{
			_isAttacking = false;
		}		
		
	}

	private void OnBodyEntered(CharacterBody2D body)
	{
		if(body.IsInGroup("Enemies"))
		{
			GD.Print("Me toco un enemigo");
		}
	}
}
