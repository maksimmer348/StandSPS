namespace StandSPS;

public abstract class AbstractTestModule
{
    public int Id { get; set; }
    
    public event Action<string> NameChanged;
    private string name;
    
    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                NameChanged?.Invoke(Name);
            }
        }
    }

    public event Action<string> IndexChange;
    private int index;
    public int Index
    {
        get => index;
        set
        {
            if (index != value)
            {
                index = value;
                IndexChange?.Invoke(Name);
            }
        }
    }

    public abstract string Description();
    
    public override string ToString()
    {
        return $"{Name}";
    }
}