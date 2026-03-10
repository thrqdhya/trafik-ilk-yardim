using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(CharacterController))]
public class SimpleGravity : MonoBehaviour
{
    [Header("Gravity Settings")]
    public float gravity = -9.81f;           // percepatan gravitasi
    public float groundedOffset = -0.14f;    // offset untuk raycast ke tanah
    public float fallMultiplier = 1.0f;      // percepatan tambahan saat jatuh
    public LayerMask groundLayer;            // layer tanah / bangunan

    private CharacterController characterController;
    private float verticalVelocity = 0f;
    private bool isGrounded;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckGrounded();
        ApplyGravity();
    }

    void CheckGrounded()
    {
        // Pakai Sphere untuk cek grounded
        Vector3 spherePosition = transform.position + Vector3.up * groundedOffset;
        isGrounded = Physics.CheckSphere(spherePosition, characterController.radius * 0.9f, groundLayer, QueryTriggerInteraction.Ignore);

        if (isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f; // dikit negatif supaya menempel ke tanah
    }

    void ApplyGravity()
    {
        if (!isGrounded)
        {
            verticalVelocity += gravity * fallMultiplier * Time.deltaTime;
        }

        Vector3 motion = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        characterController.Move(motion);
    }
}
