using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private bool _pressedJump;
    [SerializeField] private bool _haltedJump;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;

    private UIManager_Endless _ui;
    private MosesAnimation _mosesAnim;
    private GameManager_Endless _gm;


    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _mosesAnim = GetComponent<MosesAnimation>();

        _ui = FindObjectOfType<UIManager_Endless>();
        _gm = FindObjectOfType<GameManager_Endless>();

        if (_ui == null)
        {
            Debug.LogError("UI Manager Script is Null!");
        }
        
        if (_gm == null)
        {
            Debug.LogError("Game Manager Script is Null!");
        }

    }

    void Update()
    {
        if (Time.timeScale == 0f) return;
        _isGrounded = CheckIfGrounded();

        if (!_isGrounded)
        {
            _mosesAnim.JumpAnimation();  // Play running animation
        }
        else
        {
            _mosesAnim.RunningAnimation();
        }


        HandleRunningSfx();
    }
    void FixedUpdate()
    {
        if (_pressedJump)
        {
            Jump();
            _pressedJump = false;
        }

        if (_haltedJump)
        {
            stoppedJumping();
            _haltedJump = false;
        }
    }

    private void Jump()
    {
        AudioManager.instance.PlaySfx("Moses_Jump");    
        Vector3 jumpVector = new Vector3(0, _jumpForce, 0);
        _playerRb.velocity = jumpVector;
    }

    private void stoppedJumping()
    {
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, _playerRb.velocity.y * 0.5f);

    }

    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void HandleRunningSfx()
    {
        if (Time.timeScale == 0) return;

        if (_isGrounded && !_gm.getGameWon())
        {
            if (!AudioManager.instance.loopingSfxSourceA.isPlaying)
            {
                Debug.Log("Running SFX is Playing");
                AudioManager.instance.PlayLoopingSfxA("Moses_Running");
            }
        }
        else
        {
            Debug.Log("Running SFX is Paused");
            AudioManager.instance.loopingSfxSourceA.Stop();
        }
    }

    public void OnJumpButtonPressed()
    {
        if (_isGrounded)
        {
            _pressedJump = true;
        }
    }

    public void OnJumpButtonReleased()
    {
        if(_playerRb.velocity.y > 0f)
        {
            _haltedJump = true;
        }
    }
}
