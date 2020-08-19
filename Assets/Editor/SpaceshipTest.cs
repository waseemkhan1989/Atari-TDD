using UnityEngine;
using NUnit.Framework;

public class SpaceshipTest
{
    private Spaceship m_Spaceship;

    [SetUp]
    public void Setup()
    {
        m_Spaceship = new GameObject("Spaceship").AddComponent<Spaceship>();
    }
    
    [Test]
    public void MovementTest()
    {

        // Assert.IsNull(spaceship.MoveJoystick.InputDir, "x and y co-ordinates are NULL");
        //Assert.IsTrue(m_Spaceship.MoveJoystick.InputDir == null);
    }

    [Test]
    public void Move()
    {
        m_Spaceship.Movement(4f, 3f);
        // Assert.AreEqual(m_Spaceship.rb.position, );
    }
}


