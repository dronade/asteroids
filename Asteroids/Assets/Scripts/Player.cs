
using UnityEngine;

// --------------------
// @Author Emily Canto
// --------------------

public class Player : MonoBehaviour
{
    // --- Public variables: ---
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public Bullet bulletPrefab;

    // --- Private variables: ---
    private Rigidbody2D _rigidBody;
    private bool _thrusting;
    private float _turningDirection;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // --- Determine which buttons player is pressing
    private void Update(){

        _thrusting = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            _turningDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            _turningDirection = -1.0f;
        } else {
            _turningDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    // --- Turn/Thrust based on player input (from Update())
    private void FixedUpdate() {

        if (_thrusting){
            _rigidBody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if (_turningDirection != 0.0f){
            _rigidBody.AddTorque(_turningDirection * this.turnSpeed);
        }
    
    }

    // --- Create a new instance of Bullet, and shoot it using the location (and rotation) of the player
    private void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Projectile(this.transform.up);
    }

}
