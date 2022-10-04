using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustOnSpawn : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    [SerializeField] private float thrustForce;
    // Start is called before the first frame update
    private void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.AddForce( -transform.right * thrustForce, ForceMode2D.Impulse );
    }

    private void Update() {
        Vector2 direction = rigidBody2D.velocity;

        float angle = Mathf.Atan2( direction.y, direction.x ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis( angle, Vector3.forward );

    }

    private void OnCollisionEnter2D( Collision2D collision ) {
        Destroy( gameObject );
    }

    public void MultiplyThurst(float multiplier) {
        thrustForce *= multiplier;
    }
}
