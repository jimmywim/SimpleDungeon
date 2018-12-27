using System;
using System.Collections.Generic;
using System.Text;

public class Window
{
    public int Width;
    public int Height;
    public int OffsetTop;
    public int OffsetLeft;

    public Window()
    {
        this.Width = Console.WindowWidth;
        this.Height = Console.WindowHeight;
        this.OffsetTop = 0;
        this.OffsetLeft = 0;
    }

    public void Render(List<string> lines)
    {
        string topBorder = this.FillWindowWithCharacter('+', '-', '+');
        Console.CursorTop = this.OffsetTop;

        Console.Write(topBorder);

        lines.ForEach((line) =>
        {
            Console.Write($"| {line}");
            Console.CursorLeft = Console.WindowWidth - 1;
            Console.Write("|");
        });

        Console.Write(topBorder);
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
}