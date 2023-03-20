using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    [SerializeField]private float _spawnRate = 2.0f;
    [SerializeField]private float _spawnDistance = 15.0f;
    [SerializeField]private float _spawnTrajectory = 15.0f;
    [SerializeField]private int _spawnVolume = 1;
    
    private void Start() {

        InvokeRepeating(nameof(SpawnAsteroid), this._spawnRate, this._spawnRate);
    }

    private void SpawnAsteroid(){

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
