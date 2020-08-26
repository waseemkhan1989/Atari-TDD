using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

namespace WK.Core.TestsUnity.Playmode
{
    [TestFixture]
    public class MovementTest 
    {
        public Spaceship m_Spaceship;
        private GameObject m_Go;
        //private readonly Vector2 ActualOutput = new Vector2(5f,3f);
        private Rigidbody2D m_RigidBody;

        private GameObject ShootJoyStickGameObject;
        private GameObject MoveJoyStickGameObject;
        private IJoyStick MockShootJoyStick;
        private IJoyStick MockMoveJoyStick;
    
        [SetUp]
        public void Setup()
        {
            m_Go = new GameObject("Spaceship");
            m_RigidBody = m_Go.AddComponent<Rigidbody2D>();
            m_Spaceship = m_Go.AddComponent<Spaceship>();
        
            ShootJoyStickGameObject = new GameObject("ShootJoyStickGameObject");
            MoveJoyStickGameObject = new GameObject("MoveJoyStickGameObject");

            MockMoveJoyStick = ShootJoyStickGameObject.AddComponent<JoyStickMock>();
            MockShootJoyStick = MoveJoyStickGameObject.AddComponent<JoyStickMock>();

            m_Spaceship.MoveJoyStickGameObject = MoveJoyStickGameObject;
            m_Spaceship.ShootJoyStickGameObject = ShootJoyStickGameObject;
        
            m_Spaceship.Start();
        }

        [UnityTest]
        public IEnumerator Should_MoveSpaceship_when_MouseIsOnJoystick()
        {
            // Assert.IsNull(spaceship.MoveJoystick.InputDir, "x and y co-ordinates are NULL");
            // Assert.That(m_Spaceship.InputDir, Is.EqualTo(Vector2.zero));
            m_Spaceship.MoveJoystick.InputDir = new Vector3(5, 6, 6);
            m_Spaceship.MoveSpeed = 2f;
            // m_Spaceship.Movement();
            // m_Spaceship.Update();
        
            // Assert.That(m_RigidBody.position, Is.EqualTo(new Vector3(10, 12, 12)));
            yield return new WaitForSeconds(1);
            Assert.That(m_RigidBody.position, Is.EqualTo(new Vector3(10, 12, 12)).Using(Vector3EqualityComparer.Instance));
            // Markus told me that you should use these EqualityComparer
        }
    
        public class JoyStickMock : MonoBehaviour, IJoyStick
        {
            public Vector3 InputDir { get; set; }
        }
    }
}
