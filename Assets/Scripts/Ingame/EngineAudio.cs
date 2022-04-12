using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private float minVolume = 0.05f, maxVolume = 0.1f;
    [SerializeField] private float volumeIncrease = 0.01f;
    [SerializeField] private float currentVolume;
    private void Awake()
    {
        audioSource.volume = currentVolume;
    }


    public void ControlEngineVolume(float speed)
    {
        if (speed > 0)
        {
            if (currentVolume < maxVolume)
            {
                currentVolume += volumeIncrease * Time.deltaTime;
            }
        }
        else
        {
            if (currentVolume > minVolume)
            {
                currentVolume -= volumeIncrease * Time.deltaTime;
            }
        }
        currentVolume = Mathf.Clamp(currentVolume, minVolume, maxVolume);
        audioSource.volume = currentVolume;
    }
}
