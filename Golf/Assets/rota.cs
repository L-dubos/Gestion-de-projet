using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public enum RotationAxis { X, Y, Z }

    [Header("Paramètres de rotation")]
    [SerializeField] private RotationAxis axis = RotationAxis.Y;
    [SerializeField] private float speed = 100f;
    [SerializeField] private bool reverse = false;

    [Header("Activation")]
    [SerializeField] private bool rotateOnCollision = false;
    [SerializeField] private string requiredTag = "";

    private bool shouldRotate = true;

    void Update()
    {
        if (shouldRotate)
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
        Vector3 rotationVector = Vector3.zero;

        switch (axis)
        {
            case RotationAxis.X: rotationVector = Vector3.right; break;
            case RotationAxis.Y: rotationVector = Vector3.up; break;
            case RotationAxis.Z: rotationVector = Vector3.forward; break;
        }

        float rotationSpeed = (reverse ? -1 : 1) * speed * Time.deltaTime;
        transform.Rotate(rotationVector * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!rotateOnCollision) return;

        if (string.IsNullOrEmpty(requiredTag) || collision.gameObject.CompareTag(requiredTag))
        {
            shouldRotate = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!rotateOnCollision) return;

        if (string.IsNullOrEmpty(requiredTag) || collision.gameObject.CompareTag(requiredTag))
        {
            shouldRotate = false;
        }
    }
}
