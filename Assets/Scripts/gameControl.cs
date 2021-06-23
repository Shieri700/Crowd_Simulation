using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using MengeCS;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class gameControl : MonoBehaviour
{
    public enum game_mode
    {
        Edit,
        Play
    }

    game_mode gameMode;
    GameObject modeButtonText;

    public GameObject PedestrianModel;
    private MengeCS.Simulator _sim;
    private List<GameObject> _objects = new List<GameObject>();
    private bool _sim_is_valid = false;

    // Start is called before the first frame update
    void Start()
    {
        gameMode = game_mode.Edit;
        modeButtonText = GameObject.Find("ModeText");
    }

    // Update is called once per frame
    void Update()
    {
        if (_sim_is_valid && gameMode == game_mode.Play)
        {
            _sim.DoStep();
            UnityEngine.Vector3 newPos = new UnityEngine.Vector3();
            for (int i = 0; i < _sim.AgentCount; ++i)
            {
                MengeCS.Vector3 pos3d = _sim.GetAgent(i).Position;
                newPos.Set(pos3d.X, pos3d.Y, pos3d.Z);
                _objects[i].transform.position = newPos;
            }
        }
    }

    public void startSim()
    {
        Debug.Log("Starting simulation...");

        string demo = "circle";
        string mengeRoot = @"E:\LoveCS\PG\Project\librarys\Menge-0.9.2\Menge-0.9.2\";
        //string behavior = String.Format(@"{0}examples\core\{1}\{1}B.xml", mengeRoot, demo);
        string behavior = String.Format(@"{0}examples\core\{1}\tttest.xml", mengeRoot, demo);

        //string scene = String.Format(@"{0}examples\core\{1}\{1}S.xml", mengeRoot, demo);
        string scene = String.Format(@"{0}examples\core\{1}\textS.xml", mengeRoot, demo);

        Debug.Log("\tInitialzing sim");
        Debug.Log("\t\tBehavior: " + behavior);
        Debug.Log("\t\tScene: " + scene);

        _sim = new MengeCS.Simulator();
        _sim_is_valid = _sim.Initialize(behavior, scene, "orca");

        if (_sim_is_valid)
        {
            int COUNT = _sim.AgentCount;
            Debug.Log(string.Format("Simulator initialized with {0} agents", COUNT));
            for (int i = 0; i < COUNT; ++i)
            {
                MengeCS.Agent a = _sim.GetAgent(i);
                UnityEngine.Vector3 pos = new UnityEngine.Vector3(a.Position.X, a.Position.Y, a.Position.Z);
                GameObject o = Instantiate(PedestrianModel, pos, Quaternion.identity) as GameObject;
                if (o != null)
                {
                    //o.transform.GetComponentInChildren<Renderer>().material.color = classColors[a.Class % classColors.Count];
                    o.transform.GetChild(0).gameObject.transform.localScale = new UnityEngine.Vector3(a.Radius * 2, 0.85f, a.Radius * 2);
                    _objects.Add(o);
                }
            }
        }
        else
        {
            Debug.Log("Failed to initialize the simulator...");
        }
    }

    public void switchMode()
    {
        if (gameMode == game_mode.Edit)
        {
            gameMode = game_mode.Play;
            startSim();
            modeButtonText.SendMessage("currentGameMode", gameMode);
        }
        else
        {
            gameMode = game_mode.Edit;
            for(int i = 0; i < _objects.Count; i++)
            {
                Destroy(_objects[i]);
            }
            _objects.Clear();
            modeButtonText.SendMessage("currentGameMode", gameMode);
        }
    }

    public void generateXML()
    {
        crowdxml.saveXML crowdXML = new crowdxml.saveXML();
        crowdXML.startS("mengeXML/testS.xml");
        {
            //crowdXML.SerializeNode();
            //crowdXML.SerializeElement();
            crowdXML.testS();
        }
        crowdXML.closeS();

        crowdXML.startB("mengeXML/testB.xml");
        {
            //crowdXML.SerializeNode();
            //crowdXML.SerializeElement();
            crowdXML.testB();
        }
        crowdXML.closeB();
        Debug.Log("Finish update");
    }
}
