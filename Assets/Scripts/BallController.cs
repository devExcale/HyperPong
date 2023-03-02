using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float fixedVelocity;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float startingAngle;
    private float _startingAngleRad;

    private Rigidbody _rigidbody;
    private Vector3 _currentDir;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _startingAngleRad = (float)(startingAngle / 180d * Math.PI);

        float x = Mathf.Cos(_startingAngleRad);
        float z = Mathf.Sin(_startingAngleRad);

        _currentDir = new Vector3(x, 0, z);
    }

    private void DrawVelocity()
    {
        Vector3 pos = transform.position;
        Debug.DrawLine(pos, pos + _rigidbody.velocity, Color.blue);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity =  speed * _currentDir;
        DrawVelocity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        // It's a sphere, hopefully the collision will be just one
        ContactPoint contactPoint = collision.GetContact(0);

        Vector3 awayDir = collision.impulse.normalized;
        Vector3 orthogonalVelocity = Vector3.Dot(_rigidbody.velocity, awayDir) * awayDir;
        
        Debug.Log(orthogonalVelocity);
        
        Vector3 velocity = _rigidbody.velocity;
        velocity += 2 * orthogonalVelocity;
        
        _rigidbody.velocity = velocity;
        _currentDir = velocity.normalized;
        DrawVelocity();

        Debug.DrawLine(contactPoint.point, contactPoint.point + collision.impulse.normalized, Color.red, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
