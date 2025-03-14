using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Transform platform; // La plateforme à déplacer
    public Vector3 targetPosition; // La position finale
    public float speed = 2f; // Vitesse de montée
    public string tag;

    private Vector3 initialPosition;
    private bool isActivated = false;

    void Start()
    {
        initialPosition = platform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag)) // Assure-toi que le joueur a le tag "Player"
        {
            isActivated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            isActivated = false;
        }
    }

    void Update()
    {
        if (isActivated)
        {
            platform.position = Vector3.Lerp(platform.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            platform.position = Vector3.Lerp(platform.position, initialPosition, Time.deltaTime * speed);
        }
    }
}