using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Player player;
    public Invoker invoker;
    private bool _thrust;
    private float _turningDirection;

    private Rigidbody2D _rb;

    private void Start()
    {
        Command forwardCommand = new ForwardCommand(player, _rb, player._thrustSpeed);
        Command turnCommand = new TurnCommand(player, _rb, _turningDirection, player._turnSpeed);
        invoker = new Invoker(forwardCommand, turnCommand);
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
            player.Shoot();
        }
    }
  

    // --- Turn/Thrust based on player input
    private void FixedUpdate()
    {
        if (_thrust)
        {
            invoker.Forward();
        }

        if (_turningDirection != 0.0f)
        {
            invoker.Turn();
        }

    }
}
