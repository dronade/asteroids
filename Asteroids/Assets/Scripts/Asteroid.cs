using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1.0f;
    public float minimumSize = 0.5f;
    public float maximumSize = 1.5f;
    [SerializeField]private float _speed = 25.0f;
    [SerializeField]private float _lifetime = 30.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Start(){
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rigidBody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction){
        _rigidBody.AddForce(direction * this._speed);
        Destroy(this.gameObject, this._lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet"){
            if ((this.size / 2) >= this.minimumSize ){
                Split();
                Split();
            }
            Destroy(this.gameObject);
        }
    }

    private void Split(){
        Vector2 position  = this.transform.position; 
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size / 2;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }

}
