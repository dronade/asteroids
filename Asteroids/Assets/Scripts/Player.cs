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
    private bool _thrust;
    private float _turningDirection;

    private CommandManager commandManager;

    private void Awake() {
        commandManager = GetComponent<CommandManager>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        // Movement
        _thrust = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turningDirection = 1.0f;

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turningDirection = -1.0f;
        }
        else
        {
            _turningDirection = 0.0f;
        }

        // Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    // --- Turn/Thrust based on player input
    private void FixedUpdate()
    {
        if (_thrust)
        {
            commandManager.Execute(new ForwardCommand(this, _rigidBody, this._thrustSpeed));
        }

        if (_turningDirection != 0.0f)
        {
            commandManager.Execute(new TurnCommand(this, _rigidBody, this._turnSpeed, this._turningDirection));
        }

    }

    // --- Create a new instance of Bullet, and shoot it using the location + rotation of player
    public void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab,
        this.transform.position, this.transform.rotation);
        commandManager.Execute(new ShootCommand(this.transform, bullet));
    }

// need to add explode particle & freeze time when dead
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Asteroid"){
            Destroy(this.gameObject);

            if (!isDead){
                isDead = true;
                gameManager.GameOver();
            }
        }
    }

}
