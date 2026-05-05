using System.Collections.Generic;
using System.Linq;

namespace PortalAPI
{ 
    public class HuronAPIData
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string ValueIdentifier { get; set; }
        public List<HuronAPIAttributeData> Attributes { get; set; }

        public string GetStringValue(string name)
        {
            var str = "";
            var value = Attributes?.Where(m => m.Caption == name).FirstOrDefault()?.Value;
            if (value != null)
            {
                str = value;
            }
            return str;
        }

        public List<HuronAPISetElementData> GetSetAttributes(string name)
        {
            var str = "";
            var attribute = Attributes?.Where(m => m.Caption == name).FirstOrDefault();
            if (attribute != null)
            {
                var setElements = attribute.SetElements;
                if (setElements != null)
                {
                    return setElements;
                }
            }
            return new List<HuronAPISetElementData>();
        }
    }
}
