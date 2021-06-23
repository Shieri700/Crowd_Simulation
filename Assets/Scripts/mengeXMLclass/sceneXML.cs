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
        [XmlElement("time_step")]
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
        public AgentProfile[] agents;
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

        [XmlElement("test_visibility")]
        public bool testVisibility;
    }
}
