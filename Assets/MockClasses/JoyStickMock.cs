using UnityEngine;

namespace MockClasses
{
    // Mock class is an implementation of interface. Interface is not a class
    // so we need a mock class for a dummy implementation of original class
    public class JoyStickMock : MonoBehaviour, IJoyStick
    {
        public Vector3 InputDir { get; set; }
    }
}