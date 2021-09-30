using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Vector3 target;
    private bool startTiro;
    public float speed;
    public GameObject particleTiro;
    public GameObject particleTiro2;

    private void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(startTiro)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
            //if(transform.position == target)
            //{
            //    Destroy(gameObject);
            //}
        }
    }

    public void SetTarget(Vector3 p_target)
    {
        target = p_target;
        startTiro = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject _tiroParticle = Instantiate(particleTiro, target, new Quaternion(0, 0, 0, 0));
            Destroy(_tiroParticle, 2.0f);

            other.GetComponent<Zombie>().Death();
        }
        else
        {
            GameObject _tiroParticle = Instantiate(particleTiro2, target, new Quaternion(0, 0, 0, 0));
            Destroy(_tiroParticle, 2.0f);
        }

        Destroy(gameObject);
    }
}
