using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace sceneXML
{
    /////////////////////////////////////
    /// AgentProfile
    /////////////////////////////////////
    public class Common
    {
        [XmlAttribute("time_step")]
        public float timeStep;
    }

    public class Experiment
    {
        [XmlAttribute("version")]
        public int version;

        [XmlElement("SpatialQuery")]
        public SpatialQuery spatialQuery;

        [XmlElement("Common")]
        public Common common;

        [XmlElement("AgentProfile")]
        public AgentProfile[] agentProfiles;

        [XmlElement("AgentGroup")]
        public AgentGroup[] agentGroup;

        [XmlElement("ObstacleSet")]
        public ObstacleSet obstacleSet;
    }

    public class AgentProfile
    {
        [XmlAttribute("name")]
        public string name;

        [XmlElement("Common")]
        public Common common;
    }

    public class SpatialQuery
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("test_visibility")]
        public bool testVisibility;
    }

    /////////////////////////////////////
    /// AgentGroup
    /////////////////////////////////////
    public class AgentGroup
    {
        [XmlElement("ProfileSelector")]
        public ProfileSelector profileSelector;

        [XmlElement("StateSelector")]
        public StateSelector stateSelector;

        [XmlElement("Generator")]
        public Generator[] generator;
    }

    public class ProfileSelector
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("name")]
        public string name;
    }

    public class StateSelector
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("name")]
        public string name;
    }

    public class Generator
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("anchor_x")]
        public float anchor_x;

        [XmlAttribute("anchor_y")]
        public float anchor_y;

        [XmlAttribute("offset_x")]
        public float offset_x;

        [XmlAttribute("offset_y")]
        public float offset_y;

        [XmlAttribute("count_x")]
        public float count_x;

        [XmlAttribute("count_y")]
        public float count_y;

        //[XmlElement("Agent")]
        //public Agent agents;
    }

    /////////////////////////////////////
    /// ObstacleSet
    /////////////////////////////////////

    public class ObstacleSet
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("class")]
        public int _class;

        [XmlElement("Obstacle")]
        public Obstacle[] obstacles;
    }

    public class Obstacle
    {
        [XmlAttribute("closed")]
        public int closed;

        [XmlElement("Vertex")]
        public Vertex_scene[] vertices;
    }

    public class Vertex_scene
    {
        [XmlAttribute("p_x")]
        public float p_x;

        [XmlAttribute("p_y")]
        public float p_y;
    }
}
