using System.Collections.Generic;

class Keyboard
{
    public Dictionary<char, Letter> letters = new Dictionary<char, Letter>();
    public Keyboard(Dictionary<char, Letter> letters)
    {
        this.letters = letters;
    }
    public void update()
    {
    }
}