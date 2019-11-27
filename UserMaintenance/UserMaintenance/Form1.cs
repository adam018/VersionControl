using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.Lastname;
            
            button1.Text = Resource1.Add;
            listBox1.DataSource = users;
            listBox1.DisplayMember = "Fullname";
            listBox1.ValueMember = "ID";
            button2.Text = Resource1.CreateFile;
            button3.Text = Resource1.Delete;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text            

            };
            users.Add(u);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            
            

            save.DefaultExt = ".csv";
            save.AddExtension = true;
            if (save.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName))
                {
                    foreach (var u in users)
                    {
                        sw.Write(u.ID);
                        sw.Write( ";");
                        sw.Write(u.FullName);
                        sw.WriteLine();
                    }
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            users.RemoveAt(listBox1.SelectedIndex);
            listBox1.DataSource = users;
        }
    }
}
