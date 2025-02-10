using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace PersonSystem.ViewModels;

internal class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Person> People { get; } = [
        new() {Name = "John", Age = 40},
        new() {Name = "Jane", Age = 40},
        new() {Name = "Mark", Age = 40},
    ];

    public ObservableCollection<Person> NewPeople { get; } = [];
    
    public IRelayCommand<Person> RemovePersonCommand { get; }
    
    public MainWindowViewModel()
    {
        RemovePersonCommand = new RelayCommand<Person>(RemovePerson);
    }

    private void RemovePerson(Person? input)
    {
        if (input is null)
        {
            throw new InvalidCastException("Input must be a Person.");
        }
        People.Remove(input);
    }
}