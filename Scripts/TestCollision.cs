using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) �� Ȥ�� ������� RigidBody �־�� �Ѵ�. (IsKinematic : Off)
    // 2) ������ Collider�� �־�� �Ѵ�. (isTrigger : Off)
    // 3) ������� Collider�� �־�� �Ѵ�. (isTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name} !");
    }


    // 1) �� �� Collider�� �־�� �Ѵ�.
    // 2) �� �� �ϳ��� IsTrigger : On
    // 3) �� �� �ϳ��� RigidBody�� �־�� �Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"Trigger @ {other.gameObject.name} !");
    }

    void Start()
    {
        
    }



    void Update()
    {
        
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.forward, 10);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Racast {hit.collider.gameObject.name}!");
        }
    }
}
