using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Animator _animator;
    
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var moveDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"));

        if (moveDirection != Vector2.zero)
        {
            Move(moveDirection);
        }
        else
        {
            Idle();
        }
    }

    private void Move(Vector3 moveDirection)
    {
        _animator.SetFloat(MoveX, moveDirection.x);
        _animator.SetFloat(MoveY, moveDirection.y);
        _animator.SetBool(IsWalking, true);

        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    private void Idle()
    {
        _animator.SetBool(IsWalking, false);
    }
}
