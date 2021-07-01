using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentStart : MonoBehaviour
{
    public Slider posXInput;
    public Slider posYInput;
    public Slider posXInputEnd;
    public Slider posYInputEnd;
    public Slider sizeInput;

    public GameObject agentStartPlane;
    public GameObject agentEndPlane;

    void Start()
    {
        posXInput.value = agentStartPlane.transform.position.x;
        posYInput.value = agentStartPlane.transform.position.z;
        posXInputEnd.value = agentEndPlane.transform.position.x;
        posYInputEnd.value = agentEndPlane.transform.position.z;
    }

    public Vector2 getPos()
    {
        return new Vector2(posXInput.value, posYInput.value);
    }

    public Vector2 getPosEnd()
    {
        return new Vector2(posXInputEnd.value, posYInputEnd.value);
    }

    public int getSize()
    {
        return (int)sizeInput.value;
    }
}
