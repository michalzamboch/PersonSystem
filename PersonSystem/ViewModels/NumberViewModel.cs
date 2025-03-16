using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using PersonSystem.Models;

namespace PersonSystem.ViewModels;

public sealed class NumberViewModel : ObservableValidator
{
    private readonly Number number =  new Number();
    
    private string _value = string.Empty;
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Value
    {
        get => _value;
        set
        {
            var result = SetProperty(ref _value, value, true);   
        }
    }

    public NumberViewModel()
    {
        
    }
}