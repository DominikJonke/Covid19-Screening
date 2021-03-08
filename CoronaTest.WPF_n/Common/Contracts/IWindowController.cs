namespace CoronaTest.WPF_n.Common.Contracts
{
    public interface IWindowController
    {
        void ShowWindow(BaseViewModel viewModel, bool showAsDialog);
        void CloseWindow(BaseViewModel viewModel);
    }
}
