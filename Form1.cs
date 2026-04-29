using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Wordle
{
    public partial class Wordle : Form
    {

        private List<Label> keyboard = new List<Label>();
        private List<Label> board = new List<Label>();
        private WordleGame game = new WordleGame();
        private string guess = "";

        public Wordle()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo_ico_img;

            keyboard = new List<Label>() { LetterQ, LetterW, LetterE, LetterR, LetterT, LetterY, LetterU, LetterI, LetterO, LetterP, LetterA, LetterS, LetterD, LetterF, LetterG, LetterH, LetterJ, LetterK, LetterL, LetterZ, LetterX, LetterC, LetterV, LetterB, LetterN, LetterM };
            board = new List<Label>() { Letter00, Letter01, Letter02, Letter03, Letter04, Letter10, Letter11, Letter12, Letter13, Letter14, Letter20, Letter21, Letter22, Letter23, Letter24, Letter30, Letter31, Letter32, Letter33, Letter34, Letter40, Letter41, Letter42, Letter43, Letter44, Letter50, Letter51, Letter52, Letter53, Letter54 };

            new ToolTip().SetToolTip(ExitBtn, "Exit game");
            new ToolTip().SetToolTip(PlayAgain, "Play again");
            new ToolTip().SetToolTip(ResetBtn, "Reset game");
            new ToolTip().SetToolTip(AddWordBtn, "Set word");
            new ToolTip().SetToolTip(SettingsBtn, "Settings");
            new ToolTip().SetToolTip(SaveWordBtn, "Save new word");

            init();

            foreach (Label l in keyboard) l.Click += (a, _) => onClickLetter(l);

            LetterEnter.Click += onClickEnter;
            LetterBack.Click += onClickBack;

            KeyDown += onKeyDown;

            ExitBtn.Click += (a, _) => Close();
            PlayAgain.Click += (a, _) => init();
            ResetBtn.Click += (a, _) => init();
            AddWordBtn.Click += onAddWordClick;
            SaveWordBtn.Click += onSaveWordClick;
            SettingsBtn.Click += (a, _) =>
            {
                ExitBtn.Visible = !ExitBtn.Visible;
                ResetBtn.Visible = !ResetBtn.Visible;
                AddWordBtn.Visible = !AddWordBtn.Visible;
                SaveWordBtn.Visible = !SaveWordBtn.Visible;
                SaveWordTxt.Visible = false;
                if (WordInput.Visible) WordInput.Visible = false;
                this.Focus();
            };
        }
        private void init()
        {
            game.letters_board = new List<Letter>();
            game.letters_kb = new Dictionary<char, Letter>();

            game = new WordleGame();
            game.NotInWordList = NotInWordList;
            game.ResultBox = ResultBox;
            game.StartBtn = PlayAgain;
            game.ResetBtn = ResetBtn;
            game.ExitBtn = ExitBtn;
            game.PlayAgain = PlayAgain;
            game.SettingsBtn = SettingsBtn;
            foreach (Label l in board)
            {
                l.Text = "";
                game.letters_board.Add(new Letter("", l, Colors.Background));
            }
            foreach (Label l in keyboard) game.letters_kb.Add(Convert.ToChar(l.Text), new Letter(l.Text, l, Colors.Keys));
            ExitBtn.Visible = false;
            PlayAgain.Visible = false;
            ResetBtn.Visible = false;
            NotInWordList.Visible = false;
            ResultBox.Visible = false;
            PlayAgain.Visible = false;
            WordInput.Visible = false;
            SaveWordBtn.Visible = false;
            SaveWordTxt.Visible = false;
            AddWordBtn.Visible = false;
        }
        private void onAddWordClick(object s, EventArgs e)
        {

            WordInput.Visible = true;
            WordInput.Focus();
            WordInput.SelectAll();
            WordInput.KeyDown += (_, c) =>
            {
                if (c.KeyCode != Keys.Enter) return;
                string newWord = WordInput.Text.Trim().ToUpper();
                if (newWord.Length != 5) WordInput.Text = "";
                else
                {
                    init();
                    game.word = newWord;
                    WordInput.Visible = false;
                    ExitBtn.Visible = false;
                    ResetBtn.Visible = false;
                    AddWordBtn.Visible = false;
                    SaveWordBtn.Visible = false;
                    this.Focus();
                }
            };
        }
        private void onSaveWordClick(object s, EventArgs e)
        {
            SaveWordTxt.Visible = true;
            SaveWordTxt.Focus();
            SaveWordTxt.SelectAll();
            SaveWordTxt.KeyDown += (_, c) =>
            {
                if (c.KeyCode == Keys.Enter)
                {
                    string newWord = SaveWordTxt.Text.Trim().ToUpper();
                    if (newWord.Length != 5) SaveWordTxt.Text = "";
                    else
                    {
                        string dbpath = "../../assets/db.csv";
                        File.WriteAllLines(dbpath, game.lines.Append(newWord + ",0"));
                        ExitBtn.Visible = false;
                        ResetBtn.Visible = false;
                        AddWordBtn.Visible = false;
                        SaveWordBtn.Visible = false;
                        SaveWordTxt.Visible = false;
                        this.Focus();
                    }
                }
            };
        }
        private void onClickLetter(Label l)
        {
            if (game.locked) return;
            Letter le = game.board.letters.ElementAt(game.board.letters.FindLastIndex(v => v.element.Text.Length > 0) + 1);
            if (guess.Length >= 5) return;
            guess += l.Text;
            le.text = l.Text;
        }
        private void onClickEnter(object s, EventArgs e)
        {
            if (game.locked) return;
            if (guess.Length >= 5)
            {
                game.guess(guess);
                this.Update();
                guess = "";
            }
        }
        private void onClickBack(object s, EventArgs e)
        {
            if (game.locked) return;
            Letter le = game.board.letters.ElementAt(game.board.letters.FindLastIndex(v => v.element.Text.Length > 0));
            if (guess.Length < 1) return;
            guess = guess.Substring(0, guess.Length - 1);
            le.element.Text = "";
        }
        private void onKeyDown(object s, KeyEventArgs e)
        {
            if (game.locked) return;
            if (e.KeyCode == Keys.Back)
            {
                if (guess.Length > 0)
                {
                    guess = guess.Substring(0, guess.Length - 1);
                    Letter le = game.board.letters.ElementAt(game.board.letters.FindLastIndex(v => v.element.Text.Length > 0));
                    le.text = "";
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (guess.Length == 5)
                {
                    game.guess(guess);
                    this.Update();
                    guess = "";
                }
            }
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                if (guess.Length < 5)
                {
                    char key = e.KeyCode.ToString()[0];
                    guess += key;
                    Letter le = game.board.letters.ElementAt(game.board.letters.FindLastIndex(v => v.element.Text.Length > 0) + 1);
                    le.text = key.ToString();
                }
            }
        }
    }
}

class Scoreboard
{
    public string name;
    public int won = 0;
    public int lost = 0;
    public List<int> scores = new List<int>();
    public List<string> words = new List<string>();
    public Scoreboard(string name)
    {
        this.name = name;
    }
}