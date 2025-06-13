// Collectible.cs
// Plays audio, adds to score, then destroys the collectible

using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;         // Sound is dragged here
    private AudioSource audioSource;

    private bool collected = false;        // Prevent double collection

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

            // Delay destroy so audio can play
            Destroy(gameObject, collectSound.length);
        }
    }
}                    