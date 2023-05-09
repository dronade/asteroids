using UnityEngine;

public class ForwardCommand : Command
{
    private float speed;
    private Rigidbody2D rb;
    private Player p;

    public ForwardCommand(Player player, Rigidbody2D rigidbody, float thrustSpeed) : base(player)
    {
        speed = thrustSpeed;
        rb = rigidbody;
        p = player;
    }
    public override void Execute()
    {
        rb.AddForce(p.transform.up * this.speed);
    }
}