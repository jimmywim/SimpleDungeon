using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEditor.Forms
{
    public partial class ItemEditor : Form
    {
        public Item Item { get; set; }

        public ItemEditor()
        {
            InitializeComponent();
            this.Item = new Item();
            this.Name = "Create Item";
        }

        public ItemEditor(Item item)
        {
            InitializeComponent();
            this.nameTextBox.Name = item.Name;
            this.descriptionTextBox.Text = item.Description;

            this.Item = item;
            this.Name = "Edit Item";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Item.Name = this.nameTextBox.Text;
            this.Item.Description = this.descriptionTextBox.Text;
        }
    }
}
