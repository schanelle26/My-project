// Hazard.cs
// Kills the player on contact and restarts the level
// Detects collision with player and tells GameManager to respawn

using UnityEngine;

public class Hazard : MonoBehaviour
{
    private AudioSource hazardAudioSource;

    private void Start()
    {
        // Get AudioSource on the same GameObject
        hazardAudioSource = GetComponent<AudioSource>();

        if (hazardAudioSource == null)
            Debug.LogWarning("No AudioSource found on this object!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // To play the hazard sound 
            if (hazardAudioSource != null && hazardAudioSource.clip != null)
                hazardAudioSource.Play();

            // Delay restarting the scene so the sound can be heard
            Invoke("RestartScene", 0.5f); // 0.5 seconds delay
        }
    }

    private void RestartScene()
    {
        GameManager.instance.PlayerDied();
    }
}
