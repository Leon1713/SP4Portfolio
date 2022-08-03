using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEquipController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public int currEquipSlot;
    CharacterController characterController;
    public Transform rightHand;  
    public GameObject debugPoint;
    public Text pickUpText;
    public GameObject startWeapon;
    public TextMeshProUGUI weaponNameText;

    void Start()
    {
        pickUpText.enabled = false;
        weaponNameText.enabled = false;
        currEquipSlot = 0;
        characterController = Player.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        
        
            for (int i = 0; i < Player.GetComponent<PlayerInventory>().equipped.Length; ++i)
            {
                if (i != currEquipSlot && Player.GetComponent<PlayerInventory>().equipped[i] != null)
                {
                    Player.GetComponent<PlayerInventory>().equipped[i].SetActive(false);
                }
                else if(Player.GetComponent<PlayerInventory>().equipped[i] != null)
                {
                    Player.GetComponent<PlayerInventory>().equipped[i].SetActive(true);
                }
            }
        
        Ray ray = new Ray(Player.GetComponent<PlayerCharacterController>().orientation.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.transform.gameObject.layer != LayerMask.NameToLayer("ammo") && hit.transform.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                debugPoint.transform.position = hit.point;
            }
            if (hit.transform.gameObject.layer != LayerMask.NameToLayer("Player") && (hit.point - Player.GetComponent<PlayerCharacterController>().orientation.transform.position).magnitude <= 2f)
            {
                if (hit.transform.gameObject.GetComponent<WeaponConcrete>() != null)
                {
                    pickUpText.enabled = true;
                    weaponNameText.text = hit.transform.gameObject.GetComponent<WeaponConcrete>().weaponInfo.name;
                    weaponNameText.enabled = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pickUpEquipment(hit.transform.gameObject.GetComponent<WeaponConcrete>().weaponInfo);
                        Destroy(hit.transform.gameObject);
                    }

                }
                else
                {
                    pickUpText.enabled = false;
                    weaponNameText.enabled = false;
                }
            }
        }
        else
        {
            weaponNameText.enabled = false;
            pickUpText.enabled = false;
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            ++currEquipSlot;
        }
        else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            --currEquipSlot;
        }
        if(currEquipSlot > 3)
        {
            currEquipSlot = 0;
        }
        else if(currEquipSlot < 0)
        {
            currEquipSlot = 3;
        }

    }

    void pickUpEquipment(WeaponInfo weapon)
    {

        Player.GetComponent<PlayerInventory>().pickUpEquipment(weapon, currEquipSlot);
    }
   
}
