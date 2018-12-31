using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConsoleUI
{
    private int topUISize = 0;
    public Window TopWindow;
    public Window BottomWindow;

    public Window PopupWindow;

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

        this.PopupWindow = new Window
        {
            Height = Console.WindowHeight / 2,
            Width = (int)Math.Floor(Console.WindowWidth * 0.75),
            OffsetTop = (int)Math.Floor(Console.WindowHeight * 0.25),
            OffsetLeft = (int)Math.Floor(Console.WindowWidth * 0.125),
            BackColor = 1
        };
    }

    public void PresentRoom(Scene room)
    {
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
        this.Render();
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

        this.PopupWindow.Title = "Inventory";
        this.PopupWindow.ShowDialog(lines);
        this.Render();
    }

    public string PresentMenu(Menu menu)
    {
        //this.Render();
        var result = menu.ShowOnWindow(this.BottomWindow);
        this.Render();
        return result;
    }

    private void Render()
    {
        Console.Clear();
        this.TopWindow.Render();
        this.BottomWindow.Render();

        Console.CursorTop = this.TopWindow.Height;
        do
        {
            Console.Write(new string(' ', Console.WindowWidth));
        } while (Console.CursorTop < this.BottomWindow.OffsetTop);
    }
}