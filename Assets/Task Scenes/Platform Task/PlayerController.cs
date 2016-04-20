using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    internal bool isGrounded;
    internal bool hasPeaked;

    public float jumpHorizontalSpeed;
    public float jumpPower;
    public float jumpGravity;
    public float jumpHeight;
    public float rotateSpeed;
    public bool canTurnInAir;

    internal float initialHeight;




    // Use this for initialization
    void Start () {
        hasPeaked = true;
        isGrounded = false;
	}

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(3);
        }
    }
	
	void FixedUpdate () {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            hasPeaked = false;
            isGrounded = false;
            initialHeight = transform.position.y;
            Jump();
        } 
        else if (isGrounded == false)
        {
            Jump();
        }

        //if (Input.GetAxis("Horizontal") > 0)
        //{
        if (canTurnInAir || isGrounded)
            transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * rotateSpeed, 0f));
        //}
    }

    public void Jump()
    {
        if (transform.position.y >= initialHeight + jumpHeight)
        {
            hasPeaked = true;
            Debug.Log("Player jump has peaked");
        }

        transform.Translate(Vector3.forward * Time.deltaTime * jumpHorizontalSpeed); //Move forward

        if (!hasPeaked)
            transform.Translate(Vector3.up * Time.deltaTime * jumpPower); //Move up
        else
            transform.Translate(Vector3.down * Time.deltaTime * jumpGravity); //Move down

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform" && isGrounded == false)
        {
            Debug.Log("Player is grounded");
            isGrounded = true;
        } 

    }
}
