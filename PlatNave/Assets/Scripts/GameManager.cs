using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private List<EnemySO> enemies;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadScene("Splash");
    }
    
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SpawnEnemy(type:0);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SpawnEnemy(type:1);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SpawnEnemy(type:2);
        }
    }

    public void SpawnEnemy(int type)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<EnemyController>().InitializeEnemy(enemies[type].maxEnergy, enemies[type].enemySprite);
    }
}
