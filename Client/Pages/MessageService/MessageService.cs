namespace MyBudget.Client.Pages.MessageService
{
    public class MessageService
    {
        public event Action? SaidSomething;

        public string Message { get; set; } = "...";

        public void SaySomething(string message)
        {
            Message = message;
            SaidSomething?.Invoke();
        }
    }
}
