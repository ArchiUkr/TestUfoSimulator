using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UfoMovement : MonoBehaviour
{
    public float speed;
    public int health = 3;
    private Vector3 targetPosition;
    public ParticleSystem explosionParticle;
    public GameObject UfoMesh;

    private void Start()
    {
        targetPosition = RandomPositionOnPlane();
    }


    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            targetPosition = RandomPositionOnPlane();
        }

        if (health <= 0)
        {         
            UfoMesh.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<UfoMovement>().enabled = false;
            explosionParticle.Play();
            StartCoroutine(UfoExplosive());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        targetPosition = RandomPositionOnPlane();
        if (collision.gameObject.tag == "Ufo")
        {
            health--;
            gameObject.GetComponent<UfoUI>().CheckHP();
        }
    }
    IEnumerator UfoExplosive()
    {       
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private Vector3 RandomPositionOnPlane()
    {
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        return new Vector3(x, 0f, z);
    }

  
}
