using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject[] prefabsList;
    private void Start()
    {
        prefabsList = Resources.LoadAll<GameObject>("Weapons");
    }
   
}
