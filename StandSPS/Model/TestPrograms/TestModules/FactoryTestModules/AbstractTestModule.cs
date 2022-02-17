namespace StandSPS;

public abstract class AbstractTestModule
{
    public int Id { get; set; }
    
    public event Action<string> NameChanged;
    private string _name;
    
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                NameChanged?.Invoke(Name);
            }
        }
    }
    public abstract string Description();
}