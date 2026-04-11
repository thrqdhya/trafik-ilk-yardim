using UnityEngine;
using UnityEngine.UI;

public class MissionTrigger : MonoBehaviour
{
    public Toggle targetToggle; // Tarik Toggle ComputerRoom ke sini

    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah yang masuk adalah pemain (XR Origin/Main Camera)
        if (other.CompareTag("MainCamera") || other.gameObject.name.Contains("XR"))
        {
            targetToggle.isOn = true;
            Debug.Log("Misi Masuk Ruangan Selesai!");
        }
    }
}