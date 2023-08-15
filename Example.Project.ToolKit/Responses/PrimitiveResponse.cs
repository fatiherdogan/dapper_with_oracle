using System.Runtime.Serialization;

namespace Example.Project.ToolKit.Responses
{
    [Serializable]
    [DataContract]
    public class PrimitiveResponse : BaseResponse
    {
        [DataMember]
        public string PrimitiveResponseValue { get; set; }

        [DataMember]
        public string EntityPrimaryKey { get; set; }
    }
}
