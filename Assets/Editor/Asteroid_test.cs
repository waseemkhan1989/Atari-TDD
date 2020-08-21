using System;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Editor
{
    [TestFixture]
    public class Asteroid_test
    {
        private GameObject m_AsteroidGameObject;
        private Asteroids m_Asteroids;

        private Random m_Random;

        [SetUp]
        public void SetUp()
        {
            m_AsteroidGameObject = new GameObject();
            m_AsteroidGameObject.transform.position = Vector3.zero;

            m_AsteroidGameObject.AddComponent<Rigidbody2D>();
            
            m_Asteroids = m_AsteroidGameObject.AddComponent<Asteroids>();
            m_Asteroids.boundLeft = m_Asteroids.boundRight = m_Asteroids.boundUp = m_Asteroids.boundDown = 1.0f;
            
            m_Random = new Random();
        }

        [Test]
        [Repeat(100)]
        public void Should_CalculateCorrectDirection()
        {
            m_AsteroidGameObject.transform.position = new Vector3(m_Random.Next(-100, 100), m_Random.Next(-100, 100), m_Random.Next(-100, 100));
            var targetDirection = new Vector3(m_Random.Next(-100, 100), m_Random.Next(-100, 100), m_Random.Next(-100, 100));
            var expectedDirection = targetDirection - m_AsteroidGameObject.transform.position;
            
            m_Asteroids.Initialize(targetDirection);
            
            Assert.That(m_Asteroids.direction,Is.EqualTo(expectedDirection));
        }

        [Test]
        public void Should_DestroyAsteroid_When_OutOfBounds()
        {
            var asteroidGameObjects = new []
            {
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(), 
            };

            var asteroids = new Asteroids[5];
            
            asteroidGameObjects[0].transform.position = Vector3.zero;
            asteroidGameObjects[1].transform.position = new Vector3(2,0,0);
            asteroidGameObjects[2].transform.position = new Vector3(-2,0,0);
            asteroidGameObjects[3].transform.position = new Vector3(0,2,0);
            asteroidGameObjects[4].transform.position = new Vector3(0,-2,0);

            for (int i = 0; i < 5; ++i)
            {
                asteroids[i] = asteroidGameObjects[i].AddComponent<Asteroids>();
                asteroids[i].CheckPosition();
            }
            
            Assert.That(asteroidGameObjects[0] != null);
            Assert.That(asteroidGameObjects[1] == null);
            Assert.That(asteroidGameObjects[2] == null);
            Assert.That(asteroidGameObjects[3] == null);
            Assert.That(asteroidGameObjects[4] == null);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_AsteroidGameObject);
        }
    }
}