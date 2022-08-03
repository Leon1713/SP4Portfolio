using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletElement : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponInfo weapon; // ref to weapon
    Color color; // change color for different element
    public GameObject particleObj;
    public GameObject trailObj;
    public ParticleSystem.MainModule mainModule;
    public TrailRenderer line;
    public float expireRate;
    float timeCount;
    public bool isPlayerBullet;
    void Start()
    {
        timeCount = 0;
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("ammo"));
        //mainModule = particleObj.GetComponent<ParticleSystem>().main;
       //weapon = gameObject.transform.parent.parent.parent.gameObject.GetComponent<WeaponConcrete>().weaponInfo;
        //if(weapon.element == WeaponInfo.Element.fire)
        //{
        //    color = Color.red;
        //    mainModule.startColor = new ParticleSystem.MinMaxGradient(color);
        //    line.startColor = color;
           
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount > expireRate)
        {
            DestroyImmediate(gameObject);
            return;
        }
        timeCount += Time.deltaTime;
    }
}
