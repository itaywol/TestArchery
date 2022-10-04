using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{

    private PlayerInputController playerInputController;
    private InputAction fire;
    private float strength;
    [SerializeField] private Transform projectilePrefab;
    private Trajectory trajectory;

    private bool charging = false;

    private void Awake() {
        playerInputController = new PlayerInputController();
    }
    private void OnEnable() {
        fire = playerInputController.Player.Fire;
        fire.Enable();

        fire.started += StartedFire;
        fire.performed += PerformFire;
    }

    private void OnDisable() {
        fire.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        trajectory = GetComponent<Trajectory>();
        charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(charging) {
            strength += Time.deltaTime;
        }else {
            if(strength>1f) {
                Transform arrow = Instantiate( projectilePrefab, transform.position - transform.right*0.82f, transform.rotation );
                arrow.GetComponent<ThrustOnSpawn>().MultiplyThurst( strength );
               
            }
            strength = 0f;
        }
        strength = Mathf.Clamp( strength, 0f, 3f );
        trajectory.SetForce( strength * 20f );
    }

    private void StartedFire( InputAction.CallbackContext context ) {
        charging = true;
    }

    private void PerformFire(InputAction.CallbackContext context) {
        charging = false;
    }
}
