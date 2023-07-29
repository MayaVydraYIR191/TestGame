using System.Collections.Generic;
using GameKit.Managers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SceneAsset sceneAsset;
    [SerializeField] private List<SharedManager> sharedManagers;
    void Awake()
    {
        foreach (var sharedManager in sharedManagers)
        {
            sharedManager.InitManager();
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SceneManager.LoadScene(sceneAsset.name);
    }

}

