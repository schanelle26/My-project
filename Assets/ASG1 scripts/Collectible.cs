/*
* Author: Schanelle Jackson
* Date: 2025-06-13
* Description: Handles collectible item logic in Unity. When the player enters the trigger area,
*              it plays a sound, increases the player's score /5, and destroys the collectible.
*/

using UnityEngine;

/// <summary>
/// Handles collectible logic using Unity Physics. Collects the item when the player enters the trigger zone.
/// </summary>
public class Collectible : MonoBehaviour
{
    /// <summary>
    /// The audio clip that plays when the collectible is picked up.
    /// </summary>
    public AudioClip collectSound;

    /// <summary>
    /// The AudioSource component that plays the collection sound.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Prevents the collectible from being collected more than once.
    /// </summary>
    private bool collected = false;

    /// <summary>
    /// Unity Start method. Retrieves the AudioSource component attached to this object.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called when another collider enters this object's trigger.
    /// If player touches it and it hasn't been collected yet,
    /// it plays the sound, updates the score, and destroys the object.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;

            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            GameManager.instance.CollectItem();

            Destroy(gameObject, collectSound.length);
        }
    }
}
