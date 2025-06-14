/*
* Author: Schanelle Jackson
* Date: 2025-06-13
* Description: Controls door opening and closing based on player proximity using trigger collider.
*/

using UnityEngine;

/// <summary>
/// Controls the door behavior, opening the door and playing sound when the player enters the trigger area.
/// </summary>
public class DoorTrigger : MonoBehaviour
{
    /// <summary>
    /// Animator component controlling door animations.
    /// </summary>
    public Animator doorAnimator;

    /// <summary>
    /// AudioSource component for playing door sounds.
    /// </summary>
    private AudioSource doorAudioSource;

    /// <summary>
    /// Flag indicating whether the door is currently open.
    /// </summary>
    private bool isOpen = false;

    /// <summary>
    /// Called before the first frame update. Initializes component references and checks for missing components.
    /// </summary>
    private void Start()
    {
        doorAudioSource = GetComponent<AudioSource>();

        if (doorAnimator == null)
            Debug.LogWarning("Door Animator is not assigned!");

        if (doorAudioSource == null)
            Debug.LogWarning("No AudioSource found on this object!");
    }

    /// <summary>
    /// Called when another collider enters this trigger collider.
    /// Opens the door if the collider belongs to player.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }

    /// <summary>
    /// Called when another collider exits this trigger collider.
    /// Closes the door if the collider belongs to the player.
    /// </summary>
    /// <param name="other">The collider that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
            if (doorAnimator != null)
                doorAnimator.SetBool("isOpen", false);
        }
    }

    /// <summary>
    /// Opens the door if it is not already open and plays the door opening sound.
    /// </summary>
    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;

            if (doorAnimator != null)
                doorAnimator.SetBool("isOpen", true);

            if (doorAudioSource != null)
                doorAudioSource.Play();
        }
    }
}
