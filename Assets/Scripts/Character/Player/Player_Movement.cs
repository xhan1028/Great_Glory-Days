using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public float jumpPower;
	
	float horizontalMove
	{
		get => _horizontalMove; 
		set
		{
			_horizontalMove = value;
			animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));
		}
	}
	float _horizontalMove;
	private bool jump = false;
	private Rigidbody2D rigid;

	public GameObject chatUI;
	public bool canMove => !chatUI.gameObject.activeSelf;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (!canMove && horizontalMove != 0) horizontalMove = 0;
		if (!canMove) return;
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.W))
		{
			if (!jump)
			{
				jump = true;
				rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
			}
		}
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
	//	jump = false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name.Equals("Area"))
		{
			jump = false;
		}
	}
}
