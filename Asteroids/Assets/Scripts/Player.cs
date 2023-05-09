using UnityEngine;

// --------------------
// @Author Emily Canto
// --------------------

public class Player : MonoBehaviour
{
    // --- Variables: ---
    
    private Rigidbody2D _rigidBody;
    public Bullet bulletPrefab;
    public GameManager gameManager;
    public  float _thrustSpeed = 2.0f;
    public float _turnSpeed = 0.25f;
    private bool isDead = false;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // --- Create a new instance of Bullet, and shoot it using the location + rotation of player
    public void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, 
        this.transform.position, this.transform.rotation);

        bullet.Projectile(this.transform.up);
    }

// need to add explode particle & freeze time when dead
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Asteroid"){
            Destroy(this.gameObject);

            if (!isDead){
                isDead = true;
                gameManager.gameOver();
            }
        }
    }

}
