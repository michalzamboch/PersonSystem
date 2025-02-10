using CommunityToolkit.Mvvm.ComponentModel;

namespace PersonSystem.ViewModels;

internal sealed class Person : ObservableObject
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    
    private int _age = 0;
    public int Age
    {
        get => _age;
        set => SetProperty(ref _age, value);
    }
}