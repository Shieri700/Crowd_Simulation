using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MengeCS;
using System;

public class crowdSim : MonoBehaviour
{
    public GameObject PedestrianModel;
    public int numberOfAgents;

    private MengeCS.Simulator _sim;
    private List<GameObject> _objects = new List<GameObject>();
    private bool _sim_is_valid = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting simulation...");
        string mengeRoot = @"E:\LoveCS\PG\Project\librarys\Menge-0.9.2\Menge-0.9.2\";

        _sim = new MengeCS.Simulator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
