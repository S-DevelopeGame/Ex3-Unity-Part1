using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFollow : MonoBehaviour
{
    [Tooltip("player object")] [SerializeField] private GameObject player; 
    [Tooltip("X move position the scoreText")] [SerializeField] private float xPositionScore;
    [Tooltip("Y move position the scoreText")] [SerializeField] private float yPositionScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) // if the player exists put the score in his position else destroy
            transform.position = new Vector2(player.transform.position.x + xPositionScore, player.transform.position.y + yPositionScore);
        else
            Destroy(this.gameObject);
    }
}
