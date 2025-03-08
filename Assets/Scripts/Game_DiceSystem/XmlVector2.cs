using System;
using System.Xml.Serialization;

namespace Game_DiceSystem
{
    public class XmlVector2
    {
        [XmlAttribute("x")]
        public int x;
        [XmlAttribute("y")]
        public int y;
    }
}