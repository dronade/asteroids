using UnityEngine;

public class ForwardCommand : ICommand
{
    private readonly float speed;
    private readonly Rigidbody2D rb;
    private readonly Player p;

    private Transform startTransform;

    public ForwardCommand(Player player, Rigidbody2D rigidbody, float thrustSpeed)
    {
        speed = thrustSpeed;
        rb = rigidbody;
        p = player;
        startTransform = p.transform;
    }
    public void Execute()
    {
        startTransform = p.transform;
        rb.AddForce(p.transform.up * this.speed);
    }
}