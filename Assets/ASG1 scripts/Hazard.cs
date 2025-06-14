/*
* Author: Schanelle Jackson
* Date: 2025-06-13
* Description: This script handles player death when touching a hazard. 
*              It plays a sound and signals the GameManager to restart the level.
*/

using UnityEngine;

/// <summary>
/// Detects player collision with hazards. Plays a sound and triggers level restart.
/// </summary>
public class Hazard : MonoBehaviour
{
    /// <summary>
    /// AudioSource component used to play the hazard sound.
    /// </summary>
    private AudioSource hazardAudioSource;

    /// <summary>
    /// Unity Start method. Retrieves the AudioSource component and warns if not found.
    /// </summary>
    private void Start()
    {
        // Get AudioSource on the same GameObject
        hazardAudioSource = GetComponent<AudioSource>();

        if (hazardAudioSource == null)
            Debug.LogWarning("No AudioSource found on this object!");
    }

    /// <summary>
    /// Called when another collider enters this object's trigger.
    /// When player hits, it plays a sound and restarts the level with a short delay.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the hazard sound if available
            if (hazardAudioSource != null && hazardAudioSource.clip != null)
                hazardAudioSource.Play();

            // Delay restarting the scene so the sound can be heard
            Invoke("RestartScene", 0.5f);
        }
    }

    /// <summary>
    /// Tells the GameManager to restart the scene after player death.
    /// </summary>
    private void RestartScene()
    {
        GameManager.instance.PlayerDied();
    }
}
