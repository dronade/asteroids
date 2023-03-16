using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    [SerializeField]private float spawnRate = 2.0f;
    [SerializeField]private int spawnVolume = 1;

    private void Start() {

        InvokeRepeating(nameof(SpawnAsteroid), this.spawnRate, this.spawnRate);
    }

    private void SpawnAsteroid(){

        for (int i = 0; i <this.spawnVolume; i++){
            Vector3 spawnPoint;
            Asteroid asteroid = Instantiate(this.asteroidPrefab, position, rotation);
        }

    }
}
