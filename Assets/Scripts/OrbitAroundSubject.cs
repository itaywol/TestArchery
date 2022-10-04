using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundSubject : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Transform subject;
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp( transform.position, orbitAroundTargetFacingSubject(), speed * Time.deltaTime );
    }

    private Vector3 orbitAroundTargetFacingSubject() {
        Vector3 direction = -( subject.position-target.position );
        return subject.position + direction.normalized * distance;
    }
}
