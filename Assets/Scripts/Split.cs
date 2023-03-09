using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public Player player;
    public GameObject slime;
    public float jumpSpeed = 150.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(slime, transform.position, Quaternion.identity);
            transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
            player.health -= 1.0f;
        }
    }
}
