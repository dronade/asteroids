using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager Instance { get; private set; }

    public Asteroid asteroidPrefab;
    [SerializeField]private float _spawnRate = 2.0f;
    [SerializeField]private float _spawnDistance = 15.0f;
    [SerializeField]private float _spawnTrajectory = 15.0f;
    [SerializeField]private int _spawnVolume = 1;

    [SerializeField]private bool _enabled = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else {
            Instance = this;
            StartSpawning();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StopSpawning();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            StartSpawning();
        }
    }

    public void StopSpawning()
    {
        if (_enabled)
        {
            Debug.Log("Stop spawning");
            CancelInvoke();
            _enabled = false;
        }
    }

    public void StartSpawning()
    {
        if (!_enabled) 
        {
            Debug.Log("Start spawning");
            InvokeRepeating(nameof(SpawnAsteroid), this._spawnRate, this._spawnRate);
            _enabled = true;
        }
    }

    private void SpawnAsteroid(){
        if (!_enabled) { return; }

        for (int i = 0; i <this._spawnVolume; i++){
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this._spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this._spawnTrajectory, this._spawnTrajectory);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minimumSize, asteroid.maximumSize);

            asteroid.SetTrajectory(rotation * -spawnDirection);
        }

    }
}
