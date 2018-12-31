using System;
using System.Linq;
using System.Collections.Generic;

public class Menu
{
    public string Title;
    public string Help;
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

    public string ShowOnWindow(Window window)
    {
        List<string> lines = new List<string>();
        if (!string.IsNullOrEmpty(this.Title))
        {
            lines.Add($"{this.Title}: ");
        }

        if (!string.IsNullOrEmpty(this.Help))
        {
            lines.Add($"{this.Help}: ");
        }

        foreach (var option in this.Options)
        {
            lines.Add($"\t{option.Key.ToUpper()} - {option.Name}");
        }

        lines.Add($"\tEsc - Exit");

        window.Render(lines);

        ConsoleKeyInfo input;
        var possibleKeys = this.Options.Select(o => o.Key);

        string returnedOption = string.Empty;
        do
        {
            input = Console.ReadKey(true);

            returnedOption = input.KeyChar.ToString().ToUpper();
        } while (possibleKeys.Contains(input.KeyChar.ToString().ToUpper()) && input.Key != ConsoleKey.Escape);

        var selectedItem = this.Options.FirstOrDefault((o) => o.Key == returnedOption);
        if (selectedItem != null)
        {
            selectedItem.action();
        }
        
        return returnedOption;
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
        Console.CursorTop = Console.WindowHeight - lines.Count - 4;
        this.Render(lines);
    }
}