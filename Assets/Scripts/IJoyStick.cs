using UnityEngine;

//we created interface of Joystick class so that we can bypass
//the original implementation of Joystick. It is just a blueprint of class
// which contains function prototypes and parameters declarations.
public interface IJoyStick
{
    Vector3 InputDir { get; set; }
}