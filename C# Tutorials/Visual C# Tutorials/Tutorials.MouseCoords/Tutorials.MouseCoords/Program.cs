using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class MainForm : Form
{
    // Declare Variables
    int mouseX, mouseY;

    static void Main(string[] args)
    {
        Application.Run(new MainForm());
    }
    /// <summary>The Constructor of our project. 
    /// Set up Window properties and create input Events
    /// </summary>
    MainForm()
    {
        // Set the Form window's appearance and behavior
        SuspendLayout(); 
        Size = new Size( 400, 300 );
        AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
        Text = "Mouse & Screen Coords";
        CenterToScreen();
        ResumeLayout(false);

        SetStyle(ControlStyles.DoubleBuffer, true); // Turn on Double Buffering to stop flickering
        SetStyle(ControlStyles.AllPaintingInWmPaint, true); // Redraw everything in window
        SetStyle(ControlStyles.ResizeRedraw, true); // Redraw while resizing window

        // Create an event handler which is triggered every time the mouse is moved
        MouseMove += new MouseEventHandler(OnMouseMove);

        // Create event handler which is triggered when Windows says 
        // OnPaint: it's time to draw inside the Form window
        Paint += new PaintEventHandler(OnPaint); 
    }

    /// <summary>The main "Loop" triggered whenever the window needs to be redrawn </summary>
    /// <param name="sender"></param> <param name="e"></param>
    void OnPaint(Object sender, PaintEventArgs e)
    {
        Pen pen = new Pen(Color.LightBlue);

        e.Graphics.DrawLine(pen, mouseX, 0, mouseX, ClientSize.Height);
        e.Graphics.DrawLine(pen, 0, mouseY, ClientSize.Width, mouseY);

        SolidBrush blackBrush = new SolidBrush(Color.Black);

        Font font = new Font( "Arial", 16 );
        e.Graphics.DrawString( "Mouse Coords: " + mouseX + ", " + mouseY, font, blackBrush, 20, 20);
        e.Graphics.DrawString( "ClientSize: " + this.Width + ", " + this.Height, font, blackBrush, 20, 60);
    }
    /// <summary> Update Mouse Coordinates </summary>
    /// <param name="sender"></param> <param name="e"></param>
    void OnMouseMove(object sender, MouseEventArgs e)
    {
        mouseX = e.X;
        mouseY = e.Y;
        Invalidate(); // Triggers OnPaint all over again and makes our Loop
    }

    /// <summary>Keypress event </summary>
    /// <param name="e"></param>
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        switch (e.KeyCode)
        {
            case Keys.Escape: // If Escape key is pressed
                Close(); // Close the window
                break;
        }
    }
}
