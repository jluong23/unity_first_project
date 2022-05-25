using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpHeight = 0.5f;
    [SerializeField] float turnSpeed = 1f;
    Vector3 velocity;
    public float gravity = -9.81f;
    
    [SerializeField] Transform groundCheck;
    public float groundDistance = 0.4f;
    [SerializeField] LayerMask ground;

    [SerializeField] Text coinText;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource coinSound;

    public CharacterController controller;
    
    int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        Vector3 move = transform.right* dx + transform.forward * dz;
        controller.Move(move*movementSpeed*Time.deltaTime);
        
        if(isGrounded() && velocity.y < 0){
            velocity.y = -2f;
        }        


        if (Input.GetButtonDown("Jump") && isGrounded())
        {   
            Jump();
        }
        else if(Input.GetButton("Turn Camera")){
            TurnPlayer(Input.GetAxis("Turn Camera"));
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

    }

    void TurnPlayer(float dir){
        if(dir < 0){
            transform.Rotate(0, -turnSpeed, 0);
        }else{
            transform.Rotate(0, turnSpeed, 0);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy Head")){
            Destroy(collision.transform.parent.gameObject);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // picking up coin, increment coin counter, play sound
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            coins++;
            coinText.text = "Coins: " + coins;
            coinSound.Play();
        }
    }

    bool isGrounded(){
        return Physics.CheckSphere(groundCheck.position, groundDistance, ground);

    }

    void Jump(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
