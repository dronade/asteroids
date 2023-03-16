using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --------------------
// @Author Emily Canto
// --------------------

public class Bullet : MonoBehaviour
{

    // --- Variables: ---
    [SerializeField]private float speed = 500.0f;
    [SerializeField]private float lifetime = 7.0f;
    private Rigidbody2D _rigidBody;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // --- Determine speed of projectile, and destroy after lifetime
    public void Projectile(Vector2 direction){
        _rigidBody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);
    }

}
