using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DudukController : MonoBehaviour
{
    public Transform seatAnchor;       // Tarik objek Seat_Anchor ke sini
    public Transform xrOrigin;         // Tarik objek XR Origin (XR Rig) ke sini
    public Toggle computerRoomToggle;  // Tarik Toggle misi 2 ke sini

    public void PindahKeKursi()
    {
        CharacterController cc = xrOrigin.GetComponent<CharacterController>();

        // Matikan physics secara total
        if (cc != null) cc.enabled = false;

        // Paksa pindah posisi dan rotasi
        xrOrigin.position = seatAnchor.position;
        xrOrigin.rotation = seatAnchor.rotation;

        // Kunci: Sinkronisasi posisi secara paksa ke engine physics
        Physics.SyncTransforms();

        // JANGAN nyalakan CC dulu kalau masih mental. 
        // Kita coba nyalakan lagi setelah jeda sangat singkat (opsional)
        if (cc != null) cc.enabled = true;

        if (computerRoomToggle != null) computerRoomToggle.isOn = true;
        Debug.Log("Duduk paksa sukses!");
    }
}