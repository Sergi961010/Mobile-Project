using System;
using UnityEngine;

namespace TheCreators.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        public static event Action OnAnimationFinish;
        public void AnimationFinished()
        {
            OnAnimationFinish?.Invoke();
        }
    }
}
