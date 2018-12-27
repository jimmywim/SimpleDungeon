using System.Collections.Generic;

public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Door> Exits { get; set; }
    public List<Item> Items { get; set; }
    public List<Character> Characters { get; set; }

    public Room()
    {
        this.Exits = new List<Door>();
        this.Items = new List<Item>();
        this.Characters = new List<Character>();
    }
}