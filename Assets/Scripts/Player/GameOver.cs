using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Tooltip("Camera Object")] [SerializeField] private Camera camera;
    [Tooltip("the distance from the player to camera")] [SerializeField] private float offSet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y + offSet < camera.transform.position.y)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
