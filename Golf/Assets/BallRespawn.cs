using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Transform respawnPoint; // Référence au point de respawn

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Réinitialise la vitesse
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Réinitialise la rotation
    }
}
