using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SaveSystem saveSystem;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
        if (saveSystem.LoadedData != null)
        {
            var damagable = player.GetComponentInChildren<Damagable>();
            damagable.Health = saveSystem.LoadedData.playerHealth;
        }
    }
}
