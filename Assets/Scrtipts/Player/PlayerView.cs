using UnityEngine;

namespace Scripts.Player.PlayerView
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _footstepSound;

        [Header("Audio Settings")]
        [SerializeField] private float _stepInterval;

        private float _stepTimer = 0;
        private bool _isPlaying = false;

        private void Update()
        {
            _stepTimer += Time.deltaTime;
        }

        public void PlayWalkingSound()
        {
            if (_stepTimer >= _stepInterval && !_isPlaying)
            {
                _audioSource.PlayOneShot(_footstepSound);
                _stepTimer = 0;
                _isPlaying = true;
            }

            if (_stepTimer >= _stepInterval)
            {
                _stepTimer = 0f;
                _isPlaying = false;
            }

        }

        public void StopWalkingSound()
        {
            _audioSource.Stop();
            _stepTimer = 0;
            _isPlaying = false;
        }
    }
}
