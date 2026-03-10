using UnityEngine;

public class XRInfografisZoom : MonoBehaviour
{
    [Header("XR / Camera Settings")]
    public Transform playerCamera;       // Kamera dari XR Origin
    public float zoomDistance = 0.8f;    // Jarak di depan pemain saat diperbesar
    public float zoomHeightOffset = 0.2f;// Tinggi offset supaya sejajar mata
    public float zoomSpeed = 5f;         // Kecepatan animasi

    [Header("Zoom Settings")]
    public float zoomScaleMultiplier = 1.5f; // Berapa kali membesar

    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Transform originalParent;
    private Vector3 targetPosition;
    private Vector3 targetScale;
    private bool isZoomed = false;

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        originalParent = transform.parent;

        targetPosition = originalPosition;
        targetScale = originalScale;
    }

    void Update()
    {
        // Smooth movement & scale
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * zoomSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * zoomSpeed);
    }

    // Panggil method ini saat infografis diklik (XR Grab Interactable / Raycast)
    public void ToggleZoom()
    {
        if (!isZoomed)
            ZoomIn();
        else
            ZoomOut();
    }

    void ZoomIn()
    {
        isZoomed = true;

        // Detach dari madding supaya posisi world bebas
        transform.SetParent(null);

        // Hitung posisi target di depan pemain
        targetPosition = playerCamera.position + playerCamera.forward * zoomDistance + playerCamera.up * zoomHeightOffset;

        // Scale membesar
        targetScale = originalScale * zoomScaleMultiplier;
    }

    void ZoomOut()
    {
        isZoomed = false;

        // Kembalikan parent ke madding
        transform.SetParent(originalParent);

        // Kembali ke posisi & scale semula
        targetPosition = originalPosition;
        targetScale = originalScale;
    }
}
