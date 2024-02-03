using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esxplosion : MonoBehaviour
{
    Collider explosionCollaider;
    List <Rigidbody> explosionObjects;
    [SerializeField]
    float explosionForce;
    AudioSource explosionSound;

    private void Awake()
    {
        explosionObjects=new List<Rigidbody> ();
        explosionCollaider = GetComponent<Collider>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        explosionObjects.Add(other.attachedRigidbody); 
    }

    private void OnTriggerExit(Collider other)
    {
        explosionObjects.Remove(other.attachedRigidbody);
    }
    

    void Explode()
    {
        explosionSound.Play();
        foreach (var item in explosionObjects)
        {
            var normal = Vector3.Normalize(item.transform.position - transform.position);            
            item.AddForce(normal * explosionForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if (Input.GetKey("e"))
        {
            Explode();
        }
    }
}
