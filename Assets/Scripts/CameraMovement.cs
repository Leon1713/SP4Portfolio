using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool gameMode; // if 1 is in game if 0 out of game / noclip
    private  float yawInput; // rotation along y-axis :  X MOUSE
    private float pitchInput; // rotation along x-axis : Y MOUSE
    public float mouseSensitivity;
    public float camMoveSpeed;
    public GameObject Player;
    public GameObject Eyes;
    public GameObject playerControlManager;
    Vector3 rotation;
    Vector3 dir;

    // Update is called once per frame
    // Doing Gamemode = 0;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rotation.Set(0, 0,0);
        //Player = GameObject.Find("Player");
        //Eyes = GameObject.Find("eyes");

    }

    void updateRotation(GameObject input)
    {
        if (input == null)
            return;
        input.transform.rotation = Quaternion.Euler(rotation);
        // Update the transform of an object

    }

    void moveFlyCam()
    {
        Vector3 move = Input.GetAxis("Vertical") * Vector3.forward + Input.GetAxis("Horizontal") * Vector3.right;
        transform.Translate (move * camMoveSpeed * Time.deltaTime, Space.Self);
    }

    void attachCam()
    {
        if(Player != null && gameMode == true)
        {
            transform.position = Eyes.transform.position;
        }
    }
    void updateTranslate(GameObject input)
    {
        if (input == null)
            return;
        dir = input.transform.forward;
    }
    // change rotation variable according to gamemode
    void updateMouse()
    {
        yawInput = mouseSensitivity * Input.GetAxis("Mouse X");
        pitchInput = mouseSensitivity * -Input.GetAxis("Mouse Y");
        rotation.x += pitchInput;
        rotation.y += yawInput;
       // if (!gameMode)
        {
            rotation.x = Mathf.Clamp(rotation.x, -90, 90);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
            
        gameMode = playerControlManager.GetComponent<PlayerControlManager>().isPlayerControl;
        if(Cursor.lockState == CursorLockMode.None)
        {
            return;
        }
        updateMouse();
        updateRotation(this.gameObject);

        if (gameMode == true)
        {
            attachCam();
        }
        else
        {
            moveFlyCam();
        }
    }
    
}

