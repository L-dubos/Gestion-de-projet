using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformTrigger : MonoBehaviour
{

    private Collider platformCollider;

    // Start is called before the first frame update
    void Start()
    {
        platformCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Ignore la collision entre la balle et la plateforme
            Physics.IgnoreCollision(collision.collider, platformCollider, true);
        }
    }
}
