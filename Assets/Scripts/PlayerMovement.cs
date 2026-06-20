using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	private const KeyCode JumpKey = KeyCode.Space;
	private const string HorizontalInputName = "Horizontal";
	private const string VerticalInputName = "Vertical";

	[SerializeField] private float _jumpForce;
	[SerializeField] private float _moveForce;
	[SerializeField] float _maxForce;
	
	private Rigidbody _rigidbody;
	private bool _jumpKeyPressed;
	public bool _isGrounded;

	private float _horizontalInput;
	private float _verticalInput;

	private float _slopeNormalLimit = 0.9f;
	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_isGrounded = true;
	}

	private void Update()
	{
		ProcessInput();
	}

	private void FixedUpdate()
	{
		if (_jumpKeyPressed)
			Jump();
		
		if (_rigidbody.velocity.magnitude < _maxForce)
		{
			Move();
		}
		
		Debug.Log($"Velocity: {_rigidbody.velocity.magnitude}");
	}

	private void Jump()
	{
		_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
		_jumpKeyPressed = false;
		_isGrounded = false;
	}

	private void Move()
	{
		Vector3 forceDirection = ((Vector3.forward * _verticalInput) + (Vector3.right * _horizontalInput)).normalized;
		_rigidbody.AddForce(forceDirection * _moveForce);
	}

	private void ProcessInput()
	{
		if (!_jumpKeyPressed && _isGrounded)
			_jumpKeyPressed = Input.GetKeyDown(JumpKey);

		_horizontalInput = Input.GetAxisRaw(HorizontalInputName);
		_verticalInput = Input.GetAxisRaw(VerticalInputName);
	}

	private void OnCollisionEnter(Collision collision)
	{
		CheckPlayerIsGrounded(collision.contacts);
	}

	private void OnCollisionStay(Collision collision)
	{
		CheckPlayerIsGrounded(collision.contacts);
	}

	private void OnCollisionExit(Collision other)
	{
		_isGrounded = false;
	}

	private void CheckPlayerIsGrounded(ContactPoint[] contacts)
	{
		foreach (var contact in contacts)
		{
			Vector3 contactNormal = contact.normal;
			
			Debug.Log(contact.normal);

			if (contactNormal.y >= _slopeNormalLimit)
				_isGrounded = true;
		}
	}
}
