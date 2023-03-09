using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AxisMovement();
    }

    private void AxisMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, vertical, 0.0f) * moveSpeed * Time.deltaTime;
    }
}
