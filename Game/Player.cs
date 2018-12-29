using System.Collections.Generic;
using System.Linq;

public class Player
{
    public Room CurrentRoom { get; set; }
    public List<Item> Inventory { get; set; }

    public void Spawn(Room room)
    {
        this.CurrentRoom = room;
        this.Inventory = new List<Item>();
    }

    public void Navigate(Direction direction)
    {
        var exit = this.CurrentRoom.Exits.FirstOrDefault(e => e.Direction == direction);
        if (exit != null)
        {
            this.CurrentRoom = exit.Target;
        }
    }

    public void PickupItem(Item item)
    {
        this.Inventory.Add(item);
        this.CurrentRoom.Items.Remove(item);
    }

    public void DropItem(Item item)
    {
        this.Inventory.Remove(item);
        this.CurrentRoom.Items.Add(item);
    }
}