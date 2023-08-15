using System.Runtime.Serialization;

namespace Example.Project.ToolKit.Responses
{
    [Serializable]
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public ResponseCodes ResponseCode { get; set; } = ResponseCodes.Successful;

        [DataMember]
        public string ResponseMessage { get; set; } = "Success";

        [DataMember]
        public string ResponseErrorMessage { get; set; } = "";
    }
}
