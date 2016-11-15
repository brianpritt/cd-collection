namespace cdCollection.Objects
{
  public class Cd {
    private string _artist;
    private string _album;
    private int _year;
    private static List<string> _instances = new List<string>;
    private string _fullDescription;

    public Cd(string artist, string album, int year)
    {
      _artist = artist;
      _album = album;
      _year = year;
    }
    public void SetArtist(string artist)
    {
      _artist = artist;
    }
    public string GetArtist()
    {
      return _artist;
    }
    public void SetAlbum(string album)
    {
      _album = album;
    }
    public string GetAlbum()
    {
      return _album;
    }
    public void SetYear(year)
    {
      _year = year;
    }
    public int GetYear()
    {
      return _year;
    }
    public void SetDescription()
    {
      _fullDescription = _album + ", by " + _artist + " Year: " + _year;
    }
    public string GetDescription()
    {
      return _fullDescription;
    }
    public static List<string> GetLIst()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(_fullDescription);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
