using UnityEngine;

public static class AnimatorData
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
}