using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventory; // grid
    public GameObject inventoryPanel; // grid
    private bool isPauseMenu;
    public List<WeaponInfo> equipments;
    public GameObject[] equipped = new GameObject[4] { null, null, null, null };
    public GameObject player;
    public Transform rightHand;
    public GameObject itemMan;
    public GameObject dropPoint;
    public LayerMask weaponLayer;

    private void Start()
    {
        isPauseMenu = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isPauseMenu)
            {
                isPauseMenu = false;
            }
            else
            {
                isPauseMenu = true;
            }
        }
        if(isPauseMenu)
        {
            inventoryPanel.SetActive(true);
            Cursor.lockState =  CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventoryPanel.SetActive(false);
        }
    }

    public void pickUpEquipment(WeaponInfo equip)
    {
        int temp = 0;
        int tempVal = weaponLayer.value;
        while (tempVal > 0 && temp < 100)
        {
            tempVal = tempVal >> 1;
            ++temp;
        }
        for (int i = 0; i < 4; ++i)
        {
            if (equipped[i] == null)
            {
                equipped[i] = GameObject.Instantiate(equip.gameObjectReference, rightHand);
                equipped[i].GetComponent<Rigidbody>().isKinematic = true;
                equipped[i].GetComponent<Collider>().isTrigger = true;
                equipped[i].GetComponent<WeaponConcrete>().manager = itemMan;
                equipped[i].layer = temp - 1;
                foreach (GameObject child in equipped[i].transform)
                {
                    child.layer = temp - 1;
                }
                equipped[i].GetComponent<WeaponConcrete>().pickUpSlotNum = i;
                equipped[i].SetActive(false);
                return;
            }
        }
        equipments.Add(equip);
        GameObject iconHandler = GameObject.Instantiate(Resources.Load<GameObject>("UI/gridData"),inventory.transform);
        iconHandler.GetComponent<inventoryItemID>().weaponInfo = equip;

    }

    public void destroyEquipment(GameObject weapon) // click to drop equip in inv
    {
        // destroy and drop
        GameObject temp = GameObject.Instantiate(weapon.GetComponent<inventoryItemID>().weaponInfo.gameObjectReference, dropPoint.transform.position, weapon.GetComponent<inventoryItemID>().weaponInfo.gameObjectReference.transform.rotation);
        temp.SetActive(true);
        DestroyImmediate(weapon);
    }

    public void pickUpEquipment(WeaponInfo equip, int slotnumber)
    {
        int temp = 0;
        int tempVal = weaponLayer.value;
        while (tempVal > 0 && temp < 100)
        {
            tempVal = tempVal >> 1;
            ++temp;
        }
        if (equipped[slotnumber] != null)
        {
            for(int i = 0; i < 4; ++i)
            {
                if(equipped[i] == null)
                {
                    equipped[i] = GameObject.Instantiate(equip.gameObjectReference,rightHand);
                    equipped[i].GetComponent<Rigidbody>().isKinematic = true;
                    equipped[i].GetComponent<Collider>().isTrigger = true;
                    equipped[i].GetComponent<WeaponConcrete>().manager = itemMan;

                    equipped[i].layer = temp - 1;
                    foreach(Transform child in equipped[i].transform)
                    {
                        child.gameObject.layer = temp - 1;
                    }
                    equipped[i].GetComponent<WeaponConcrete>().pickUpSlotNum = i;
                    equipped[i].SetActive(false);
                    return;
                }
            }
        }
        else
        {
            if(equipped[slotnumber] == null)
            {
                equipped[slotnumber] = GameObject.Instantiate(equip.gameObjectReference, rightHand);
                equipped[slotnumber].GetComponent<Rigidbody>().isKinematic = true;
                equipped[slotnumber].GetComponent<Collider>().isTrigger = true;
                equipped[slotnumber].GetComponent<WeaponConcrete>().manager = itemMan;
                equipped[slotnumber].layer = temp - 1;
                foreach (Transform child in equipped[slotnumber].transform)
                {
                    child.gameObject.layer = temp - 1;
                }
                equipped[slotnumber].GetComponent<WeaponConcrete>().pickUpSlotNum = slotnumber;
                equipped[slotnumber].SetActive(false);
                return;
            }
        }
        equipments.Add(equip);
        GameObject iconHandler = GameObject.Instantiate(Resources.Load<GameObject>("UI/gridData"), inventory.transform);
        iconHandler.GetComponent<inventoryItemID>().weaponInfo = equip;
    }

    public void deleteEquippedEquips(WeaponInfo equip) // drop equip
    {
        equipped[player.GetComponent<PlayerEquipController>().currEquipSlot] = null;
    }
  
}
