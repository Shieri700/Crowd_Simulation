using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using behaviorXML;
using sceneXML;

namespace crowdxml
{
    public class saveXML
    {
        private TextWriter writerB;
        private TextWriter writerS;

        public void startB(string filename)
        {
            writerB = new StreamWriter(filename);
        }

        public void startS(string filename)
        {
            writerS = new StreamWriter(filename);
        }

        public void closeB()
        {
            writerB.Close();
        }

        public void closeS()
        {
            writerS.Close();
        }

        public void testB()
        {
            BFSM bfsm = new BFSM();
            StateClass stateWalk = new StateClass();
            stateWalk.name = "Walk";
            stateWalk.final = 0;
            stateWalk.GoalSelector = new Goal();
            stateWalk.GoalSelector.type = "mirror";
            stateWalk.GoalSelector.mirror_x = 1;
            stateWalk.GoalSelector.mirror_y = 1;
            stateWalk.VelComponent = new Vel();
            stateWalk.VelComponent.type = "goal";

            StateClass stateStop = new StateClass();
            stateStop.name = "Stop";
            stateStop.final = 1;
            stateStop.GoalSelector = new Goal();
            stateStop.GoalSelector.type = "identity";
            stateStop.VelComponent = new Vel();
            stateStop.VelComponent.type = "goal";

            StateClass[] states = { stateWalk, stateStop };
            bfsm.State = states;

            bfsm.transition = new Trans();
            bfsm.transition.from = "Walk";
            bfsm.transition.to = "Stop";
            bfsm.transition.condition = new Condition();
            bfsm.transition.condition.type = "goal_reached";
            bfsm.transition.condition.distance = 0.05f;

            XmlSerializer x = new XmlSerializer(bfsm.GetType());
            x.Serialize(writerB, bfsm);
        }

        public void testS()
        {
            Experiment e = new Experiment();
            e.version = 2;

            e.spatialQuery = new SpatialQuery();
            e.spatialQuery.type = "kd-tree";
            e.spatialQuery.testVisibility = false;

            e.common = new Common();
            e.common.timeStep = 0.1f;

            AgentProfile agentProfile0 = new AgentProfile();
            agentProfile0.name = "group1";
            AgentProfile[] agentProfiles = { agentProfile0 };
            e.agentProfiles = agentProfiles;

            e.obstacleSet = new ObstacleSet();
            e.obstacleSet.type = "explicit";
            e.obstacleSet._class = 1;

            Obstacle obstacle0 = new Obstacle();
            obstacle0.closed = 1;
            Vertex_scene v0 = new Vertex_scene();
            v0.p_x = 1.333f;
            v0.p_y = 1.333f;
            Vertex_scene v1 = new Vertex_scene();
            v1.p_x = 5.333f;
            v1.p_y = 1.333f;
            Vertex_scene v2 = new Vertex_scene();
            v2.p_x = 5.333f;
            v2.p_y = 5.333f;
            Vertex_scene v3 = new Vertex_scene();
            v3.p_x = 1.333f;
            v3.p_y = 5.333f;
            Vertex_scene[] vertices = { v0, v1, v2, v3 };
            obstacle0.vertices = vertices;
            Obstacle[] obstacles = { obstacle0 };
            e.obstacleSet.obstacles = obstacles;

            XmlSerializer x = new XmlSerializer(e.GetType());
            x.Serialize(writerS, e);
        }

    }
}
