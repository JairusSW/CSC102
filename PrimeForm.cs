/**
 * CSC102 Project 1 written by John and Jairus
 * John wrote the simple prime number algorithm
 * I wrote the rest
 * This includes several algorithms to play around with
 * I also have this posted on my github:
 * https://github.com/JairusSW/CSC102/tree/Project01
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project01
{
    public partial class PrimeForm : Form
    {
        public List<string> logs = new List<string>();
        public PrimeForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            logs = new List<string>(); // clear logs
            int limit = int.Parse(limitInput.Text);

            List<int> result = new List<int>();

            if (algorithm.Text == "Eratosthenes") result = calcEratosthenesSieve(limit);
            else if (algorithm.Text == "Atkin's") result = calcAtkinsSieve(limit);
            else result = calcSimple(limit);

            resultsBox.DataSource = result;
            quantityofprimenum.Text = result.Count.ToString();

            logsBox.DataSource = logs;
        }

        private List<int> calcSimple(int limit)
        {
            // Algorithm written by John Gao
            // We worked on it together
            List<int> primes = new List<int>();

            int ops = 0;

            for (int i = 2; i < limit; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    ops++;
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) primes.Add(i);
            }

            logs.Add("Using simple algorithm\n");
            logs.Add("Complexity (Worst): O(n^2)");
            logs.Add("Calculating all primes up to " + limit);
            logs.Add("Found " + primes.Count.ToString() + " primes in " + ops + " operations.");
            logs.Add("\nTry using a different algorithm!");
            return primes;
        }

        private List<int> calcEratosthenesSieve(int limit)
        {
            // Sieve of Eratosthenes
            // Reference: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
            // Ported by Jairus Tanaka

            List<int> primes = new List<int>();

            int ops = 0;

            bool[] sieve = new bool[limit + 1];

            for (int i = 0; i <= limit; i++) sieve[i] = true;
            // 0 and 1 cannot be prime
            sieve[0] = false;
            sieve[1] = false;

            for (int i = 2; i * i <= limit; i++)
            {
                if (!sieve[i]) continue;
                // update all multiples of i to be not prime
                for (int ii = i * i; ii <= limit; ii += i)
                {
                    ops++;
                    sieve[ii] = false;
                }
            }

            for (int i = 2; i <= limit; i++)
            {
                if (sieve[i]) primes.Add(i);
            }

            logs.Add("Using Eratosthenes algorithm\n");
            logs.Add("Complexity (Worst): O(N*log(log(N)))");
            logs.Add("Calculating all primes up to " + limit);
            logs.Add("Found " + primes.Count.ToString() + " primes in " + ops + " operations.");

            return primes;
        }
        private List<int> calcAtkinsSieve(int limit)
        {
            // Atkin's Sieve
            // Reference: https://en.wikipedia.org/wiki/Sieve_of_Atkin
            // Ported by Jairus Tanaka from GeeksForGeeks' C implementation
            // I think I can rewrite this using SIMD instructions to make it use even less operations...
            // And by the way, I did take time to understand these algorithms, I'm not just copy and pasting them
            // Implementation source: https://www.geeksforgeeks.org/sieve-of-atkin/

            List<int> primes = new List<int>();
            int ops = 0;

            bool[] sieve = new bool[limit + 1];

            for (int i = 0; i <= limit; i++) sieve[i] = false;

            if (limit > 2) sieve[2] = true;
            if (limit > 3) sieve[3] = true;

            for (int x = 1; x * x <= limit; x++)
            {
                for (int y = 1; y * y <= limit; y++)
                {
                    ops++;
                    // All these check if x and y have an odd number of solutions. If it is the case, it could possibly be a prime number. We then pass it through the "sieve" to determine if it is a true prime
                    // if it passes a check, it is upgraded to a prime candidate. then, if it passes all three checks, it is a true prime

                    int n = (4 * x * x) + (y * y);
                    if (n <= limit
                        && (n % 12 == 1 || n % 12 == 5))
                    {
                        sieve[n] ^= true;
                    }

                    n = (3 * x * x) + (y * y);
                    if (n <= limit && n % 12 == 7)
                    {
                        sieve[n] ^= true;
                    }

                    n = (3 * x * x) - (y * y);
                    if (x > y && n <= limit
                        && n % 12 == 11)
                    {
                        sieve[n] ^= true;
                    }
                }
            }



            for (int r = 5; r * r < limit; r++)
            {
                if (!sieve[r]) continue;
                for (int i = r * r; i < limit; i += r * r) sieve[i] = false;
            }

            // Print primes using sieve[]
            for (int a = 2; a <= limit; a++) if (sieve[a]) primes.Add(a);

            logs.Add("Using Atkin's algorithm\n");
            logs.Add("Complexity (Worst): O(n)");
            logs.Add("Calculating all primes up to " + limit);
            logs.Add("Found " + primes.Count.ToString() + " primes in " + ops + " operations.");

            return primes;
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            logs = new List<string>();
            resultsBox.DataSource = new List<int>();
            quantityofprimenum.Text = "";
            logsBox.DataSource = logs;
            limitInput.Text = "";
            algorithm.Text = "Simple";
        }
    }
}
