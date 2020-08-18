namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public void SignIn();
        public void SignOut();
        public void SendConfirmationLink();
    }
}
