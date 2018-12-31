using GameEditor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEditor
{
    public partial class MainForm : Form
    {
        private World world;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    var serializer = new DataContractSerializer(typeof(World), new DataContractSerializerSettings
                    {
                        MaxItemsInObjectGraph = 0x7FF,
                        IgnoreExtensionDataObject = false,
                        PreserveObjectReferences = true
                    });

                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        object obj = serializer.ReadObject(fs);
                        this.world = (World)obj;

                        this.HydrateWorld();
                    }
                }
            }
        }

        private void HydrateWorld()
        {
            this.RefreshScenesListBox();
        }

        public void SelectSceneAndEdit(Guid sceneId)
        {
            Scene scene = this.world.AllScenes.FirstOrDefault(s => s.Id == sceneId);
            if (scene != null)
            {
                this.PopulateEditor(scene);
                this.itemsListBox.SelectedIndex = this.itemsListBox.Items.IndexOf(scene);
            }
        }

        private void PopulateEditor(Scene scene)
        {
            this.titleTextBox.Text = scene.Name;
            this.descriptionTextbox.Text = scene.Description;

            this.itemsListBox.DataSource = scene.Items;
            this.itemsListBox.DisplayMember = nameof(Item.Name);
        }

        private void RefreshScenesListBox()
        {
            this.scenesListbox.DataSource = null;
            this.scenesListbox.DataSource = this.world.AllScenes;
            this.scenesListbox.DisplayMember = nameof(Scene.Name);
            this.scenesListbox.ValueMember = nameof(Scene.Id);
        }

        private void RefreshItemsListBox()
        {
            this.itemsListBox.DataSource = null;
            this.itemsListBox.DataSource = this.GetThisScene().Items;
            this.itemsListBox.DisplayMember = nameof(Item.Name);
        }

        private Scene GetThisScene()
        {
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            return scene;
        }

        private void NavigateOrCreate(Scene scene, Direction direction)
        {
            Door target = scene.Exits.FirstOrDefault(exit => exit.Direction == direction);
            if (target != null)
            {
                this.scenesListbox.SelectedValue = target.Target.Id;
                this.PopulateEditor(target.Target);
            }
            else
            {
                Scene newScene = new Scene();
                scene.Exits.Add(new Door
                {
                    Direction = direction,
                    Initial = scene,
                    Target = newScene
                });

                Direction reverseDirection = direction;
                switch (direction)
                {
                    case Direction.Forward:
                        reverseDirection = Direction.Back;
                        break;
                    case Direction.Back:
                        reverseDirection = Direction.Forward;
                        break;
                    case Direction.Left:
                        reverseDirection = Direction.Right;
                        break;
                    case Direction.Right:
                        reverseDirection = Direction.Left;
                        break;
                }

                scene.Exits.Add(new Door
                {
                    Direction = reverseDirection,
                    Initial = newScene,
                    Target = scene
                });

                this.world.AllScenes.Add(newScene);
                this.RefreshScenesListBox();

                this.scenesListbox.SelectedIndex = this.scenesListbox.Items.IndexOf(newScene);

                this.PopulateEditor(newScene);
            }
        }

        private void scenesListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            Scene scene = this.GetThisScene();
            if (scene != null)
            {
                this.PopulateEditor(scene);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Scene scene = this.GetThisScene();
            scene.Name = this.titleTextBox.Text;
            scene.Description = this.descriptionTextbox.Text;

            this.RefreshScenesListBox();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            Scene scene = this.GetThisScene();
            this.NavigateOrCreate(scene, Direction.Forward);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Scene scene = this.GetThisScene();
            this.NavigateOrCreate(scene, Direction.Back);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            Scene scene = this.GetThisScene();
            this.NavigateOrCreate(scene, Direction.Left);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            Scene scene = this.GetThisScene();
            this.NavigateOrCreate(scene, Direction.Right);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Scene?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Scene scene = this.GetThisScene();
                this.world.AllScenes.Remove(scene);
                this.RefreshScenesListBox();
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            ItemEditor editor = new ItemEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                Scene scene = this.GetThisScene();
                scene.Items.Add(editor.Item);
                this.RefreshItemsListBox();
            }
        }

        private void editItemButton_Click(object sender, EventArgs e)
        {
            Item item = this.itemsListBox.SelectedItem as Item;
            if (item != null)
            {
                ItemEditor editor = new ItemEditor(item);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    item = editor.Item;
                    this.RefreshItemsListBox();
                }
            }
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            Item item = this.itemsListBox.SelectedItem as Item;
            if (item != null)
            {
                if(MessageBox.Show("Really Delete?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.GetThisScene().Items.Remove(item);
                    this.RefreshItemsListBox();
                }
            }
        }
    }
}
