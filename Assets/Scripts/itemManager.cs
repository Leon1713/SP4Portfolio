using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public GameObject[] weaponList;
    private void Awake()
    {
        weaponList = Resources.LoadAll<GameObject>("Weapons");
    }
    
    public GameObject getItemByID(uint Id)
    {
        for(int i = 0; i < weaponList.Length; ++i)
        {
            if(weaponList[i].GetComponent<WeaponConcrete>().uid == Id)
            {
                return weaponList[i];
            }
        }
        return null;
    }
}
