namespace VL.Spider.Manipulator.Entities
{
    public class GrabResult
    {
        public bool GrabStatus { set; get; }
        public string GrabType { set; get; }
        public string URL { set; get; }
        public string Message { set; get; }

        public GrabResult( bool grabStatus, string message = "")
        {
            GrabStatus = grabStatus;
            Message = message;
        }
        public GrabResult(string url, string grabType, bool grabStatus, string message = "")
        {
            URL = url;
            GrabType = grabType;
            GrabStatus = grabStatus;
            Message = message;
        }
    }
}
