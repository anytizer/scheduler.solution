namespace scheduler
{
    class SuccessResponse
    {
        public bool success { get; set; }
        public string message { get; set; }

        public SuccessResponse()
        {
            this.success = false;
            this.message = "";
        }
    }
}
