using UnityEngine;

namespace MockClasses
{
    public class JoyStickMock : MonoBehaviour, IJoyStick
    {
        public Vector3 InputDir { get; set; }
    }
}