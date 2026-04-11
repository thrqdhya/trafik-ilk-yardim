using UnityEngine;

public class XRInspectObject : MonoBehaviour
{
    public Transform cameraTransform; // Tarik Main Camera ke sini
    public float distanceToFace = 0.5f; // Jarak dari muka
    public float smoothSpeed = 10f;

    private bool isInspecting = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (isInspecting)
        {
            // Posisi target: di depan kamera
            Vector3 targetPos = cameraTransform.position + (cameraTransform.forward * distanceToFace);
            // Rotasi target: menghadap kamera
            Quaternion targetRot = Quaternion.LookRotation(transform.position - cameraTransform.position);

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smoothSpeed);
        }
        else
        {
            // Balik ke mading
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * smoothSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * smoothSpeed);
        }
    }

    public void ToggleInspect()
    {
        isInspecting = !isInspecting;
        if (TaskManager.instance != null)
        {
            TaskManager.instance.CentangMading();
        }
    }
}