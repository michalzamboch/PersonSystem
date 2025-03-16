using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace PersonSystem.ViewModels;

internal class MainWindowViewModel : ViewModelBase
{
    private readonly ImmutableList<Person> _inputPeople =
    [
        new() { Name = "John", Age = 40 },
        new() { Name = "Jane", Age = 40 },
        new() { Name = "Mark", Age = 40 },
    ];
    
    public ObservableCollection<Person> OldPeople { get; }

    private ObservableCollection<Person> _localNewPeople = [];
    
    private ReadOnlyObservableCollection<Person> _newReadonlyPeople = ReadOnlyObservableCollection<Person>.Empty;
    public ReadOnlyObservableCollection<Person> NewReadonlyPeople
    {
        get => _newReadonlyPeople;
        private set => SetProperty(ref _newReadonlyPeople, value);
    }
    
    public ICommand RemovePersonCommand { get; }
    public ICommand ResetPeopleCommand { get; }
    public ICommand AddNewPersonCommand { get; }
    
    public MainWindowViewModel()
    {
        OldPeople = new ObservableCollection<Person>(_inputPeople);
        NewReadonlyPeople = new ReadOnlyObservableCollection<Person>(_localNewPeople);
        
        RemovePersonCommand = new RelayCommand<Person>(RemovePerson);
        ResetPeopleCommand = new RelayCommand(ResetPeople);
        AddNewPersonCommand = new RelayCommand(AddNewPerson);
    }

    private void RemovePerson(Person? input)
    {
        if (input is null)
        {
            throw new InvalidCastException("Input must be a Person.");
        }
        OldPeople.Remove(input);
    }

    private void ResetPeople()
    {
        _localNewPeople = new ObservableCollection<Person>(_inputPeople);
        NewReadonlyPeople = new ReadOnlyObservableCollection<Person>(_localNewPeople);
    }

    private void AddNewPerson()
    {
        _localNewPeople.Add(new Person() { Name = "Paul", Age = 40 });
    }
}