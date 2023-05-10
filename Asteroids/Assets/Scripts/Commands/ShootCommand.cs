using UnityEngine;

public class ShootCommand : ICommand
{

	private Transform transform;
	private Bullet bullet;
	public ShootCommand(Transform transform, Bullet bullet)
	{
		this.transform = transform;
		this.bullet = bullet;
	}

	public void Execute()
	{
		bullet.Projectile(this.transform.up);
	}
}