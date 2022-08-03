using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfCallBack : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
