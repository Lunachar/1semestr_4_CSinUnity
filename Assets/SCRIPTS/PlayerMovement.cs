using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform Transform_Body;
    [SerializeField] float MovementSpeed = 5f;

    Rigidbody rb;
    public float JumpForce = 300f;
    private bool _isGrounded;
    Vector3 Vector3_Move_Direction = new Vector3();


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3_Move_Direction = Transform_Body.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + Vector3_Move_Direction * MovementSpeed * Time.deltaTime);
        JumpLogic();
    }
    private void JumpLogic()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }
    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
