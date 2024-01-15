using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OboyGlass : MonoBehaviour
{
    [SerializeField] float minRotationSpeed = 200;
    [SerializeField] float maxRotationSpeed = 220;
    [SerializeField] Vector2 startSpeed = new Vector2(-10, 0);
    [SerializeField] Rigidbody2D myRigidbody;

    private void Start()
    {
        Move();
    }

    void Update()
    {
        Rotate();
    }

    void Move()
    {
        myRigidbody.AddForce(startSpeed);
    }

    void Rotate()
    {
        transform.Rotate(transform.forward, Random.Range(minRotationSpeed, maxRotationSpeed) * Time.deltaTime);
    }
}
