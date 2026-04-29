using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

class WordleGame
{
    public Dictionary<char, Letter> letters_kb = new Dictionary<char, Letter>();
    public List<Letter> letters_board = new List<Letter>();
    public Board board;
    public Keyboard keyboard;
    public string word = "";
    public string[] lines;

    public System.Windows.Forms.Label NotInWordList;
    public System.Windows.Forms.Label ResultBox;
    public System.Windows.Forms.Label ExitBtn;
    public System.Windows.Forms.Label StartBtn;
    public System.Windows.Forms.Label ResetBtn;
    public System.Windows.Forms.Label SettingsBtn;
    public System.Windows.Forms.Label PlayAgain;

    public bool locked = false;

    public WordleGame()
    {
        board = new Board(letters_board);
        keyboard = new Keyboard(letters_kb);

        string path = "../../assets/words.csv";
        string dbpath = "../../assets/db.csv";

        if (!File.Exists(dbpath)) lines = File.ReadAllLines(path);
        else lines = File.ReadAllLines(dbpath);
        lines = File.ReadAllLines(path);
        int maxAttempts = lines.Length;
        while (maxAttempts-- > 0)
        {
            int random = new Random().Next(0, lines.Length - 1);
            string line = lines.ElementAt(random);
            string[] split = line.Split(',');


            if (split[1] != "0") continue;
            line = word + ",1\n";
            word = split[0];
            break;
        }
        File.WriteAllLines(dbpath, lines);
    }
    public void start(string word)
    {
        if (word == null) throw new ArgumentNullException("word");
        if (word.Length != 5) throw new ArgumentException("The chosen word must be of length 5, but was of length " + word.Length);
    }
    public async void guess(string guess)
    {
        if (locked) return;
        if (guess == null) throw new ArgumentNullException("guess");
        if (guess.Length != 5) throw new ArgumentException("The guess must be of length 5, but was of length " + guess.Length);
        guess = guess.ToUpper();

        if (guess != word && !lines.Contains(guess))
        {
            NotInWordList.Visible = true;
            foreach (Letter l in letters_board) Effects.Bounce(l.element);
            await Task.Delay(1000);
            NotInWordList.Visible = false;
            guess = "";
            int i = board.letters.FindIndex(l => l.text.Length == 0) - 1;
            if (i < 0) i = 4;
            board.letters[i].text = "";
            board.letters[i - 1].text = "";
            board.letters[i - 2].text = "";
            board.letters[i - 3].text = "";
            board.letters[i - 4].text = "";
            return;
        }

        Dictionary<char, int> usedChars = new Dictionary<char, int>();
        for (int i = 0; i < word.Length; i++)
        {
            char guessCh = guess.ElementAt(i);
            char wordCh = word.ElementAt(i);

            int occurences = word.Split(guessCh).Length - 1;

            Letter lt = keyboard.letters[guessCh];
            List<Letter> lt_board = board.letters.Where(l => l.element.Text.Length > 0 && Convert.ToChar(l.element.Text) == guessCh).ToList();

            if (usedChars.ContainsKey(guessCh)) usedChars[guessCh] = usedChars[guessCh] + 1;
            else usedChars.Add(guessCh, 0);

            if (usedChars[guessCh] >= occurences)
            {
                lt.color = Colors.Grey;
                await setTile(Colors.Grey, lt_board);
                continue;
            }

            if (lt == null) throw new Exception("Invalid letter found at index " + i + "!");
            if (guessCh == wordCh)
            {
                lt.color = Colors.Green;
                await setTile(Colors.Green, lt_board);
            }
            else if (word.Contains(guessCh))
            {
                lt.color = Colors.Yellow;
                await setTile(Colors.Yellow, lt_board);
            }
            else
            {
                lt.color = Colors.Grey;
                await setTile(Colors.Grey, lt_board);
            }
        }

        if (guess == word)
        {
            ResultBox.Text = "Genius!";
            ResultBox.Visible = true;
            Effects.Rebounce(ResultBox, 5);
            PlayAgain.Visible = true;
            locked = true;
        }
        else if (board.letters.Count(l => l.color == Colors.Background) == 0)
        {
            ResultBox.Text = "You Lost!";
            ResultBox.Visible = true;
            Effects.Rebounce(ResultBox, 5);
            PlayAgain.Visible = true;
            locked = true;
        }
    }
    private async Task setTile(Color color, List<Letter> lt)
    {
        foreach (Letter l in lt)
        {
            if (l.color == Colors.Background)
            {
                l.color = color;
                await Effects.Flip(l.element);
                return;
            }
        }
        return;
    }
}