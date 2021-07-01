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
        [XmlElement("GoalSet")]
        public GoalSet goalSet;

        [XmlElement("State")]
        public StateClass[] State;

        [XmlElement("Transition")]
        public Trans transition;
    }

    public class GoalSet
    {
        [XmlAttribute("id")]
        public int id;

        [XmlElement("Goal")]
        public Goal[] goals;
    }


    public class Goal
    {
        [XmlAttribute("capacity")]
        public int capacity;

        [XmlAttribute("id")]
        public int id;

        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("weight")]
        public float weight;

        [XmlAttribute("x")]
        public float x;

        [XmlAttribute("y")]
        public float y;
    }

    public class StateClass
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int final;

        [XmlElement("GoalSelector")]
        public GoalSelector GoalSelector;
        public Vel VelComponent;
    }

    public class GoalSelector
    {
        [XmlAttribute]
        public string type;
        [XmlAttribute("goal_set")]
        public int goal_set;
        [XmlAttribute("goal")]
        public int goal;
    }

    public class Vel
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("weight")]
        public float weight;

        [XmlAttribute("file_name")]
        public string filename;
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
