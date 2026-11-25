using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MD_editor
{
    public partial class FormText : Form
    {
        public FormText()
        {
            InitializeComponent();
        }

        public void SetFileName(string sFileName)
        {
            StreamReader reader = File.OpenText(sFileName);
            textBox1.Text = reader.ReadToEnd();
            reader.Close();
            textBox1.SelectionLength = 0;
            this.Text = "ТЕКСТ: " + sFileName;
        }
    }
}