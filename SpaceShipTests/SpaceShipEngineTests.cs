using Assets.Scripts;
using NSubstitute;
using NUnit.Framework;

namespace SpaceShipTests
{
    [TestFixture, Category("StandardTest")]
    public class SpaceShipEngineTests
    {
        private SpaceShipModel m_Spaceship;
        private ISpaceshipEngine m_SpaceShipEngine;

        [SetUp]
        public void Setup()
        {
            m_SpaceShipEngine = Substitute.For<ISpaceshipEngine>();
            m_Spaceship = new SpaceShipModel(m_SpaceShipEngine);
        }
        
        [Test]
        public void SomeTest()
        {
            m_Spaceship.AddForce();
            m_SpaceShipEngine.Received(1).AddForce();
        }
    }
}