using System.Runtime.Serialization;

namespace Example.Project.ToolKit.Responses
{
    [Serializable]
    [DataContract]
    public class EntityResponse<T> : BaseResponse
    {
        [DataMember]
        public T EntityData { get; set; }
    }
}
