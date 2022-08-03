using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConcrete : MonoBehaviour
{
    public GameObject manager;
    bool isWeapon;
    public WeaponInfo weaponInfo;
    public  int pickUpSlotNum = -1;
    // Object specific 
    public uint uid;
    private void Start()
    {
        

        manager = GameObject.Find("itemManager");
        switch(uid)
        {
           
            case 0:
                weaponInfo = WeaponInfo.Instantiate((WeaponInfo)Resources.Load("Weapons/WeaponTemplate"));
                weaponInfo.element = WeaponInfo.Element.fire;
                weaponInfo.Id = uid;
                weaponInfo.name = "Wooden staff of fire";
                weaponInfo.gameObjectReference = manager.GetComponent<itemManager>().getItemByID(uid);
                break;
            case 1:
                weaponInfo = WeaponInfo.Instantiate((WeaponInfo)Resources.Load("Weapons/WeaponTemplate"));
                weaponInfo.element = WeaponInfo.Element.fire;
                weaponInfo.Id = uid;
                weaponInfo.name = "Legendary staff of fire";
                weaponInfo.gameObjectReference = manager.GetComponent<itemManager>().getItemByID(uid);
                break;





        }
    }
}

