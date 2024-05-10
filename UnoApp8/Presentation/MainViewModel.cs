namespace UnoApp8.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;

    public MainViewModel(
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);
        MessageDlg = new AsyncRelayCommand(ShowMessageDialog);
    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }

    public ICommand MessageDlg { get; }

    private async Task GoToSecondView()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }

    public async Task ShowMessageDialog()
    {
        await _navigator.ShowMessageDialogAsync<string>(this, title: "The title", content: "Here be the message");
    }
}
