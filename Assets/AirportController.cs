using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportController : MonoBehaviour {
    [SerializeField] private float speed;
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(0,1 * speed * Time.deltaTime,0);
    }
}
