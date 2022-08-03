using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    [CreateAssetMenu(fileName = "new Weapon", menuName = "weapon")]
public class WeaponInfo  : Weapon
{
    public static WeaponInfo copyWeapon(WeaponInfo copy) // dk why i create this method
    {
        WeaponInfo temp = new WeaponInfo();
        temp.name = copy.name;
        temp.Id = copy.Id;
        temp.type = copy.type;
        temp.phyDamage = copy.phyDamage;
        temp.magicDamage = copy.magicDamage;
        temp.element = copy.element;
        return temp;
    }
    //public GameObject phyWeaponOBJ;
    public new string name;
    public uint Id; // 0 - wood staff....
    public enum weaponType
    {
        staff = 0,
        sword,
        bow
    };

    public enum Element
    {
        non = 0,
        fire,
        electricity,
        heal,
        ice
    }
    public Element element;
    public weaponType type; // determine projectile or melee
    public float phyDamage; // if bow or sword
    public float magicDamage;
}
