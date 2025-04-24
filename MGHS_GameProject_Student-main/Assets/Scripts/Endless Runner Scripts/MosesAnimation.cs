using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void JumpAnimation()
    {
        _anim.SetBool("isJumping", true);
        _anim.SetBool("isGrounded", false);
    }

    public void RunningAnimation()
    {
        _anim.SetBool("isJumping", false);
        _anim.SetBool("isGrounded", true);
    }

}
