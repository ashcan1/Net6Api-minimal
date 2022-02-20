using Minimal_App.Model;

namespace Minimal_App.Services;

public interface IcoffeeService
{
    public CoffeeModel Create(CoffeeModel coffee);
    public CoffeeModel? Get ( int id);
    public List <CoffeeModel>List();
    public CoffeeModel? Update (CoffeeModel coffee); 
    public bool Delete(int id);




}