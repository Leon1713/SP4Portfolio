using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    private CharacterController characterController;
    public float moveSpeed;
    public GameObject gravityManager;
    public GameObject playerControlManager;
    public GameObject orientation;
    public Camera camera;
    public float jumpHeight;
    public bool grounded;
    private Vector3 jumpForce;
    public Vector3 vel;
    public float sprintIncrease;
    public float sprintSpeedOverride;
    float defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        jumpForce = Vector3.zero;
        vel = Vector3.zero;
        characterController = gameObject.GetComponent<CharacterController>();
        defaultSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        orientation.transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
        vel += gravityManager.GetComponent<GravityManager>().gravity * Time.deltaTime; // s = ut + 1/2at^2
        if (grounded && vel.y < 0)
        {
            vel.y = -0.001f; // force cc to detect ground.
        }

        Vector3 movement = Input.GetAxisRaw("Vertical") * orientation.transform.forward + Input.GetAxisRaw("Horizontal") * orientation.transform.right;
        if(!playerControlManager.GetComponent<PlayerControlManager>().isPlayerControl)
        {
            movement = Vector3.zero;
        }
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (sprintSpeedOverride == 0)
                moveSpeed = defaultSpeed + sprintIncrease;
            else
            {
                moveSpeed = sprintSpeedOverride;
            }
        }
        else
        {
            moveSpeed = defaultSpeed;
        }
        movement *= moveSpeed;
        characterController.Move((vel + movement ) * Time.deltaTime);
        grounded = characterController.isGrounded;

        // jumping
        if (playerControlManager.GetComponent<PlayerControlManager>().isPlayerControl)
        {
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                // Jump
                vel.y = Mathf.Sqrt(jumpHeight * -2f * gravityManager.GetComponent<GravityManager>().gravity.y);
            }
        }


        //Vector3 movement = Vector3.zero;
        ////Vector3 jumpForce = new Vector3(0, 0, 0);
        //orientation.transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
        ////no input
        //if(playerControlManager.GetComponent<PlayerControlManager>().isPlayerControl)
        //{
        //    movement = Input.GetAxisRaw("Vertical") * orientation.transform.forward + Input.GetAxisRaw("Horizontal") * orientation.transform.right;
        //    movement *= moveSpeed;
        //    if(grounded && Input.GetKeyDown(KeyCode.Space))
        //    {
        //        vel.y = Mathf.Sqrt(5 * -2f * gravityManager.GetComponent<GravityManager>().gravity.y);
        //    }
        //}
        //vel += gravityManager.GetComponent<GravityManager>().gravity * Time.deltaTime;
        //vel.y = Mathf.Clamp(vel.y, -100, 100);
        //grounded = characterController.isGrounded;
        //if (!grounded)
        //{
        //    jumpForce += gravityManager.GetComponent<GravityManager>().gravity * Time.deltaTime;
        //    characterController.Move((movement + jumpForce + vel) * Time.deltaTime);
        //}
        //else
        //{
        //    characterController.Move((movement + jumpForce + vel) * Time.deltaTime);
        //    vel.y = -0.001f;
        //}

        //if(jumpForce != Vector3.zero)
        //{
        //    jumpForce += gravityManager.GetComponent<GravityManager>().gravity * Time.deltaTime;
        //}
        //else if(jumpForce.y <= 0)
        //{
        //    jumpForce = Vector3.zero;
        //}


    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    // //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
    //    Gizmos.DrawWireSphere(transform.position, gameObject.GetComponent<CharacterController>().height/2);
    //}
    private bool isGround()
    {
        //Ray ray = new Ray(Vector3.zero, Vector3.down);
        //RaycastHit hit;
        Collider[] hitColliders = new Collider[10];
        int numColliders = 0;
        numColliders = Physics.OverlapSphereNonAlloc(transform.position, characterController.height/2 , hitColliders);
        //if (Physics.SphereCast(ray, characterController.radius * 2, out hit,characterController.radius))
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        for(int i = 0; i < numColliders; ++i)
        {
            if(hitColliders[i].gameObject.layer == LayerMask.NameToLayer("floor"))
            {
                return true;
            }
        }
        return false;
    }

}
