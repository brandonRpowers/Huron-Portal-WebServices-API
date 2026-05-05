using System.Collections.Generic;

namespace PortalAPI
{
    public class HuronAPIAttributeData
    {
        public string Caption { get; set; }
        public string ReferenceType { get; set; }
        public string Value { get; set; }
        public string DataType { get; set; }
        public string ValueIdentifier { get; set; }
        public string TargetUrl { get; set; }
        public List<HuronAPISetElementData> SetElements { get; set; }
    }
}
