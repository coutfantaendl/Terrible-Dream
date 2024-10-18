using System;
using UnityEngine;

namespace Scripts.Triggers
{
    public class TriggerAnimation : MonoBehaviour, ITriggerAnimation
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string[] _triggerNames;

        private int[] _triggerHashes;
        private bool _hasAnimationPlayer = false;

        private void Awake()
        {
            if (_triggerNames == null || _triggerNames.Length == 0)
                throw new ArgumentNullException(paramName: nameof(gameObject.name), message: "Names cannot be null or empty");
            if (_animator == null)
                throw new ArgumentNullException(paramName: nameof(gameObject.name), message: "Animator cannot be null");

            _triggerHashes = new int[_triggerNames.Length];

            for (int i = 0; i < _triggerNames.Length; i++)
            {
                if (string.IsNullOrEmpty(_triggerNames[i]))
                    throw new ArgumentNullException(paramName: nameof(_triggerNames), message: $"Trigger name at index {i} cannot be null or empty");

                _triggerHashes[i] = Animator.StringToHash(_triggerNames[i]);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_hasAnimationPlayer)
            {
                PlayAnimation();
            }
        }

        public void PlayAnimation()
        {
            foreach (var triggerHash in _triggerNames)
            {
                _animator.SetTrigger(triggerHash);
            }

            _hasAnimationPlayer = true;
        }
    }
}
