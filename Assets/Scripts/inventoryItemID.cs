using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryItemID : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public PlayerInventory PlayerInventory;
    public itemManager itemMan;
    private GameObject image;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player");
        itemMan = GameObject.Find("Managers").transform.GetChild(2).GetComponent<itemManager>();
        PlayerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        image = transform.GetChild(0).gameObject;
        
    }
    private void Update()
    {
        if (weaponInfo == null)
            return;

        if(weaponInfo.Id == 0)
        {
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/NStaff");
        }
        else if(weaponInfo.Id == 1)
        {
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/lStaff");
        }

        // to be added on
    }


    public void onWeaponClicked()
    {
        PlayerInventory.destroyEquipment(this.gameObject);
    }

   

}
