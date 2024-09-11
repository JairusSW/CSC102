class Program
{
    // I used this as my first way, but thought it would be cooler to do it key-by-key.
    // It updates in real time that way
    static string[] getWords(string txt)
    {
        return txt.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    }
    static int getRandomBgColor()
    {
        Random random = new Random();
        // ANSII codes for a bg is 41-46 inclusive. We use 107 to make that inclusive.
        // Taken from prior research and my project on gh https://github.com/JairusSW/as-rainbow/blob/master/assembly/index.ts
        // I'm sorry its cursed :P
        return random.Next(41, 47);
    }
    static void resetTerm()
    {
        // Terminate ansii
        Console.Write("\u001b[49m");
        Console.Clear();
        // Set term bg to a random color
        Console.Write("\u001b[" + getRandomBgColor().ToString() + "m");
        Console.WriteLine("This CLI counts the number of words contained in a string.        \nRainbow mode enabled. Press Ctrl+C to quit.                       ");
        Console.WriteLine("Enter a string to search: (you may have to click the screen first)");
    }
    static void updateTerm(string txt, int chars, int words, int spaces)
    {
        resetTerm();
        // I know and have used the ansii codes to edit a single line,
        // but I think its easier here to just clear the console.
        Console.WriteLine("\n\nText: " + txt);
        Console.WriteLine("Chars: " + chars.ToString());
        Console.WriteLine("Words: " + words.ToString());
        // I use the ternary expr to check for a division by zero
        Console.WriteLine("\nAvg Chars Per Word: " + (words != 0 ? ((chars - spaces) / words) : 0).ToString());
    }
    static void Main()
    {
        resetTerm();

        bool isSpace = false;
        int words = 0;
        int chars = 0;
        int spaces = 0;
        string txt = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.End) break;
            if (key.Key == ConsoleKey.Backspace)
            {
                if (txt.Length > 0) txt = txt.Substring(0, txt.Length - 1);
                if (chars > 0) chars--;
                // I don't want to implement this logic again backwards, so I'm using the previous method here
                words = getWords(txt).Length;
                updateTerm(txt, chars, words, spaces);
                continue;
            }
            if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.Tab)
            {
                // Tab (\t) counts as a space
                spaces++;
                isSpace = true;
            }
            else if (isSpace && key.Key != ConsoleKey.Backspace)
            {
                words++;
                isSpace = false;
            }
            if (chars == 0) words++;
            chars++;
            txt += key.KeyChar;

            updateTerm(txt, chars, words, spaces);
        }
    }
}
