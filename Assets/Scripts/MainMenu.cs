using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPosition;
    public void Start() {
        //Instantiate(prefab, spawnPosition, Quaternion.AngleAxis(-90, new Vector3(1, 0, 0)));
    }
    public void Play() {
        SceneManager.LoadScene("nihao");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Player has Quit the game");
    }
}
