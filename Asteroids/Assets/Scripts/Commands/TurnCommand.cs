using UnityEngine;

public class TurnCommand : ICommand
{
    private static readonly float speedMulti = 0.05f;

    private readonly float speed;
    private readonly float direction;
    private readonly Rigidbody2D rb;
    private readonly Player p;

    public TurnCommand(Player player, Rigidbody2D rigidbody, float turnSpeed, float turnDirection)
    {
        p = player;
        rb = rigidbody;
        speed = turnSpeed;
        direction = turnDirection;
    }

    public void Execute()
    {
        rb.AddTorque(direction * this.speed * speedMulti);
    } 
}