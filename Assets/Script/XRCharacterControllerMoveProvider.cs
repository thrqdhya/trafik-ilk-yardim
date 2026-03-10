using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(CharacterController))]
public class XRCharacterControllerMoveProvider : LocomotionProvider
{
    [Header("Movement Settings")]
    public float moveSpeed = 1.5f;
    public Transform forwardSource; // biasanya Main Camera

    [Header("Gravity Settings")]
    public float gravity = -9.81f;
    private float verticalVelocity = 0f;

    private CharacterController characterController;

    // Gunakan override untuk menghindari warning
    protected override void Awake()
    {
        base.Awake(); // panggil Awake bawaan LocomotionProvider
        characterController = GetComponent<CharacterController>();

        if (forwardSource == null)
        {
            forwardSource = Camera.main.transform;
        }
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Ambil input dari Unity Input System (WASD / XR Device Simulator)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);

        // Hitung movement vector
        Vector3 move = (forwardSource.forward * input.y + forwardSource.right * input.x);
        move.y = 0f;
        if (move.magnitude > 1f)
            move.Normalize();
        move *= moveSpeed;

        // Gravity
        if (!characterController.isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        else if (verticalVelocity < 0f)
        {
            verticalVelocity = -2f; // agar menempel ke tanah
        }

        move.y = verticalVelocity;

        // Gerakkan Character Controller
        characterController.Move(move * Time.deltaTime);

        // ⚡ Tidak perlu Begin/EndLocomotion untuk test
    }
}
