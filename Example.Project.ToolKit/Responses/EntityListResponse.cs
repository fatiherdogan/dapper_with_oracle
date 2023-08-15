using System.Runtime.Serialization;

namespace Example.Project.ToolKit.Responses
{
    [Serializable]
    [DataContract]
    public class EntityListResponse<T> : BaseResponse
    {
        private List<T> _entityDataList = new List<T>();

        [DataMember]
        public List<T> EntityDataList
        {
            get { return _entityDataList; }
            set { _entityDataList = value; }
        }
    }
}
