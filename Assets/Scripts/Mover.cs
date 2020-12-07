using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    Ray lastRay;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent nma = GetComponent<NavMeshAgent>();
        nma.speed *= 2.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log("Point: " + hit.point);
            NavMeshAgent nma = GetComponent<NavMeshAgent>();
            nma.SetDestination(hit.point);

        }
    }
}
