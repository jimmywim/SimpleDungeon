using System;
using System.Collections.Generic;

public class Map
{
    private class SceneCoordinates
    {
        public Scene Scene;
        public int X;
        public int Y;
    }

    private World world;
    private List<SceneCoordinates> coords = new List<SceneCoordinates>();
    private List<Door> renderedExits = new List<Door>();

    public Map(World world)
    {
        this.world = world;
    }

    public void Show()
    {
        this.RenderMap();

        ConsoleKeyInfo consoleKeyInfo;
        do
        {
            consoleKeyInfo = Console.ReadKey(true);
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    Console.CursorLeft--;
                    this.CheckCusorAndUpdateStatus();
                    break;
                case ConsoleKey.RightArrow:
                    Console.CursorLeft++;
                    this.CheckCusorAndUpdateStatus();
                    break;
                case ConsoleKey.DownArrow:
                    Console.CursorTop++;
                    this.CheckCusorAndUpdateStatus();
                    break;
                case ConsoleKey.UpArrow:
                    Console.CursorTop--;
                    this.CheckCusorAndUpdateStatus();
                    break;
            }
        } while (consoleKeyInfo.Key != ConsoleKey.Escape);
    }

    private void RenderMap()
    {
        Console.Clear();
        Console.WriteLine("Pres ESC to return");

        this.DrawScenes();
    }

    private void DrawScenes()
    {
        // start from the first scene
        this.DrawScene(this.world.StartScene, Console.WindowHeight / 2, Console.WindowWidth / 2);
    }

    private void DrawScene(Scene scene, int startTop, int startLeft)
    {
        var sceneLines = this.RenderScene(scene);

        Console.CursorTop = startTop;
        Console.CursorLeft = startLeft;

        sceneLines.ForEach((line) =>
        {
            Console.WriteLine(line);
            this.coords.Add(new SceneCoordinates
            {
                Scene = scene,
                X = startLeft,
                Y = startTop
            });
        });

        int sceneBoxSize = 2;
        scene.Exits.ForEach((exit) =>
        {
            if (this.renderedExits.Contains(exit))
            {
                return;
            }

            this.renderedExits.Add(exit);

            switch (exit.Direction)
            {
                case Direction.Back:
                    this.DrawScene(exit.Target, startTop + sceneBoxSize, startLeft);
                    break;
                case Direction.Forward:
                    this.DrawScene(exit.Target, startTop - sceneBoxSize, startLeft);
                    break;
                case Direction.Left:
                    this.DrawScene(exit.Target, startTop, startLeft - sceneBoxSize);
                    break;
                case Direction.Right:
                    this.DrawScene(exit.Target, startTop, startLeft + sceneBoxSize);
                    break;
            }
        });
    }

    private List<string> RenderScene(Scene scene)
    {
        List<string> sceneLines = new List<string>();
        sceneLines.Add("+");
        return sceneLines;
    }

    private void CheckCusorAndUpdateStatus()
    {
        SceneCoordinates foundCoords = null;

        this.coords.ForEach((coord) =>
        {
            if (Console.CursorLeft == coord.X && Console.CursorTop == coord.Y)
            {
                foundCoords = coord;
            }
        });

        int left = Console.CursorLeft;
        int top = Console.CursorTop;

        Console.CursorLeft = 0;
        Console.CursorTop = Console.WindowHeight - 1;

        if (foundCoords != null)
        {
            Console.Write($"Scene: {foundCoords.Scene.Name}");
        }
        else
        {
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.CursorLeft = left;
        Console.CursorTop = top;
    }
}