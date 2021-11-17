using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [Tooltip("Choose time that Cars will destroy")]
    [SerializeField] public int timeDestroyObject;
    void Start()
    {
        this.StartCoroutine(destroyCar());
    }
    private IEnumerator destroyCar()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(timeDestroyObject);
            Destroy(this.gameObject);
        }
    }
}
