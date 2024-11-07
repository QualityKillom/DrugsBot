using Domain.Validators;
using FluentValidation;

namespace Domain.Entities;

public class DrugNetwork
{
    public string NetworkName { get; private set; }
    
    public ICollection<DrugStore> DrugStores { get; private set; }
    
    public DrugNetwork(string networkName)
    {
        NetworkName = networkName;
        DrugStores = new List<DrugStore>(); 
    }
}