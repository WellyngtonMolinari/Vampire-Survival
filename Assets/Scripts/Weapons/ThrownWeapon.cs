using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownWeapon : MonoBehaviour
{
    public Weapon weapon;
    private float throwPower;
    public Rigidbody2D theRB;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SetThrowPower();
        theRB.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
        rotateSpeed = Random.Range(0.5f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360 * Time.deltaTime * Mathf.Sign(theRB.velocity.x)));
    }

    public void SetThrowPower()
    {
        // access speed variable in "weapon.cs" script
        WeaponStats currentStats = weapon.stats[weapon.weaponLevel];
        throwPower = currentStats.speed;
    }
}
