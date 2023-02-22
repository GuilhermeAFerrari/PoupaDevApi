namespace PoupaDev.API.ViewModels
{
    public class ErrorResponseViewModel
    {
        public ErrorResponseViewModel()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsViewModel>();
        }

        public ErrorResponseViewModel(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsViewModel>();
            AddError(logref, message);
        }

        public string TraceId { get; private set; }
        public List<ErrorDetailsViewModel> Errors { get; private set; }

        public class ErrorDetailsViewModel
        {
            public ErrorDetailsViewModel(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }

            public string Logref { get; private set; }

            public string Message { get; private set; }
        }

        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetailsViewModel(logref, message));
        }
    }
}
