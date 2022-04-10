using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAudioFinishPlaying : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {

        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}
