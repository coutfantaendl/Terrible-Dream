using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TriggerSound : MonoBehaviour, ITriggerSound
{
    [SerializeField] private AudioClip _triggerSound;
    [SerializeField] private AudioSource _audioSource;

    private bool _hasSoundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasSoundPlayed)
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        if (_audioSource == null || _triggerSound == null)
            throw new ArgumentNullException(paramName: nameof(gameObject.name), message: "Name cannot be null");

        _audioSource.PlayOneShot(_triggerSound);
        _hasSoundPlayed = true;
        StartCoroutine(DestroyAfterSound());
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(_triggerSound.length);

        Destroy(gameObject);
    }

}
