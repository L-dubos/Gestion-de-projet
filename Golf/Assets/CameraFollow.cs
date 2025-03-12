using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le cube à suivre
    public Vector3 offset = new Vector3(0, 3, -5); // Position relative au cube
    public float rotationSpeed = 3f; // Sensibilité de la rotation

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }

    void Update()
    {
        if (target == null) return;

        // Rotation avec le clic droit
        if (Input.GetMouseButton(1)) // 1 = clic droit
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;  // Rotation autour de l'axe Y
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;  // Rotation autour de l'axe X
            pitch = Mathf.Clamp(pitch, -30f, 60f);  // Limite de l'angle de la caméra
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Met à jour la position de la caméra
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);  // Rotation en fonction des entrées
        transform.position = target.position + rotation * offset;  // Applique la rotation à l'offset

        // La caméra regarde toujours le cube
        transform.LookAt(target);
    }
}
