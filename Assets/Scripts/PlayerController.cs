using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5;

    private float _speedMultiplier = 1;
    private float _verticalInput;
    
    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        float mult = _verticalInput * speed * _speedMultiplier;
        _rigidbody.velocity = mult * Vector3.forward;
    }

    private void GetInput()
    {
        _verticalInput = Input.GetAxis("Vertical");
    }
}
