using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject arm;

    private bool doorOpen;
    private bool armOpen;
    protected override void Interact()
    {
        doorOpen = !doorOpen;

        armOpen = !armOpen;

        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        arm.GetComponent<Animator>().SetBool("IsOpen", armOpen);
    }
}
