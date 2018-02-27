using UnityEngine;
using System.Collections;

public class Roller : MonoBehaviour
{
    private Rigidbody rigidb;
    public float speed;

    private void Start()
    {
        rigidb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 move = new Vector3(0, 0.0f, 100);
        rigidb.AddForce(move*speed);
    }
}