using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Jika yang masuk adalah pemain
        if (other.CompareTag("Player"))
        {
            TaskManager.instance.CentangKomputer();
        }
    }
}