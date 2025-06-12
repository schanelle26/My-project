// DoorTrigger.cs - Opens door when player is nearby
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            doorAnimator.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            doorAnimator.SetBool("isOpen", false);
    }
}
