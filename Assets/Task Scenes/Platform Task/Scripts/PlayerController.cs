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

    public static float platSpeed;
    public float jumpSpeedRatio;


    // Use this for initialization
    void Start () {
        hasPeaked = true;
        isGrounded = true;
        platSpeed = GameObject.Find("MovingObjects").GetComponent<PlatformMovement>().speed;
	}

    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if ((horz > 0.01 || horz < -0.01 || vert > 0.01) && isGrounded)
        {
            Debug.Log("JUMP");
            startPos = transform.position;
            int platformIndex;
            if (horz > 0)
            {
                platformIndex = 2;
            }
            else if (horz < 0)
            {
                platformIndex = 0;
            }
            else {
                platformIndex = 1;
            }

            if (OncomingPlatforms.sortedPlats[platformIndex] != null)
            {
                Debug.Log("Jumping to " + platformIndex);
                targetObj = OncomingPlatforms.sortedPlats[platformIndex];
            } else
            {
                Debug.Log("Jumping into space");
                targetObj = null;
                targetPos = new Vector3(transform.position.x + (18f - platSpeed * jumpSpeedRatio),
                    transform.position.y,
                    transform.position.z + (5 - (5 * platformIndex)));
            }

            height = 0;
            verticalVelocity = jumpPower;
            curTime = 0;
            isGrounded = false;
            OncomingPlatforms.ClearNext();

            //    hasPeaked = false;
            //    isGrounded = false;
            //    Debug.Log("Jumping...");
            //    initialHeight = transform.position.y;
            //    Jump();
            //}
            //else if (!isGrounded && Input.GetButtonDown("Jump"))
            //{
            //    hasPeaked = true;
            //    //Jump();
            //}
            //else if (!isGrounded)
            //{
            //   // Jump();
            //}
        }

        //Restart game if player falls or hits the reset button
        if (Input.GetButtonDown("Submit") || transform.position.y < -28)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	
	void FixedUpdate () {

        if (!isGrounded)
        {
            JumpForward();
        }

        //Jump();

        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //if (canTurnInAir || isGrounded)
        //    transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * rotateSpeed, 0f));
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

    GameObject targetObj;
    public float jumpTime = 1.3f;

    Vector3 startPos;
    Vector3 targetPos;
    float height;
    public float forwardDist;
    public float lateralDist;
    float verticalVelocity;
    float curTime;

    public void JumpForward()
    {
        if (targetObj != null)
            targetPos = targetObj.transform.position;

        height += verticalVelocity * Time.deltaTime;
        verticalVelocity = Mathf.Lerp(jumpPower, -jumpPower, curTime / jumpTime);
        Vector3 basePos = Vector3.Lerp(startPos, targetPos, curTime / jumpTime);
        Vector3 resultantPos = basePos + (Vector3.up * height);
        transform.position = resultantPos;

        curTime += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
           //Debug.Log("Player is grounded");
            OncomingPlatforms.SortPlats();
            isGrounded = true;
        } 

    }
}
