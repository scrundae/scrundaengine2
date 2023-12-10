using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.IO;

namespace scrundaengine_2
{
    public class Actor
    {
        private PictureBox pictureBox;
        public int positionX;
        public int positionY;
        private System.Windows.Forms.Timer posReporter;

        // Create and configure the PictureBox in a separate method.
        public void InitializeActor()
        {
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(0, 0);
            pictureBox.Size = new Size(100, 100);
            pictureBox.BackColor = Color.Blue; // Example color
            posReporter = new System.Windows.Forms.Timer();
            posReporter.Enabled = true;
            posReporter.Interval = 1;
            posReporter.Tick += OnTick;
            
            posReporter.Start();
        }

        public void SetPosition(int x, int y)
        {
            if (pictureBox != null)
            {
                pictureBox.Location = new Point(x, y);
            }
        }
        public void MouseDownEvent(MouseEventHandler meh)
        {
            pictureBox.MouseDown += meh;
        }
        public void MouseUpEvent(MouseEventHandler meh)
        {
            pictureBox.MouseUp += meh;
        }
        public void MouseHoverEvent(EventHandler eh)
        {
            pictureBox.MouseHover += eh;
        }
        public void MouseUnhoverEvent(EventHandler eh)
        {
            pictureBox.MouseLeave += eh;
        }
        public void MouseMoveEvent(MouseEventHandler meh)
        {
            pictureBox.MouseMove += meh;
        }

        public void SetScale(int x, int y)
        {
            if (pictureBox != null)
            {
                pictureBox.Size = new Size(x, y);
            }
        }

        public void SetPhoto(string sprite)
        {
            pictureBox.ImageLocation = sprite;
        }
        public void SetPhotoLayout(PictureBoxSizeMode pbsm)
        {
            pictureBox.SizeMode = pbsm;
        }
        public void Colour(Color color)
        {
            if (pictureBox != null)
            {
                pictureBox.BackColor = color;
            }
        }

        public void AddToScene(Scene scene)
        {
            if (pictureBox != null)
            {
                scene.world.Controls.Add(pictureBox);
            }
        }

        public void RemoveFromScene(Scene scene)
        {
            if (pictureBox != null)
            {
                scene.world.Controls.Add(pictureBox);
            }
        }
        void OnTick(Object sender, EventArgs e)
        {
            positionX = pictureBox.Location.X;
            positionY = pictureBox.Location.Y;
        }
    }
    //continue
    public interface ActorAugmentation
    {
        
    }
    public class Scene
    {
        public Panel world;
        public void LoadScene(Form form)
        {
            world = new Panel();
            world.Dock = DockStyle.Fill;
            form.Controls.Add(world);
        }
        public void LoadSceneInBackground(Form form)
        {
            world = new Panel();
            world.Width = form.Width;
            world.Height = form.Height;
        }
        public void UnloadScene(Form form)
        {
            form.Controls.Remove(world);
        }
        public void SkyColour(Color color)
        {
            world.BackColor = color;
        }
    }
    public class Infoholic
    {
        ListBox console;
        TextBox input;
        System.Windows.Forms.Timer stfA;
        System.Windows.Forms.Timer KeyCheck;
        public void InitializeConsole(Form form, bool displayConsoleOnStartup)
        {
            console = new ListBox();
            console.Dock = DockStyle.Top;
            console.Visible = displayConsoleOnStartup;
            Report("scrundaengine v2");
            stfA = new System.Windows.Forms.Timer();
            stfA.Enabled = true;
            stfA.Interval = 1;
            stfA.Tick += Front;
            stfA.Start();

            form.Controls.Add(console);
        }
        public void Report(string text)
        {
            console.Items.Insert(0, "[" + DateTime.Now + "] " + text);
        }
        public void ShowConsole(bool yON)
        {
            console.Visible = yON;
        }
        public void Front(Object sender, EventArgs e)
        {
            console.BringToFront();
        }
    }
    public class UIButton
    {
        Label button;
        Color color1;
        Color color2;

        public void InitializeButton()
        {
            button = new Label();
            button.Text = "Sample Text";
            button.MouseEnter += OnHoverEnter;
            button.MouseEnter += OnHoverExit;
            color1 = Color.Black;
            color2 = Color.Black;
        }
        void OnHoverEnter(Object sender, EventArgs e)
        {
            button.ForeColor = color2;
        }
        void OnHoverExit(Object sender, EventArgs e)
        {
            button.ForeColor = color1;
        }
        public void Colours(Color normal, Color hovering)
        {
            color1 = normal;
            color2 = hovering;
        }
        public void ClickEvent(MouseEventHandler meh)
        {
            button.MouseClick += meh;
        }
        public void AddToScene(Scene scene)
        {
            scene.world.Controls.Add(button);
        }
    }
    public class GameMode
    {
        public string title = "Name your GameMode with the 'title' variable";
        public string description = "Describe your GameMode with the 'description' variable";
    }
    public static class Game
    {
        public static GameMode gameMode;
    }
}
