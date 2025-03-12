using UnityEngine;



public class BallRespawn : MonoBehaviour
{
    public Transform respawnPoint; // R�f�rence au point de respawn

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
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // R�initialise la vitesse
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // R�initialise la rotation
    }
}
