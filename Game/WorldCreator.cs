using System;
using System.Linq;
using System.Collections.Generic;

public class WorldCreator
{
    private World world { get; set; }

    private List<Item> Items { get; set; }

    public WorldCreator()
    {
        this.world = new World();
        this.world.Create();
        
        this.Items = new List<Item>();
    }

    public void ShowMainMenu()
    {
        Menu menu = new Menu();
        menu.Title = "Main Menu";

        menu.AddItem("New World");
        menu.AddItem("List Rooms");
        menu.AddItem("List Items");
        menu.AddItem("Show Map");
        menu.AddItem("Exit");

        string option = string.Empty;

        do
        {
            Console.Clear();
            option = menu.Show();
            switch (option)
            {
                case "0":
                    this.CreateWorld();
                    break;
                case "1":
                    this.ListScenes();
                    break;
                case "2":
                    // List Items
                    break;
                case "3":
                    Map map = new Map(this.world);
                    map.Show();
                    return;
            }
        } while (option != Constants.KEY_ESCAPE);
    }

    public void ListScenes()
    {
        Menu menu = new Menu();
        menu.Title = "Select a Scene to edit.";
        menu.Help = "Press ESC to go back to Main Menu:";

        this.world.AllScenes.ForEach((scene) =>
        {
            menu.AddItem(scene.Name);
        });

        Console.Clear();
        string option = menu.Show();
        if (option == Constants.KEY_ESCAPE)
        {
            return;
        }

        int selectedOption = int.Parse(option);

        Scene selectedScene = this.world.AllScenes.ElementAt(selectedOption);
        if (selectedScene != null)
        {
            this.EditScene(selectedScene);
        }
    }

    public void CreateWorld()
    {
        this.world = new World();
        this.CreateScene(null);
    }

    public Scene CreateScene(Scene startScene)
    {
        Scene scene = new Scene();

        if (startScene != null)
        {
            Door door = new Door();
            door.Direction = this.GetDirection();
            door.Initial = startScene;
            door.Target = scene;

            startScene.Exits.Add(door);
        }

        Console.WriteLine("Enter scene name: ");
        scene.Name = Console.ReadLine();

        scene.Description = this.GetString("Enter scene description");

        this.world.AllScenes.Add(scene);

        return scene;
    }

    public Scene EditScene(Scene scene)
    {
        Console.WriteLine($"Name: {scene.Name}");
        Console.WriteLine($"Description: {scene.Description}");

        Menu menu = new Menu();
        menu.Title = "Edit Scene";
        menu.Help = "Press ESC to cancel";

        menu.AddItem("Edit Name");
        menu.AddItem("Edit Description");
        menu.AddItem("Create Item");
        menu.AddItem("Add Existing Item");
        menu.AddItem("Remove Item");
        menu.AddItem("Add New Scene");

        string option = string.Empty;
        do
        {
            option = menu.Show();

            switch (option)
            {
                case "0":
                    scene.Name = this.GetString("Enter Name");
                    break;
                case "1":
                    scene.Description = this.GetString("Enter Description");
                    break;
                case "2":
                    Item newItem = this.CreateItem();
                    scene.Items.Add(newItem);
                    break;
                case "3":
                    Item existingItem = this.CloneExistingItem();
                    scene.Items.Add(existingItem);
                    break;
                case "4":
                    Item itemToRemove = this.ChooseExistingItem();
                    scene.Items.Remove(itemToRemove);
                    break;
                case "5":
                    Scene newScene = this.CreateScene(scene);
                    break;
            }
        } while (option != Constants.KEY_ESCAPE);

        return scene;
    }

    public string GetString(string prompt)
    {
        string str = string.Empty;

        Console.Write(prompt + " (press ESC when done): ");
        ConsoleKeyInfo consoleInput;
        do
        {
            consoleInput = Console.ReadKey();
            str += consoleInput.Key;

        } while (consoleInput.Key != ConsoleKey.Escape);

        return str;
    }

    public Item CreateItem()
    {
        Item item = new Item();
        Console.WriteLine("Enter item name: ");
        item.Name = Console.ReadLine();

        item.Description = this.GetString("Enter Description");

        this.Items.Add(item);
        return item;
    }

    public Item ChooseExistingItem()
    {
        Console.WriteLine("Choose an item to add: ");
        int i = 0;
        this.Items.ForEach((item) =>
        {
            Console.WriteLine($"\t{i} - {item.Name}");
            i++;
        });

        var itemNumber = Console.ReadKey(true).KeyChar;
        int selectedItem = 0;
        int.TryParse(itemNumber.ToString(), out selectedItem);

        return this.Items.ElementAt(selectedItem);
    }

    public Item CloneExistingItem()
    {
        Item item = this.ChooseExistingItem();
        Item clone = new Item
        {
            Name = item.Name,
            Description = item.Description
        };

        return clone;
    }

    public Direction GetDirection()
    {
        Menu menu = new Menu();
        menu.Title = "Choose Direction";
        menu.Help = "Press ESC to Cancel";

        var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

        directions.ForEach((direction) =>
        {
            menu.AddItem(((char)direction).ToString(), direction.ToString());
        });

        string option = string.Empty;

        do
        {
            option = menu.Show();
            switch (option)
            {
                case "F":
                    return Direction.Forward;
                case "R":
                    return Direction.Right;
                case "B":
                    return Direction.Back;
                case "L":
                    return Direction.Left;
            }
        } while (option != Constants.KEY_ESCAPE);

        return Direction.Forward;
    }
    private List<Direction> AvailableDirections(Scene scene)
    {
        List<Direction> dirs = new List<Direction>();
        var directions = scene.Exits.Select(s => s.Direction);


        return dirs;
    }
}