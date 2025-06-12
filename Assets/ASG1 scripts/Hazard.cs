// Hazard.cs
// Kills the player on contact and restarts the level
// Hazard.cs - Detects collision with player and tells GameManager to respawn
// Hazard.cs
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Tells GameManager to restart scene
            GameManager.instance.PlayerDied();
        }
    }
}
