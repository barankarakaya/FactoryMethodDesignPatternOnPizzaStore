
PizzaStore ankaraPizzaStore = new AnkaraPizzaStore();
PizzaStore İstanbulPizzaStore = new AnkaraPizzaStore();

IPizza cheesePizza = ankaraPizzaStore.OrderPizza("cheese");
Console.WriteLine("Cheese pizza ordered in Ankara Store");


IPizza veggiPizza = İstanbulPizzaStore.OrderPizza("veggi");
Console.WriteLine("Veggi pizza ordered in İstanbul Store");


interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
}



class CheesePizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("Cheese Pizza Bake");
    }

    public void Cut()
    {
        Console.WriteLine("Cheese Pizza Cut");
    }

    public void Prepare()
    {
        Console.WriteLine("Cheese Pizza Prepared");
    }
}

class VeggiPizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("Veggi Pizza Bake");
    }

    public void Cut()
    {
        Console.WriteLine("Veggi Pizza Cut");
    }

    public void Prepare()
    {
        Console.WriteLine("Veggi Pizza Prepared");
    }
}

abstract class PizzaStore
{
    protected abstract IPizza CreatePizza(string type);
    public IPizza OrderPizza(string type)
    {
        IPizza pizza = CreatePizza(type);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        return pizza;
    }
}

class AnkaraPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _=> throw new ArgumentException("invalid pizza type",nameof(type))
        };
    } 
}
class İstanbulPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("invalid pizza type", nameof(type))
        };
    }
}