using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardScript : MonoBehaviour
{
    public float power;
    [SerializeField]
    Rigidbody ballRigid;
    
    void Start()
    {
        ballRigid.AddRelativeForce(Vector3.right*-1*power,ForceMode.Impulse);
    }
}
