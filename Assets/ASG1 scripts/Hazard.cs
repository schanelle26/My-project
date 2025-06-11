// Hazard.cs
// Kills the player on contact and restarts the level

using UnityEngine;

public class Hazard : MonoBehaviour
{
    public Transform respawnPoint; // Set this in Inspector (e.g., empty GameObject)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.PlayerDied(other.gameObject, respawnPoint);
        }
    }
}
