using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public float moveSpeed;

    public Animator anim;

    public float pickupRange = 1.5f;

    //public Weapon activeWeapon;

    public List<Weapon> unassignedWeapons, assignedWeapons;

    // Start is called before the first frame update
    void Start()
    {
        AddWeapon(Random.Range(0, unassignedWeapons.Count));
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if (moveInput != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void AddWeapon(int weaponNumber)
    {
        if (weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);

            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }

    //Same function with a different type of input (float)
    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);

        //add unassigned weapons to assigned list
        assignedWeapons.Add(weaponToAdd);
        //remove from unassigned weapons list
        unassignedWeapons.Remove(weaponToAdd);
    }
}
