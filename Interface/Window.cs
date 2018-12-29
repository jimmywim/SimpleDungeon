using System;
using System.Collections.Generic;
using System.Text;

public class Window
{
    public int Width;
    public int Height;
    public int OffsetTop;
    public int OffsetLeft;
    public string Title;

    private List<string> lines;

    public bool IsDialog
    {
        get
        {
            return this.Width < Console.WindowWidth;
        }
    }

    public Window()
    {
        this.Width = Console.WindowWidth;
        this.Height = Console.WindowHeight;
        this.OffsetTop = 0;
        this.OffsetLeft = 0;

        this.lines = new List<string>();
        this.Title = "";
    }

    public void Render()
    {
        this.Render(this.lines);
    }

    public bool ShowDialog(List<string> lines)
    {
        this.lines = lines;
        return this.ShowDialog();
    }

    public bool ShowDialog()
    {
        this.Render();
        bool result = this.GetDialogResult();

        return result;
    }

    public void Render(List<string> lines)
    {
        this.lines = lines;

        string topBorder = this.FillWindowWithCharacter('+', '-', '+', true);
        Console.CursorTop = this.OffsetTop;
        Console.CursorLeft = this.OffsetLeft;

        Console.Write(topBorder);

        if (this.IsDialog)
        {
            //Console.CursorTop++;
        }

        lines.ForEach((line) =>
        {
            if (!string.IsNullOrEmpty(line))
            {
                line = line.Replace("\t", "   ");
                Console.CursorLeft = this.OffsetLeft;
                Console.Write($"| {line}".PadRight(this.Width - 1));
                Console.Write("|");

                if (this.IsDialog)
                {
                    Console.CursorTop++;
                }
            }
        });

        if (this.IsDialog)
        {
            Console.CursorLeft = this.OffsetLeft;
        }

        string bottomBorder = this.FillWindowWithCharacter('+', '-', '+');
        Console.Write(bottomBorder);
    }

    private string FillWindowWithCharacter(char start, char fill, char end, bool showTitle = false)
    {
        StringBuilder sb = new StringBuilder();

        int midWidth = this.Width;
        int titleStart = 0;
        if (showTitle && !string.IsNullOrEmpty(this.Title))
        {
            midWidth -= this.Title.Length;
            titleStart = midWidth / 2;
            titleStart -= this.Title.Length / 2;
        }

        sb.Append(start);
        int i = 0;
        do
        {
            sb.Append(fill);
            i++;

            if (showTitle && !string.IsNullOrEmpty(this.Title) && i == titleStart)
            {
                sb.Append(this.Title);
                i += this.Title.Length;
            }
        } while (i < this.Width - 2);

        sb.Append(end.ToString());

        if (this.IsDialog)
        {
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private bool GetDialogResult()
    {
        ConsoleKey consoleKey;
        do
        {
            consoleKey = Console.ReadKey(true).Key;

            if (consoleKey == ConsoleKey.Enter)
            {
                return true;
            }
        } while (consoleKey != ConsoleKey.Escape);

        return false;
    }
}