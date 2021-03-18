using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7.0f;
    private Rigidbody enemyBody;
    private GameObject player;
    private Vector3 movDir;
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movDir = (player.transform.position - transform.position).normalized;
        enemyBody.AddForce( movDir * speed * Time.deltaTime);
        checkInBounds();

    }

    void checkInBounds()
    {
        if(transform.position.y < -40)
        {
            Destroy(gameObject);
        }
    }
}
