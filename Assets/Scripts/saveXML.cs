using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using behaviorXML;

namespace crowdxml
{
    public class saveXML
    {
        private TextWriter writer;

        public void start(string filename)
        {
            writer = new StreamWriter(filename);
        }

        public void close()
        {
            writer.Close();
        }

        public void SerializeNode()
        {
            XmlSerializer ser = new XmlSerializer(typeof(XmlNode));
            XmlNode myNode = new XmlDocument().
            CreateNode(XmlNodeType.Element, "MyNode", "ns");
            myNode.InnerText = "Hello Node";
            ser.Serialize(writer, myNode);
        }

        public void SerializeElement()
        {
            XmlSerializer ser = new XmlSerializer(typeof(XmlElement));
            XmlElement myElement = new XmlDocument().CreateElement("MyElement", "ns");
            myElement.InnerText = "Hello World";
            ser.Serialize(writer, myElement);
        }

        public void test()
        {
            BFSM p = new BFSM();
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
            p.State = states;

            p.transition = new Trans();
            p.transition.from = "Walk";
            p.transition.to = "Stop";
            p.transition.condition = new Condition();
            p.transition.condition.type = "goal_reached";
            p.transition.condition.distance = 0.05f;

            XmlSerializer x = new XmlSerializer(p.GetType());
            x.Serialize(writer, p);
        }

    }
}
