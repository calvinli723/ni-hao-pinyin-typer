using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private int numWords;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numWords; i++) {
            Instantiate(prefab, spawnPosition, Quaternion.AngleAxis(-90, new Vector3(1, 0, 0)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
