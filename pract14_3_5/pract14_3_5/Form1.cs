using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace pract14_3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int n = (int)numericUpDown1.Value;
            Queue queue = new Queue();
            for (int i = 1; i <= n; i++) queue.Enqueue(i);
            while (queue.Count > 0)
            {
                int number = (int)queue.Dequeue();
                listBox1.Items.Add(number);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int n = (int)numericUpDown2.Value;
            Queue yong = new Queue();
            Queue old = new Queue();
            using (StreamReader sr = new StreamReader("info.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    string i = parts[0];
                    string f = parts[1];
                    string o = parts[2];
                    int age = int.Parse(parts[3]);
                    int ves = int.Parse(parts[4]);
                    if (age < n) yong.Enqueue($"{i} {f} {o}, возраст: {age}, вес: {ves}");
                    else old.Enqueue($"{i} {f} {o}, возраст: {age}, вес: {ves}");
                }
            }
            foreach (string person in yong) listBox2.Items.Add(person);
            listBox2.Items.Add(" ");
            foreach(string person in old) listBox2.Items.Add(person);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Queue<string> people = new Queue<string>();
            listBox3.Items.Clear();
            using (StreamReader sr = new StreamReader("info.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null) people.Enqueue(line);
            }
            people = new Queue<string>(people.OrderBy(p => int.Parse(p.Split()[3])));
            Queue sort = new Queue();
            foreach(string person in people)
            {
                string[] parts = person.Split();
                sort.Enqueue($"{parts[0]} {parts[1]} {parts[2]}, возраст: {parts[3]}, вес: {parts[4]}");

            }
            foreach (string person in sort) listBox3.Items.Add(person);
        }
    }
}
