using System;
using System.Drawing;
using System.Windows.Forms;

namespace MD_editor
{
    public partial class FormImage : Form
    {
        private Bitmap m_bmp;

        public FormImage()
        {
            InitializeComponent();
        }

        public void SetFileName(string sImageName)
        {
            try
            {
                m_bmp = new Bitmap(sImageName);
                this.pictureBox1.Image = (Image)m_bmp;
                this.Text = "Зураг " + sImageName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа: " + ex.ToString());

            }
        }
    }
}