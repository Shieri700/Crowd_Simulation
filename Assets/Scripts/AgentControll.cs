using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentControll : MonoBehaviour
{
    // public variables
    public float moveSpeed = 3.0f;

    private CharacterController agentController;

    // Start is called before the first frame update
    void Start() {
        agentController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        // Determine how much should move in the z-direction
        Vector3 movementZ = Vector3.forward * moveSpeed * Time.deltaTime;

        // Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
        Vector3 movement = transform.TransformDirection(movementZ);

        //Debug.Log("Movement Vector = " + movement);

        // Actually move the character controller in the movement direction
        agentController.Move(movement);
        //Debug.Log("ttt");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("collision" + gameObject.name);
            turnRound();
        }
    }

    void turnRound(){
        this.transform.Rotate(0, Random.Range(120, 240.0f), 0);
    }
}
