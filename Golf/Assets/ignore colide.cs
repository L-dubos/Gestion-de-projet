using UnityEngine;
using System.Collections.Generic;

public class IgnoreCollisionWithTag : MonoBehaviour
{
    [Header("Tag de l'objet à ignorer")]
    [SerializeField] private string tagToIgnore;

    [Tooltip("Vérifie continuellement les nouvelles collisions à ignorer")]
    [SerializeField] private bool checkContinuously = false;

    private Collider ownCollider;
    private HashSet<GameObject> ignoredObjects = new HashSet<GameObject>();

    void Start()
    {
        if (string.IsNullOrEmpty(tagToIgnore))
        {
            Debug.LogWarning($"[{name}] Aucun tag défini pour ignorer les collisions.");
            return;
        }

        ownCollider = GetComponent<Collider>();
        if (ownCollider == null)
        {
            Debug.LogWarning($"[{name}] Aucun Collider trouvé.");
            return;
        }

        IgnoreCollisionsWithTag();
    }

    void Update()
    {
        if (checkContinuously)
        {
            IgnoreCollisionsWithTag();
        }
    }

    private void IgnoreCollisionsWithTag()
    {
        GameObject[] objectsToIgnore = GameObject.FindGameObjectsWithTag(tagToIgnore);

        foreach (GameObject obj in objectsToIgnore)
        {
            if (obj == gameObject || ignoredObjects.Contains(obj))
                continue;

            Collider otherCollider = obj.GetComponent<Collider>();
            if (otherCollider != null)
            {
                Physics.IgnoreCollision(ownCollider, otherCollider, true);
                ignoredObjects.Add(obj);
                Debug.Log($"[{name}] Collision ignorée avec {obj.name}");
            }
        }
    }
}