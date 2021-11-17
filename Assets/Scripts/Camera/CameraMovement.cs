using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float m_sCameraSpeed;
    [SerializeField] private float secondWait;

    IEnumerator WaitAtStart()
    {
        yield return new WaitForSeconds(secondWait);
        transform.position = new Vector3(0f, transform.position.y + m_sCameraSpeed * Time.deltaTime, -10f);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitAtStart());
       
    }

    public void IncreaseCameraSpeed()
    {
        if (m_sCameraSpeed < 18f)
        {
            m_sCameraSpeed += 1f;
        }
    }

    public float getCameraSpeed()
    {
        return m_sCameraSpeed;
    }
}
