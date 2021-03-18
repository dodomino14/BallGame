using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float powerupForce = 5.0f;
    public GameObject powerupIndicator;
    private Rigidbody playerBody;
    private GameObject focalPoint;
    private Rigidbody enemyBody;
    private Vector3 awayFromPlayer;
    private bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            playerBody.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerBody.AddForce(focalPoint.transform.forward * speed * Time.deltaTime * -1);
        }
    }

    IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(8);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }

    //Colliding with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            enemyBody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }

    //Colliding with a powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            StartCoroutine(PowerupCountDown());
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
