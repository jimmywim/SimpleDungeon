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
                switch(direction)
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
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            if (scene != null)
            {
                this.PopulateEditor(scene);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            scene.Name = this.titleTextBox.Text;
            scene.Description = this.descriptionTextbox.Text;

            this.RefreshScenesListBox();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            this.NavigateOrCreate(scene, Direction.Forward);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            this.NavigateOrCreate(scene, Direction.Back);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            this.NavigateOrCreate(scene, Direction.Left);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            Scene scene = (Scene)this.scenesListbox.SelectedItem;
            this.NavigateOrCreate(scene, Direction.Right);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete Scene?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Scene scene = (Scene)this.scenesListbox.SelectedItem;
                this.world.AllScenes.Remove(scene);
                this.RefreshScenesListBox();
            }                
        }
    }
}
