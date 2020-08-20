using System.Runtime.CompilerServices;
using UnityEngine;
using NUnit.Framework;

[TestFixture, Category("UnityTest")]
public class SpaceshipTest
{
    public Spaceship m_Spaceship;
    private GameObject m_Go;
    private readonly Vector2 ActualOutput = new Vector2(5f,3f);
    private Rigidbody2D m_RigidBody;

  // Just for test
  // Angle would be input. PreCalculate transform.rotation and then check-----> Rotation Test
  //

    [SetUp]
    public void Setup()
    {
        m_Go = new GameObject("Spaceship");
        m_RigidBody = m_Go.AddComponent<Rigidbody2D>();
        m_Spaceship = m_Go.AddComponent<Spaceship>();
    }
    
   [Test]
    public void MovementTest()
    {
        // Assert.IsNull(spaceship.MoveJoystick.InputDir, "x and y co-ordinates are NULL");
        // Assert.That(m_Spaceship.InputDir, Is.EqualTo(Vector2.zero));
        m_Spaceship.MoveJoystick.InputDir = new Vector3(5, 6, 6);
        m_Spaceship.MoveSpeed = 2f;
        // m_Spaceship.Movement();
        m_Spaceship.Update();
        
        Assert.That(m_RigidBody.position, Is.EqualTo(new Vector3(10, 12, 12)));
        
        m_Spaceship.Update();
        Assert.That(m_RigidBody.position, Is.EqualTo(new Vector3(20, 24, 24)));
    }

    [Test]
    public void MoveTest()
    {
        m_Spaceship.Movement();
        Assert.AreEqual(m_Spaceship.transform.position, ActualOutput);
    }

    [Test]
    public void ShootTest()
    {
        m_Spaceship.MouseButtonPressed = true;
        m_Spaceship.CanShoot = true;
        
        m_Spaceship.Update();

        var bulltes = GameObject.FindObjectsOfType<Bullet>();
        Assert.That(bulltes.Length, Is.EqualTo(2));
    }
    
    [Test]
    public void RotationTest()
    {
        m_Spaceship.MoveJoystick.InputDir = Vector3.zero;
        m_Spaceship.ShootJoystick.InputDir = new Vector3(55, 64, 64);
        
        m_Spaceship.Update();
        
        Assert.That(m_Spaceship.transform.rotation,  Is.EqualTo(new Vector3()));
    }
}


