using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlayerControl;

    private void Start()
    {
        isPlayerControl = true;
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            changeMode();
        }
    }

    void changeMode()
    {
        if (isPlayerControl == true)
        {
            isPlayerControl = false;
        }
        else
        {
            isPlayerControl = true;
        }
    }
}
