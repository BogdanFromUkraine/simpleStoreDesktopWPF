using System.Windows.Input;
using SimpleStore.Admin.UI.Commands;

namespace SimpleStore.Admin.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string _title = "SimpleStore Admin — Clean Architecture & DI";

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public ICommand ChangeTitleCommand { get; }

    public MainViewModel()
    {
        ChangeTitleCommand = new RelayCommand(_ => ChangeTitle());
    }

    private void ChangeTitle()
    {
        Title = "Заголовок успішно змінено через RelayCommand!";
    }
}