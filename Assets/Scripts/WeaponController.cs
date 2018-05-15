using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    // Weapon Selection
    public WeaponSelection weaponSelect = WeaponSelection.None;
    Weapon weapon;

    // Get Game Objects

	// Use this for initialization
	void Start () {
		if (weaponSelect == WeaponSelection.Glock)
        {
            Glock weapon = new Glock();
        }
        else if (weaponSelect == WeaponSelection.Ithaca37)
        {
            Ithaca37 weapon = new Ithaca37();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum WeaponSelection { None, Glock, Ithaca37 };

interface IFireable
{
    void Aim();

    void Shoot();
}

interface IReloadable
{
    void Reload();
}

interface IMelee
{
    void Melee();
}

abstract class Weapon
{

}

abstract class Firearm : Weapon, IFireable, IReloadable
{
    public int magazineSize;
    public float bulletDamage;
    public float reloadSpeed;
    public float zoom;
    public bool isAiming;

    private int loadedAmmo;

    public abstract void Aim();

    public abstract void Shoot();

    public abstract void Reload();
}

abstract class MeleeWeapons : Weapon, IMelee
{
    public float meleeDamage;

    public abstract void Melee();
}

class Glock : Firearm
{
    public int magazineSize = 17;
    public float bulletDamage = 20f;
    public float reloadSpeed = 2.5f;
    public float zoom = 1.0f;

    private int loadedAmmo = 0;

    public override void Aim()
    {
        if (Input.GetButton("Aim"))
        {
            isAiming = true;
            
        }
        else
        {
            isAiming = false;
        }
    }

    public override void Shoot()
    {
        if (isAiming)
        {

        }
    }

    public override void Reload()
    {
        // THIS DOESNT TAKE INTO CONSIDERATION THE PLAYER'S AMMO!
        if (Input.GetButtonDown("Reload") && loadedAmmo<magazineSize)
        {
            loadedAmmo = magazineSize;
        }
    }
}

class Ithaca37 : Firearm
{
    public int magazineSize = 4;
    public float bulletDamage = 5f;
    public float reloadSpeed = 0.75f;
    public float zoom = 1.0f;

    private int loadedAmmo = 0;

    public override void Aim()
    {
        if (Input.GetButton("Aim"))
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }
    }

    public override void Shoot()
    {
        if (isAiming)
        {

        }
    }

    public override void Reload()
    {
        // THIS DOESNT TAKE INTO CONSIDERATION THE PLAYER'S AMMO!
        if (Input.GetButtonDown("Reload") && loadedAmmo < magazineSize)
        {
            loadedAmmo = magazineSize;
        }
    }
}
