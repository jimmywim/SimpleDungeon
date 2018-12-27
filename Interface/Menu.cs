using System;
using System.Linq;
using System.Collections.Generic;

public class Menu
{
    public string Title;
    public List<MenuItem> Options;

    public Menu()
    {
        this.Options = new List<MenuItem>();
    }

    public void AddItem(string key, string name)
    {
        this.Options.Add(new MenuItem
        {
            Key = key,
            Name = name
        });
    }
    public void AddItem(string name)
    {
        this.Options.Add(new MenuItem
        {
            Key = (this.Options.Count).ToString(),
            Name = name
        });
    }

    public string Show(bool onBottom = false)
    {
        List<string> lines = new List<string>();
        lines.Add($"{this.Title}: ");

        foreach (var option in this.Options)
        {
            lines.Add($"\t{option.Key.ToUpper()} - {option.Name}");
        }

        lines.Add($"\tEsc - Exit");

        if (onBottom)
        {
            this.RenderBottom(lines);
        }
        else
        {
            this.Render(lines);
        }

        ConsoleKeyInfo input;
        var possibleKeys = this.Options.Select(o => o.Key);

        do
        {
            input = Console.ReadKey(true);

            return input.KeyChar.ToString().ToUpper();
        } while (possibleKeys.Contains(input.KeyChar.ToString().ToUpper()) && input.Key != ConsoleKey.Escape);
    }

    private void Render(List<string> lines)
    {
        lines.ForEach((line) =>
        {
            Console.WriteLine(line);
        });
    }

    private void RenderBottom(List<string> lines)
    {
        Console.CursorTop = Console.WindowHeight - lines.Count - 2;
        this.Render(lines);
    }
}