using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {

        public float speedMultiplier = 1;

        [SerializeField]
        private float speed = 5;
    
        private Rigidbody _rigidbody;
        private BoxCollider _collider;
    
        private Vector3 _displacement;
        private Vector3 _displacementDirection;
    
        private float _baseWidth;
        private float _halfWidth;

        private int _originalLayer;
        private int _ignoreRaycastLayer;
        private int _ignoreRaycastLayerMask;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
        
            _baseWidth = transform.localScale.z;
            _halfWidth = _baseWidth / 2;
        
            _originalLayer = gameObject.layer;
            _ignoreRaycastLayer = LayerMask.NameToLayer("Ignore Raycast");
            _ignoreRaycastLayerMask = ~LayerMask.GetMask("Ignore Raycast");
        }

        private void Update()
        {
        
        }

        private void FixedUpdate()
        {
            GetInput();
            ComputeMovement();
            UpdateMovement();
        
            // Movement:
            // - Cast a line down the direction
            // - Check for collisions
            // - Go full distance if no collisions
            // - Move collision distance otherwise
        }

        private void GetInput()
        {
            float mod = speed * speedMultiplier * Time.fixedDeltaTime * Input.GetAxis("Vertical");
            _displacement = mod * Vector3.forward;
            _displacementDirection = _displacement.normalized;
        }

        private void ComputeMovement()
        {
            // Detect collision in movement direction
            // Collision is detected between the side opposite to the movement
            // and the end position of that side
            Vector3 sideStartPos = transform.position - _displacementDirection * _halfWidth;
            Vector3 sideEndPos = sideStartPos + _displacementDirection * (_displacement.magnitude + _baseWidth);
            RaycastHit raycast;

            gameObject.layer = _ignoreRaycastLayer;
            bool collision = Physics.Linecast(sideStartPos, sideEndPos + _displacement, out raycast, _ignoreRaycastLayerMask);
            gameObject.layer = _originalLayer;

            // Scale down displacement to collision distance
            if (collision)
            {
                // Handle further collision: if paddle is inside the object,
                // repel the paddle outside the object
                float distance = raycast.distance - _baseWidth;
                _displacement = distance * _displacementDirection;
            }
        }

        private void UpdateMovement()
        {
            transform.Translate(_displacement, Space.World);
        }
        
    }
}
