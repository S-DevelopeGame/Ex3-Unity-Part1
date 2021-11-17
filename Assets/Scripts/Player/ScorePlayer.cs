using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    [Tooltip("NumberField component")] [SerializeField] NumberField scoreField;
    [Tooltip("how much point to add every step")] [SerializeField] int pointsToAdd;
    [Tooltip("AddPoint component")] [SerializeField] private AddPoint addPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor" ) // collision floor
        {
            scoreField.AddNumber(pointsToAdd);
            addPoint.setAddPoint(true);
        }

        if(scoreField.GetNumber() > 50) // numbers of points in every level
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }


    }
}
