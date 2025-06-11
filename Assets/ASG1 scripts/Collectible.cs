// Collectible.cs - Adds to score and destroys object
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touched the collectible
        if (other.CompareTag("Player"))
        {
            // Tell the GameManager to add score
            GameManager.instance.CollectItem();

            // Destroy the collectible so it disappears
            Destroy(gameObject);
        }
    }
}
