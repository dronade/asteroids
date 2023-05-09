using UnityEngine;

public class TurnCommand : Command
{
    private readonly float speed;
    private readonly float direction;
    private readonly Rigidbody2D rb;
    private readonly Player p;

    public TurnCommand(Player player, Rigidbody2D rigidbody, float turnSpeed, float turnDirection) : base(player)
    {
        p = player;
        rb = rigidbody;
        speed = turnSpeed;
        direction = turnDirection;
    }

    public override void Execute()
    {
        rb.angularVelocity = direction * this.speed;
    }
}