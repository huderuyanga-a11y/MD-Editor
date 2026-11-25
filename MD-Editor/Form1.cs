using System;
using System.Windows.Forms;

namespace MD_editor
{
    public partial class Form1 : Form
    {
        private int formindex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // File → New: шинэ текст хүү цонх
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formindex = this.MdiChildren.Length;
            Form ChildForm = new Form();
            ChildForm.Name = "Child" + (formindex + 1).ToString();
            ChildForm.Text = "Child" + (formindex + 1).ToString();
            ChildForm.MdiParent = this;

            TextBox txtBox = new TextBox();
            txtBox.Dock = DockStyle.Fill;
            txtBox.Multiline = true;

            ChildForm.Controls.Add(txtBox);
            ChildForm.Show();
        }

        // File → Open: зураг эсвэл текст файл нээх
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OF = new OpenFileDialog();
            OF.Filter = "Text files (*.txt)|*.txt|jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|All files (*.*)|*.*";
            if (OF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sFN = OF.FileName;
                    string sExt = sFN.Substring(sFN.LastIndexOf(".")).ToUpper();

                    if (sExt == ".BMP" || sExt == ".JPG" || sExt == ".GIF")
                    {
                        FormImage imgForm = new FormImage();
                        imgForm.SetFileName(sFN);
                        imgForm.MdiParent = this;
                        imgForm.Show();
                    }
                    else if (sExt == ".TXT" || sExt == ".CS")
                    {
                        FormText txtForm = new FormText();
                        txtForm.SetFileName(sFN);
                        txtForm.MdiParent = this;
                        txtForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Уучлаарай. Файлыг нээж чадахгүй.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Алдаа: " + ex.ToString());
                }
            }
        }

        // File → Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // View → Arrange Icons / Cascade / Tile
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        // Бүх хүү цонхыг хаах
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (this.MdiChildren.Length > 0)
            {
                this.MdiChildren[0].Close();
            }
        }
    }
}