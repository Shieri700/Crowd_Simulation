using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace behaviorXML
{
    public class BFSM
    {
        [XmlElement("State")]
        public StateClass[] State;

        [XmlElement("Transition")]
        public Trans transition;
    }

    public class StateClass
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int final;

        public Goal GoalSelector;
        public Vel VelComponent;
    }

    public class Goal
    {
        [XmlAttribute]
        public string type;
        [XmlAttribute]
        public int mirror_x;
        [XmlAttribute]
        public int mirror_y;
    }

    public class Vel
    {
        [XmlAttribute]
        public string type;
    }

    public class Trans
    {
        [XmlAttribute]
        public string from;
        [XmlAttribute]
        public string to;

        [XmlElement("Condition")]
        public Condition condition;
    }

    public class Condition
    {
        [XmlAttribute]
        public string type;
        [XmlAttribute]
        public float distance;
    }
}
