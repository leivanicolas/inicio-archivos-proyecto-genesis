using Godot;
using System;

public partial class Character2 : CharacterBody2D
{
	[Export] public float speed = 300.0f;
	[Export] public float jumpVelocity = -400.0f;
	public bool isJumping;

	public int health = 1;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;

		}
			

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = jumpVelocity;
			isJumping = true;
			GD.Print(isJumping);
		}			

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, speed);
		}

		Velocity = velocity;
		MoveAndSlide();

	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		if(health == 0)
		{
			Die();
		}
	}
	private void Die()
	{
		
	}
}
