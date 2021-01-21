using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorCode;

namespace bugTracker
{
    public partial class Form1 : Form
    {

        public Form1()
        {
           
            InitializeComponent();
            webBrowser1.DocumentText = "<HTML><BODY contentEditable='true'></BODY></HTML>";

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "This program is used to track bugs in code.";
            String caption = "About this program";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "Exit the program?";
            String caption = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //String path;
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog() == DialogResult.OK)
            {
                //path = file.FileName;

                //richTextBox1.LoadFile(file.FileName, RichTextBoxStreamType.PlainText);

                string sourceCode = File.ReadAllText(file.FileName);

                string colorizedSourceCode = new CodeColorizer().Colorize(sourceCode, Languages.CSharp);

                //webBrowser1.Text = colorizedSourceCode;

                webBrowser1.DocumentText = colorizedSourceCode;

                webBrowser1.DocumentText = "<HTML><BODY contentEditable='true'></BODY></HTML>";

                System.IO.StreamReader txtReader;
                txtReader = new System.IO.StreamReader(file.FileName);
                webBrowser1.DocumentText = txtReader.ReadToEnd();
                txtReader.Close();
                txtReader = null;
                HtmlDocument doc = webBrowser1.Document.OpenNew(false);
                doc.ExecCommand("EditMode", false, null);



            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.txt";

            if(saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
            {
                webBrowser1.ShowSaveAsDialog();
            }
        }

        private void logBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Application.EnableVisualStyles();
          //  Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form2());
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
