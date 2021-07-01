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

        public void testB(Vector2 exitPos)
        {
            BFSM bfsm = new BFSM();
            ///////////////////////////////////////////////////////
            //Goal set
            ///////////////////////////////////////////////////////
            GoalSet goalSet = new GoalSet();
            goalSet.id = 0;

            Goal goal0 = new Goal();
            goal0.type = "point";
            goal0.id = 0;
            goal0.x = exitPos.x;
            goal0.y = exitPos.y;

            Goal[] goals = { goal0 };
            goalSet.goals = goals;
            bfsm.goalSet = goalSet;

            ///////////////////////////////////////////////////////
            //state
            ///////////////////////////////////////////////////////
            StateClass stateWalk = new StateClass();
            stateWalk.name = "Walk";
            stateWalk.final = 0;
            stateWalk.GoalSelector = new GoalSelector();
            stateWalk.GoalSelector.type = "farthest";
            stateWalk.GoalSelector.goal_set = 0;

            stateWalk.VelComponent = new Vel();
            stateWalk.VelComponent.type = "road_map";
            stateWalk.VelComponent.weight = 1.0f;
            stateWalk.VelComponent.filename = "some file name";

            StateClass stateStop = new StateClass();
            stateStop.name = "Stop";
            stateStop.final = 1;
            //stateStop.GoalSelector = new GoalSelector();
            //stateStop.GoalSelector.type = "identity";
            //stateStop.VelComponent = new Vel();
            //stateStop.VelComponent.type = "goal";

            StateClass[] states = { stateWalk, stateStop };
            bfsm.State = states;

            bfsm.transition = new Trans();
            bfsm.transition.from = "Walk";
            bfsm.transition.to = "Stop";
            bfsm.transition.condition = new Condition();
            bfsm.transition.condition.type = "goal_reached";
            bfsm.transition.condition.distance = 1.5f;

            XmlSerializer x = new XmlSerializer(bfsm.GetType());
            x.Serialize(writerB, bfsm);
        }

        public void testS(GameObject[] walls, Vector2 startPos, int startSize)
        {
            Experiment e = new Experiment();
            e.version = 2;

            e.spatialQuery = new SpatialQuery();
            e.spatialQuery.type = "kd-tree";
            e.spatialQuery.testVisibility = false;

            e.common = new Common();
            e.common.timeStep = 0.1f;

            ///////////////////////////////////////////////////////
            //agent profile
            ///////////////////////////////////////////////////////
            AgentProfile agentProfile0 = new AgentProfile();
            agentProfile0.name = "group1";

            AgentProfile[] agentProfiles = { agentProfile0 };
            e.agentProfiles = agentProfiles;

            ///////////////////////////////////////////////////////
            //agent group
            ///////////////////////////////////////////////////////
            AgentGroup agentGroup0 = new AgentGroup();

            ProfileSelector profileSelector0 = new ProfileSelector();
            profileSelector0.type = "const";
            profileSelector0.name = "group1";
            agentGroup0.profileSelector = profileSelector0;

            StateSelector stateSelector0 = new StateSelector();
            stateSelector0.type = "const";
            stateSelector0.name = "walk";
            agentGroup0.stateSelector = stateSelector0;

            Generator generator0 = new Generator();
            generator0.type = "rect_grid";
            generator0.anchor_x = startPos.x;
            generator0.anchor_y = startPos.y;
            generator0.offset_x = -0.1f;
            generator0.offset_y = -0.1f;
            generator0.count_x = 2;
            generator0.count_y = startSize / 2;
            agentGroup0.generator = generator0;

            AgentGroup[] agentGroups = { agentGroup0 };
            e.agentGroups = agentGroups;

            e.obstacleSet = new ObstacleSet();
            e.obstacleSet.type = "explicit";
            e.obstacleSet._class = 1;

            e.obstacleSet.obstacles = getObstacles(walls);

            XmlSerializer x = new XmlSerializer(e.GetType());
            x.Serialize(writerS, e);
        }

        public Obstacle[] getObstacles(GameObject[] walls)
        {
            Obstacle[] obstacles = new Obstacle[walls.Length];
            for (int i = 0; i < walls.Length; i++)
            {
                obstacles[i] = new Obstacle();
                obstacles[i].closed = 1;

                Vector3 centre = walls[i].GetComponent<Renderer>().bounds.center;
                float width = walls[i].GetComponent<Renderer>().bounds.size.x;
                //float height = walls[i].GetComponent<Renderer>().bounds.size.y;
                float depth = walls[i].GetComponent<Renderer>().bounds.size.z;

                Vertex_scene v0 = new Vertex_scene();
                v0.p_x = centre.x - width / 2.0f;
                v0.p_y = centre.z - depth / 2.0f;
                Vertex_scene v1 = new Vertex_scene();
                v1.p_x = v0.p_x + width;
                v1.p_y = v0.p_y;
                Vertex_scene v2 = new Vertex_scene();
                v2.p_x = v0.p_x + width;
                v2.p_y = v0.p_y + depth;
                Vertex_scene v3 = new Vertex_scene();
                v3.p_x = v0.p_x;
                v3.p_y = v0.p_y + depth;
                Vertex_scene[] vertices = { v0, v1, v2, v3 };
                obstacles[i].vertices = vertices;
            }
            return obstacles;
        }

    }
}
