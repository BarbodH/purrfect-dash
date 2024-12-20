using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform bottomPivot;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip jumpAudioClip;
    [SerializeField] private AudioClip attackAudioClip;
    private AudioManager _audioManager;
    private static readonly int AnimatorParamJump = Animator.StringToHash("Jump");
    private static readonly int AnimatorParamAttack = Animator.StringToHash("Attack");
    private bool _isGrounded;
    private bool _isJumping;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    private void Update()
    {
        // Alternate between run & jump animations
        if (_isGrounded != IsGrounded())
        {
            animator.SetBool(AnimatorParamJump, _isGrounded);
            _isGrounded = !_isGrounded;
        }

        // Player input processing
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            // Delegate physics operation to `FixedUpdate`
            _isJumping = true;
        }
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!animatorStateInfo.IsName("Cat_White_Attack") && Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(bottomPivot.position, groundDistance, groundLayer);
    }

    private void Jump()
    {
        _audioManager.PlaySoundEffect(jumpAudioClip);
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _isJumping = false;
    }
    
    private void Attack() 
    {
        _audioManager.PlaySoundEffect(attackAudioClip);
        animator.SetTrigger(AnimatorParamAttack);
    }
}