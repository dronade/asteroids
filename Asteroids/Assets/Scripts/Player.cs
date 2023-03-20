using UnityEngine;

// --------------------
// @Author Emily Canto
// --------------------

public class Player : MonoBehaviour
{
    // --- Variables: ---
    public Bullet bulletPrefab;
    [SerializeField]private float _thrustSpeed = 2.0f;
    [SerializeField]private float _turnSpeed = 0.5f;
    private Rigidbody2D _rigidBody;
    private bool _thrust;
    private float _turningDirection;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    //TODO: change this input system to command pattern
    //TODO:  add hull integrity
    private void Update(){
        _thrust = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

        // Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            _turningDirection = 1.0f;

        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            _turningDirection = -1.0f;

        } else {
            _turningDirection = 0.0f;
        }

        // Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    // --- Turn/Thrust based on player input
    private void FixedUpdate() {
        if (_thrust){
            _rigidBody.AddForce(this.transform.up * this._thrustSpeed);
        }

        if (_turningDirection != 0.0f){
            _rigidBody.AddTorque(_turningDirection * this._turnSpeed);
        }
    
    }

    // --- Create a new instance of Bullet, and shoot it using the location + rotation of player
    private void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, 
        this.transform.position, this.transform.rotation);

        bullet.Projectile(this.transform.up);
    }

}
