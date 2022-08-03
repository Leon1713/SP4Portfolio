using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStaffFire : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject playerObject;
    public PlayerInventory playerInventory;
    public GameObject bulletPrefab;
    public Transform spellExitPoint;

    private void Start()
    {
        playerObject = GameObject.Find("Player");
        playerCamera = playerObject.transform.Find("Main Camera").gameObject.GetComponent<Camera>();
        playerInventory = playerObject.GetComponent<PlayerInventory>();
    }

    private void OnDrawGizmos()
    {
        Vector3 targetPoint = playerCamera.transform.position + (playerCamera.transform.forward);
        //Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
        //{
        //    //if (hit.transform.gameObject.layer != LayerMask.NameToLayer("Player") || hit.transform.gameObject.layer != LayerMask.NameToLayer("ammo"))
        //    //{
        //    //    targetPoint = hit.point;
        //    //}
        //}
        // fire in camera dir
        // set element
        //targetPoint -= spellExitPoint.position;
        Gizmos.DrawLine(spellExitPoint.position, targetPoint);
    }
    private void Update()
    {
        Vector3 targetPoint = playerCamera.transform.position + (playerCamera.transform.forward * 150);
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,float.PositiveInfinity,~LayerMask.NameToLayer("ammo")))
        {
            if (hit.transform.gameObject.layer != LayerMask.NameToLayer("Player") || hit.transform.gameObject.layer != LayerMask.NameToLayer("ammo"))
            {
                if((hit.point - transform.position).sqrMagnitude > 25)
                targetPoint = hit.point;
            }
        }
        // fire in camera dir
        // set element
        targetPoint -= spellExitPoint.position;
        if(gameObject.GetComponent<WeaponConcrete>().pickUpSlotNum == playerObject.GetComponent<PlayerEquipController>().currEquipSlot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerObject.GetComponent<PlayerStats>().mana > 0)
                {
                    //spawn gameobject
                    Vector3 tmp = new Vector3(targetPoint.normalized.x, targetPoint.normalized.y, targetPoint.normalized.z);
                    GameObject tempBulletHandle = GameObject.Instantiate(bulletPrefab);
                    tempBulletHandle.transform.position = spellExitPoint.position;
                    tempBulletHandle.GetComponent<BulletElement>().weapon = spellExitPoint.parent.GetComponent<WeaponConcrete>().weaponInfo;
                    tempBulletHandle.GetComponent<Rigidbody>().AddForce(tmp * 30, ForceMode.Impulse);

                    playerObject.GetComponent<PlayerStats>().mana--;
                }
            }
        }
        else
        {
            return;
        }
    }
}
