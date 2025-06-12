// DoorTrigger.cs - Opens door when player is nearby
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // References to components
    public Animator doorAnimator;
    private AudioSource doorAudioSource;

    // Flags
    private bool isOpen = false;

    void Start()
    {
        // Get AudioSource on the same GameObject
        doorAudioSource = GetComponent<AudioSource>();

        if (doorAnimator == null)
            Debug.LogWarning("Door Animator is not assigned!");

        if (doorAudioSource == null)
            Debug.LogWarning("No AudioSource found on this object!");
    }

    // Called when player enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }

    // Called when player exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
            doorAnimator.SetBool("isOpen", false);
        }
    }

    // For door logic and sound
    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            doorAnimator.SetBool("isOpen", true);

            // Play door sound
            if (doorAudioSource != null)
                doorAudioSource.Play(); // Plays the AudioSource's assigned AudioClip
        }
    }
}
