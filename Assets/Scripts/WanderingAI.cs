using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WanderingAI : MonoBehaviour
{

    public GameObject p;
    public int MoveSpeed = 4;


    void Update()
    {
        transform.LookAt(p.transform);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}
