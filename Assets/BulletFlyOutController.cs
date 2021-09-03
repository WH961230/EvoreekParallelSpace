using System;
using UnityEngine;

public class BulletFlyOutController : MonoBehaviour
{
    void Start()
    {
    }

    private void OnEnable()
    {
        Invoke("Hide", 5f);
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
