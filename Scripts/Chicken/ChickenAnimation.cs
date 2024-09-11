using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(bool isRunning)
    {
        _animator.SetBool(AnimatorData.IsRunning, isRunning);
    }
}