//  EventDemo.cs
// Declaring and Implementing Events
using System;
using System.Drawing;
using System.Windows.Forms;

// custom delegate
public delegate void StartDelegate();

class EventDemo : Form
{
    // custom event
    public event StartDelegate StartEvent;

    public EventDemo()
    {
        Button clickMe = new Button();

        clickMe.Parent = this;
        clickMe.Text = "Click Me";
        clickMe.Location = new Point(
            (ClientSize.Width - clickMe.Width) /2,
            (ClientSize.Height - clickMe.Height)/2);

        // an EventHandler delegate is assigned
        // to the button's Click event
        clickMe.Click += new EventHandler(OnClickMeClicked);

        // our custom "StartDelegate" delegate is assigned
        // to our custom "StartEvent" event.
        StartEvent += new StartDelegate(OnStartEvent);

        // fire our custom event
        StartEvent();
    }

    // this method is called when the "clickMe" button is pressed
    public void OnClickMeClicked(object sender, EventArgs ea)
    {
        MessageBox.Show("You Clicked My Button!");
    }

    // this method is called when the "StartEvent" Event is fired
    public void OnStartEvent()
    {
        MessageBox.Show("I Just Started!");
    }

    static void Main(string[] args)
    {
        Application.Run(new EventDemo());
    }
}

