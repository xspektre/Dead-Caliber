using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    // Independent Variables
    public float speed = 2.0f;
    public float strafeMultiplier = 1.0f;
    public float backwardMultiplier = 1.0f;

    // Dependent Variables
    private float backwardSpeed;
    private float strafeSpeed;

    // Sensitivities
    public float mouseSensitivity = 2.0f;

    // Components
    public GameObject playerCamera;
    CharacterController character;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        Move();

        UpdateAnimator();
		
	}

    void Move() // Handles player movement, maybe split movement and viewing so that player can customize their options?
    {
        // Gets mouse input
        var xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        var yMouse = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Gets keyboard input and generates proper vector
        var forwardSpeed = Input.GetAxis("Vertical") * speed;
        var strafeSpeed = Input.GetAxis("Horizontal") * speed * strafeMultiplier;
        var backwardSpeed = Input.GetAxis("Vertical") * speed * backwardMultiplier;
        Vector3 movement;
        movement = new Vector3(strafeSpeed, 0, forwardSpeed);
        transform.Translate(movement * Time.deltaTime);

        // Rotation
        transform.Rotate(0,xMouse,0);
        playerCamera.transform.Rotate(-yMouse, 0, 0);
    }

    void UpdateAnimator()
    {
        animator.speed = Input.GetAxis("Vertical");
    }
}
