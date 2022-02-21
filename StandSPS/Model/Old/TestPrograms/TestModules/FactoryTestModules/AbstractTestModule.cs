namespace StandSPS;

public abstract record AbstractTestModule
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int Index { get; init; }

    public abstract string Description();
}