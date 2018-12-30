using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

public class World
{
    public List<Scene> AllScenes { get; set; }

    public Scene StartScene => this.AllScenes.First();

    public World()
    {
        this.AllScenes = new List<Scene>();
    }

    public void Create()
    {
        // TODO: Hydrate world from disk
        this.AllScenes = new List<Scene>();
        var room1 = new Scene
        {
            Name = "Living Room",
            Description = "Comfy seating area"
        };

        var room2 = new Scene
        {
            Name = "Hallway",
        };

        var door1 = new Door
        {
            Initial = room1,
            Target = room2,
            Direction = Direction.Left
        };

        var door2 = new Door
        {
            Initial = room2,
            Target = room1,
            Direction = Direction.Back
        };

        var item1 = new Item
        {
            Name = "Coffee Cup"
        };

        room2.Items.Add(item1);

        room1.Exits.Add(door1);

        room2.Exits.Add(door2);

        this.AllScenes.Add(room1);
        this.AllScenes.Add(room2);

        this.SaveWorld();
    }

    public void SaveWorld()
    {
        var settings = new DataContractSerializerSettings
        {
            MaxItemsInObjectGraph = 0x7FF,
            IgnoreExtensionDataObject = false,
            PreserveObjectReferences = true
        };

        var serializer = new DataContractSerializer(this.GetType(), settings);

        using (FileStream fs = File.OpenWrite("Dungeon.xml"))
        {
            serializer.WriteObject(fs, this);
        }
    }
}