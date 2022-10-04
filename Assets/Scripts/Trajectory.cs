using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    [SerializeField] private int numberOfPoints;
    [SerializeField] private Transform pfPoint;
    private Transform[] points;
    private float force;
    // Start is called before the first frame update
    void Start()
    {
        points = new Transform[numberOfPoints];

        for ( int i = 0; i < numberOfPoints; i++ ) {
            points[i] = Instantiate( pfPoint, transform.position, Quaternion.identity );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( force > 0f ) {
            foreach ( Transform point in points ) {
                point.gameObject.SetActive( true );
            }
            Vector2[] plots = plot((Vector2)transform.position-(Vector2)transform.right.normalized,numberOfPoints);
            for ( int i = 0; i < numberOfPoints; i++ ) {
                points[i].transform.position = plots[i];
            }
        } else {
            foreach ( Transform point in points ) {
                point.gameObject.SetActive( false );
            }
        }

        
    }


    private Vector2[] plot( Vector2 pos, int steps ) {
        Vector2[] results = new Vector2[steps];
        float timestep = Time.fixedDeltaTime*10f / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * 8f * timestep * timestep;
        
        float drag = 1f - timestep*0f*0.05f;
        Vector2 moveStep = -transform.right * force * timestep;

        for ( int i = 0; i < steps; i++ ) {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    public void SetForce( float force ) {
        this.force = force;
    }
}
