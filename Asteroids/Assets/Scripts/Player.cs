
using UnityEngine;

public class Player : MonoBehaviour
{
    // --- Public variables: ---
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

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

}
