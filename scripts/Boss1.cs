using Godot;
using System;

public partial class Boss1 : RigidBody2D
{
    private AnimationPlayer animationPlayer;
    private Area2D dangerZone;
    private CharacterBody2D player;
    private bool isAttacking = false;

/*    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        dangerZone = GetNode<Area2D>("DangerZone");
        player = GetNode<Player>("Characters/Player"); // Ajusta la ruta al jugador en tu escena

        Connect("body_entered", this, "_on_DangerZone_body_entered");
        Connect("body_exited", this, "_on_DangerZone_body_exited");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (isAttacking)
        {
            GD.Print("¡El jefe está atacando al jugador!");
            // Aquí puedes agregar la lógica de ataque del jefe
        }
    }

	private void _on_DangerZone_body_entered(Node body)
    {
        if (body == player)
        {
            GD.Print("¡El jugador ha entrado en la zona de peligro!");
            animationPlayer.Play("Attack");
            isAttacking = true;
        }
    }

    private void _on_DangerZone_body_exited(Node body)
    {
        if (body == player)
        {
            GD.Print("El jugador ha salido de la zona de peligro.");
            animationPlayer.Play("Idle");
            isAttacking = false;
        }
    }*/
}
