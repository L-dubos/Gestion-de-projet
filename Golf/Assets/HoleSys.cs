using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [Header("Configuration")]
    public string targetTag = "Player";

    [Header("Points de Téléportation")]
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    [Header("point de spawn")]
    public GameObject linkedSpawn1;
    public GameObject linkedSpawn2;

    [Header("Objets lier au spawn")]
    public GameObject linkedObject1;
    public GameObject linkedObject2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colide ok");
        if (other.CompareTag(targetTag))
        {
            linkedSpawn1.transform.position = spawnPoint1.position;
            linkedObject1.transform.position = spawnPoint1.position;
            linkedSpawn2.transform.position = spawnPoint2.position;
            linkedObject2.transform.position = spawnPoint2.position;
        }
    }
}