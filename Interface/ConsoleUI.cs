using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConsoleUI
{
    private int topUISize = 0;

    public void PresentRoom(Room room)
    {
        Console.Clear();
        
        List<string> lines = new List<string>();

        lines.Add(FillWindowWithCharacter('{', '-', '}'));

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

        lines.Add(FillWindowWithCharacter('{', '-', '}'));

        this.RenderLines(lines.ToArray());
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

        this.RenderLines(lines.ToArray());
    }

    public string PresentMenu(Menu menu)
    {
        this.ClearMenu();
        return menu.Show(true);
    }

    private void ClearMenu()
    {
        Console.CursorTop = this.topUISize;
        do
        {
            Console.WriteLine();
        } while (Console.CursorTop == Console.BufferHeight);
    }

    private string FillWindowWithCharacter(char start, char fill, char end)
    {
        StringBuilder sb = new StringBuilder();

        int midWidth = Console.BufferWidth - 2;
        sb.Append(start);
        int i = 0;
        do
        {
            sb.Append(fill);
            i++;
        } while (i < midWidth);

        sb.Append(end);

        return sb.ToString();
    }

    private void RenderLines(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }

        this.topUISize = lines.Length;
    }
}