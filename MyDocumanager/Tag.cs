namespace MyDocumanager
{
  public class Tag
  {
    private string _name;
    private int _id;

    public string Name { get { return _name; } }
    public int ID { get { return _id; } }

    public Tag(string n, int i)
    {
      _name = n;
      _id = i;
    }
  }
}
