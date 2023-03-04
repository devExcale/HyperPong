using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        
        public Vector3 Velocity => baseSpeed * speedMultiplier * Direction;
        public Vector3 Direction { get; set; }
        public float speedMultiplier = 1f;

        [SerializeField]
        private float baseSpeed;
        [SerializeField]
        private float startingAngle;
        private float _startingAngleRad;

        private Rigidbody _rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _startingAngleRad = (float)(startingAngle / 180d * Math.PI);
            Direction = new Vector3(Mathf.Cos(_startingAngleRad), 0, Mathf.Sin(_startingAngleRad));
        }

        private void DrawVelocity()
        {
            Vector3 pos = transform.position;
            Debug.DrawLine(pos, pos + _rigidbody.velocity, Color.cyan);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Velocity;
            DrawVelocity();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // It's a sphere, hopefully the collision will be just one
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 pos = transform.position;

            // Get the vector normal to the surface of impact
            // and compute the direction component on that axis
            Vector3 normalSurface = collision.impulse.normalized;
            Vector3 normalDirection = Vector3.Dot(Direction, normalSurface) * normalSurface;
        
            Debug.DrawLine(pos, pos + normalDirection, Color.green);

            // Subtract the velocity normal to the impact
            // once to null it, twice to invert it
            Direction -= 2 * normalDirection;

            Debug.DrawLine(contactPoint.point, contactPoint.point + collision.impulse.normalized, Color.red, 5f);
        }
        
    }
}
