using System.Drawing;
using System.Windows.Forms;

class Letter
{
    private string _text = "";
    public string text
    {
        get => _text;
        set
        {
            _text = value;
            if (element != null)
            {
                element.Text = _text;
                Effects.Bounce(element);
            }
        }
    }
    private Color _color = Colors.Keys;
    public Color color
    {
        get => _color;
        set
        {
            _color = value;
            if (element != null) element.BackColor = _color;
        }
    }
    public Label element;
    public Letter(string text, Label element)
    {
        this.text = text;
        this.element = element;
        element.BackColor = color;
    }
    public Letter(string text, Label element, Color color)
    {
        this.text = text;
        this.color = color;
        this.element = element;
        element.BackColor = color;
    }
}