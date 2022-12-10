using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CollectorController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick _joystick;

    public CollectorData _collectorData; 
    private void FixedUpdate() 
    {
        CollectorMovement();
        CollectorRotation();
    }

    public void CollectorMovement()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _collectorData._collectorSpeed, 0 ,
         _joystick.Vertical * _collectorData._collectorSpeed);
    }

    public void CollectorRotation()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
