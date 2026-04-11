using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    [Header("UI Toggles")]
    public Toggle taskMading;
    public Toggle taskKomputer;
    public Toggle taskVideo;

    void Awake()
    {
        instance = this;
    }

    // Fungsi untuk mencentang tugas
    public void CentangMading() { taskMading.isOn = true; }
    public void CentangKomputer() { taskKomputer.isOn = true; }
    public void CentangVideo() { taskVideo.isOn = true; }
}