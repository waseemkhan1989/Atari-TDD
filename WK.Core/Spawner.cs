﻿﻿using UnityEngine;
using Random = UnityEngine.Random;

namespace WK.Core
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] asteroids;
        public GameObject[] spawnPositions;
        public float spawnRate;
        private float NextSpawn;

        public Transform target;
    
        // Start is called before the first frame update
        void Start()
        {
        

        }

        // Update is called once per frame
        void Update()
        {
            // Creating gap between spawnings
            if (NextSpawn > 0)
                NextSpawn -= Time.deltaTime;
            if (NextSpawn <= 0)
                Spawn();
        
        }

        private void Spawn()
        {
            NextSpawn = spawnRate;
            // Randomly getting a Game object from array and then its position
            Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
            GameObject asteroidClone = Instantiate(asteroids[Random.Range(0, asteroids.Length)],
                new Vector2(position.x, position.y), transform.rotation);
            asteroidClone.GetComponent<Asteroids>().Initialize(target.position);
            asteroidClone.SetActive(true);
        
        }

  
    }
}
