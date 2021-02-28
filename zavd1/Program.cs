using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace zavd1
{
    class Program
    {
        static bool InputDouble(ref double a, string b)
        {
            string s;
            Povtor:
            s = Interaction.InputBox(b, "Introduction", a.ToString());
            try
            {
                a = Convert.ToDouble(s);
            }
            catch (System.FormatException)
            {
                if (MessageBox.Show("You did not enter a number \nDo you want to repeat?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    goto Povtor;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static bool InputInt(ref int a, string b)
        {
            string s;
            Povtor:
            s = Interaction.InputBox(b, "Introduction", a.ToString());
            try
            {
                a = Convert.ToInt32(s);
            }
            catch (System.FormatException)
            {
                if (MessageBox.Show("You did not enter a number \nDo you want to repeat?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    goto Povtor;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int n = 10;
            int i = 0;
            double min = 200, max = 400;
            double[] array = new double[n];
            Random random = new Random();
            string rez = "";

            Povtor:
            if (!InputInt(ref n, "Write n numbers: ")) return;
            if (!InputDouble(ref min, "Write min number: ")) return;
            if (!InputDouble(ref max, "Write max number: ")) return;

            for (; i < n; i++)
                array[i] = min + random.NextDouble() * (max - min);

            rez += "array 1:\n";

            for (i = 0; i < n; i++)
                rez += $" array[{i}]={array[i]}";

            Array.Resize(ref array, array.Length + 4);

            for (; i < n + 4; i++)
                array[i] = min + random.NextDouble() * (max - min);

            rez += "\n\narray 2:\n";

            for (i = 0; i < n + 4; i++)
                rez += $" array[{i}]={array[i]}";

            if (MessageBox.Show($"rezultat:\n{rez} \nDo you want to repeat?", "rezultat", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                goto Povtor;
        }
    }
}
