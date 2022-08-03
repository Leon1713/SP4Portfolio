using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPortalHit : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.GetComponent<SceneChanger>().ChangeScene("portalWin");
        }
    }
}
