// Hazard.cs
// Kills the player on contact and restarts the level
// Detects collision with player and tells GameManager to respawn

using UnityEngine;

public class Hazard : MonoBehaviour
{
    private AudioSource hazardAudioSource;

    private void Start()
    {
        hazardAudioSource = GetComponent<AudioSource>();

        if (hazardAudioSource == null)
            Debug.LogWarning("No AudioSource found on the hazard object!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play sound
            if (hazardAudioSource != null && hazardAudioSource.clip != null)
                hazardAudioSource.Play();

            // Tell GameManager to restart scene
            GameManager.instance.PlayerDied();
        }
    }
}
