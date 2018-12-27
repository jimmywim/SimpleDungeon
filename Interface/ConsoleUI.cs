using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConsoleUI
{
    private int topUISize = 0;
    public Window TopWindow;
    public Window BottomWindow;

    public ConsoleUI()
    {
        this.TopWindow = new Window
        {
            Height = Console.WindowHeight / 2
        };

        this.BottomWindow = new Window
        {
            Height = Console.WindowHeight / 4,
            OffsetTop = (int)Math.Floor(Console.WindowHeight * 0.75)
        };
    }

    public void PresentRoom(Room room)
    {
        Console.Clear();

        List<string> lines = new List<string>();

        lines.Add($"You are in {room.Name}");
        lines.Add(string.Empty);
        lines.Add(room.Description);
        lines.Add(string.Empty);

        if (room.Items.Count > 0 || room.Characters.Count > 0)
        {
            lines.Add("There is:");

            room.Items.ForEach((item) =>
            {
                lines.Add("\t" + item.Name);
            });

            lines.Add(string.Empty);

            room.Characters.ForEach((character) =>
            {
                lines.Add("\t" + character.Name);
            });
        }

        if (room.Exits.Count > 0)
        {
            lines.Add("There are doors to the: ");
            lines.Add("\t" + string.Join(',', room.Exits.Select(e => e.Direction.ToString())));
        }

        this.TopWindow.Render(lines);
    }

    public void PresentInventory(Player player)
    {
        List<string> lines = new List<string>();
        lines.Add(string.Empty);
        lines.Add("Inventory:");

        player.Inventory.ForEach((item) =>
        {
            lines.Add($"\t{item.Name}");
        });

        this.BottomWindow.Render(lines);
    }

    public string PresentMenu(Menu menu)
    {
        return menu.ShowOnWindow(this.BottomWindow);
    }
}