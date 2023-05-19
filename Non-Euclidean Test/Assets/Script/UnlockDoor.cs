using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private Animation DoorOpen;
    private Animation DoorClose;
    private Animator animator;
    private string doorOpen = "DoorOpen";

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play(doorOpen);
        }
    }
}
