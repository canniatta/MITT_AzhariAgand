namespace AppManagementDataUser.BusinessLayer.BindingModelResult
{
    public class ResultBase<T>
    {
        public ResultBase()
        {
            IsOk = true;
            Message = "Success";
            ResponseCode = "000";
            ResponseTime = DateTime.Now;
        }
        public T Data { get; set; }
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }
        public DateTime ResponseTime { get; set; }
    }
}
