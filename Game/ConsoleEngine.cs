using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConsoleEngine
{
    public Player Player { get; set; }
    public World GameWorld { get; set; }

    public ConsoleUI UI { get; set; }

    public void Launch()
    {
        Console.Clear();

        this.UI = new ConsoleUI();

        this.GameWorld = new World();
        this.GameWorld.Create();

        this.Player = new Player();
        this.Player.Spawn(this.GameWorld.StartScene);

        this.UI.PresentRoom(this.Player.CurrentRoom);

        MainLoop();
    }

    public void MainLoop()
    {
        string response = "";

        do
        {
            Menu gameMenu = new Menu();
            gameMenu.Title = "Press";

            Scene room = this.Player.CurrentRoom;

            if (room.Exits.Count > 0)
            {
                gameMenu.AddItem("N", "Navigate", () => 
                {
                      this.HandlePlayerAction(PlayerAction.Navigate);
                });
            }

            if (room.Items.Count > 0)
            {
                gameMenu.AddItem("C", "Collect Items", () => 
                {
                     this.HandlePlayerAction(PlayerAction.CollectItem);
                });
            }

            if (this.Player.Inventory.Count > 0)
            {
                gameMenu.AddItem("I", "Show Inventory", () => 
                {
                      this.HandlePlayerAction(PlayerAction.ShowInventory);
                });
            }

            response = this.UI.PresentMenu(gameMenu);

            System.Threading.Thread.Sleep(100);
        } while (response != Constants.KEY_ESCAPE);
    }

    private void HandlePlayerAction(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.Navigate:
                this.NavigatePlayer();
                break;
            case PlayerAction.CollectItem:
                this.PickupItem();
                break;
            case PlayerAction.DropItem:
                this.DropItem();
                break;
            case PlayerAction.ShowInventory:
                this.UI.PresentInventory(this.Player);
                break;
        }
    }

    private void NavigatePlayer()
    {
        var directions = this.Player.CurrentRoom.Exits.Select(e => e.Direction);

        Menu navMenu = new Menu();
        navMenu.Title = "Navigate";
        foreach (var dir in directions)
        {
            navMenu.Options.Add(new MenuItem
            {
                Key = ((char)dir).ToString(),
                Name = dir.ToString()
            });
        }

        var selection = this.UI.PresentMenu(navMenu);
        var selectionChar = selection[0];
        switch (selectionChar)
        {
            case (char)Direction.Forward:
                this.Player.Navigate(Direction.Forward);
                break;
            case (char)Direction.Right:
                this.Player.Navigate(Direction.Right);
                break;
            case (char)Direction.Back:
                this.Player.Navigate(Direction.Back);
                break;
            case (char)Direction.Left:
                this.Player.Navigate(Direction.Left);
                break;
        }

        this.UI.PresentRoom(this.Player.CurrentRoom);
    }

    private void DropItem()
    {
        Menu itemsMenu = new Menu();
        itemsMenu.Title = "Drop";

        var items = this.Player.Inventory;
        items.ForEach((item) =>
        {
            itemsMenu.AddItem(item.Name);
        });

        var result = this.UI.PresentMenu(itemsMenu);

        if (!string.IsNullOrWhiteSpace(result) && result != Constants.KEY_ESCAPE)
        {
            var selectedItemIndex = int.Parse(result);
            var item = items.ElementAt(selectedItemIndex);

            this.Player.DropItem(item);
        }
    }

    private void PickupItem()
    {
        Menu itemsMenu = new Menu();
        itemsMenu.Title = "Pick Up";

        var items = this.Player.CurrentRoom.Items;
        items.ForEach((item) =>
        {
            itemsMenu.AddItem(item.Name);
        });

        var result = this.UI.PresentMenu(itemsMenu);

        if (!string.IsNullOrWhiteSpace(result) && result != Constants.KEY_ESCAPE)
        {
            var selectedItemIndex = int.Parse(result);
            var item = items.ElementAt(selectedItemIndex);

            this.Player.PickupItem(item);
        }
    }
}