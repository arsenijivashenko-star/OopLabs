internal class Plant
{
    private string name;
    private string familyName;
    private string sort;

    public Plant()
    {
        this.name = "Unknown";
        this.familyName = "Unknown";
        this.sort = "Unknown";
    }

    public Plant(string name, string familyName, string sort)
    {
        this.name = name;
        this.familyName = familyName;
        this.sort = sort;
    }

    public Plant(bool fromConsole)
    {
        if (fromConsole)
        {
            Console.Write("Введіть назву: "); 
            this.name = Console.ReadLine() ?? "Unknown";
            Console.Write("Введіть родину: "); 
            this.familyName = Console.ReadLine() ?? "Unknown";
            Console.Write("Введіть сорт: "); 
            this.sort = Console.ReadLine() ?? "Unknown";
        }
    }

    public string Name { get => name; set => name = value; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Plant: {name} | Family: {familyName} | Sort: {sort}");
    }

    public virtual void ShowBenefit() 
    { 
        Console.WriteLine("Загальна користь для екосистеми."); 
    }

    public virtual void ShowEconomicLoss() 
    { 
        Console.WriteLine("Загальні екологічні втрати."); 
    }
}

internal class Tree : Plant
{
    private int count;
    public double Price { get; set; }

    public Tree() : base() { count = 0; Price = 0; }
    public Tree(string name, string familyName, string sort, int count, double price) : base(name, familyName, sort) 
    { 
        this.count = count; 
        this.Price = price; 
    }
    public Tree(bool c) : base(c)
    {
        Console.Write("Кількість: "); 
        this.count = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Вартість: "); 
        this.Price = double.Parse(Console.ReadLine() ?? "0");
    }

    public override void ShowBenefit() => Console.WriteLine($"Користь: Дерево {Name} зменшує шкідливі викиди CO2.");
    public override void ShowEconomicLoss() => Console.WriteLine($"Збиток: Вирубка {Name} призводить до зміни клімату.");

    public static bool operator >(Tree a, Tree b) => a.Price > b.Price;
    public static bool operator <(Tree a, Tree b) => a.Price < b.Price;
    public static Tree operator +(Tree a, int val) { a.count += val; return a; }

    public static Tree operator ++(Tree a) { a.count++; return a; }
    public static double operator -(Tree a) => -a.Price;

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Кількість: {count} | Вартість: {Price}");
    }
}
internal class Algae : Plant
{
    private double iodineContent;
    private double area;

    public Algae() : base() 
    { 
        this.iodineContent = 0; 
        this.area = 0; 
    }
    public Algae(string name, string familyName, string sort, double iodineConent, double area) : base(name, familyName, sort) 
    { 
        this.iodineContent = iodineConent; 
        this.area = area; 
    }
    public Algae(bool fromConsole) : base(fromConsole)
    {
        Console.Write("Вміст йоду: "); 
        this.iodineContent = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Площа (м2): "); 
        this.area = double.Parse(Console.ReadLine() ?? "0");
    }

    public override void ShowBenefit() => Console.WriteLine($"Користь: {Name} мають харчову цінність та антиканцерогенну дію.");
    public override void ShowEconomicLoss() => Console.WriteLine($"Збиток: Знищення {Name} призводить до забруднення водойм.");

    public static Algae operator +(Algae a, double extraArea) { a.area += extraArea; return a; }
    public static bool operator ==(Algae a, Algae b) => a.iodineContent == b.iodineContent;
    public static bool operator !=(Algae a, Algae b) => !(a == b);

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Вміст йоду: {iodineContent}% | Площа покриття: {area} м2");
    }
}

internal class PlantGarden<T> where T : Plant
{
    private T[] items;
    public PlantGarden(int size) => items = new T[size];

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public void ShowAll()
    {
        foreach (var item in items)
            item?.DisplayInfo();
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Створення об'єктів ===");
        Tree oak1 = new Tree("Дуб", "Букові", "Звичайний", 10, 1500);
        Tree oak2 = new Tree("Дуб", "Букові", "Червоний", 5, 2000);
        Algae kelp = new Algae("Ламінарія", "Бурі", "L. digitata", 0.5, 100);

        oak1.ShowBenefit();
        kelp.ShowEconomicLoss();

        Console.WriteLine($"\nЧи дорожчий Дуб 1 за Дуб 2? {oak1 > oak2}");
        oak1++;

        Console.WriteLine("\n=== Робота з індексатором (Масив Водоростей) ===");
        PlantGarden<Algae> seaGarden = new PlantGarden<Algae>(2);
        seaGarden[0] = kelp;
        seaGarden[1] = new Algae("Спіруліна", "Синьо-зелені", "Arthrospira", 0.1, 50);

        seaGarden.ShowAll();
    }
}
