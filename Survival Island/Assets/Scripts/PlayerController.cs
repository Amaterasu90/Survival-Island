using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private CharacterController characterController;
	private Vector3 moveDirection;
	public float moveSpeed = 0.5f;
	public float rotationSpeed = 3.5f;
	public float gravity = 5f;
	public float jumpHeight = 0.75f;
	private Quaternion rotateY = Quaternion.AngleAxis (0, new Vector3 (0, 1, 0));
	
	void Start () {
		characterController = GetComponent<CharacterController>();
		moveDirection = Vector3.zero;

	}
	void Update () 
	{
		Camera cam = GetComponentInChildren<Camera> ();
		if (networkView.isMine)
		{
			cam.enabled = true;
			if(characterController.isGrounded)
			{
				SetHorizontalVertical();
				Rotate();
				GiveSpeed();
				if(Input.GetButton("Jump"))
					Jump ();
			}
			Move ();
		}
		else
			cam.enabled =false;
	}
	
	void Jump ()
	{
		moveDirection.y = jumpHeight;
	}
	
	void SetHorizontalVertical()
	{
		moveDirection = (new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")))*Time.deltaTime;
	}
	
	
	void GiveSpeed()
	{
		moveDirection *= moveSpeed;
	}
	
	void Rotate()
	{
		moveDirection = rotateY * moveDirection;
		transform.rotation = rotateY;
		rotateY.eulerAngles += (new Vector3 (0, Input.GetAxis ("Rotation Y"), 0)) * rotationSpeed * Time.deltaTime;
	}
	
	void Move()
	{
		moveDirection.y -= gravity*Time.deltaTime;
		characterController.Move (moveDirection);
	}
}
