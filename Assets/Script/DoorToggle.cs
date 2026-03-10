using UnityEngine;

public class DoorToggle : MonoBehaviour
{
    [Header("Door Settings")]
    public float openAngle = 90f;     // Sudut rotasi pintu saat terbuka
    public float openSpeed = 2f;      // Kecepatan animasi
    private bool isOpen = false;      // Status pintu
    private Quaternion closedRotation;
    private Quaternion openedRotation;

    void Start()
    {
        // Simpan rotasi awal sebagai tertutup
        closedRotation = transform.localRotation;

        // Hitung rotasi terbuka (Y axis)
        openedRotation = Quaternion.Euler(transform.localEulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        // Smooth rotasi
        if (isOpen)
            transform.localRotation = Quaternion.Slerp(transform.localRotation, openedRotation, Time.deltaTime * openSpeed);
        else
            transform.localRotation = Quaternion.Slerp(transform.localRotation, closedRotation, Time.deltaTime * openSpeed);
    }

    // Panggil method ini saat pintu ditekan / diklik
    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}