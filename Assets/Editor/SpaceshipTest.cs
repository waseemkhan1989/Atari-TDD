using UnityEngine;
using NUnit.Framework;

//[TestFixture, Category("UnityTest")]
public class SpaceshipTest
{
    public Spaceship m_Spaceship;
    private GameObject m_Go;
    private readonly Vector2 ActualOutput = new Vector2(5f,3f);

  

    [SetUp]
    public void Setup()
    {
        m_Go = new GameObject("Spaceship");
        m_Go.AddComponent<Rigidbody2D>();
        m_Spaceship = m_Go.AddComponent<Spaceship>();
    }
    
   /* [Test]
    public void MovementTest()
    {
        // Assert.IsNull(spaceship.MoveJoystick.InputDir, "x and y co-ordinates are NULL");
        Assert.That(m_Spaceship.InputDir, Is.EqualTo(Vector2.zero));
    }

    [Test]
    public void Move()
    {
        m_Spaceship.Movement(4f, 3f);
        Assert.AreEqual(m_Spaceship.rb.position, ActualOutput);
    }*/
}


