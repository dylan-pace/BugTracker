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
    /// <summary>
    /// Winform Class to set up the main bug tracker page.
    /// </summary>
    public partial class Form1 : Form
    {
        //Saves the code opened by the user.
        public static String code;
        public static string fileName;

        /// <summary>
        /// Constructor that sets up the components
        /// </summary>
        public Form1()
        {
            //Manufactured code method.
            InitializeComponent();
            //Allowed the web browser text box to be editable
            webBrowser1.DocumentText = "<HTML><BODY contentEditable='true'></BODY></HTML>";
            //Hides the 'Log Bug' item on the menu bar.
            logBugToolStripMenuItem.Visible = false;

        }

        /// <summary>
        /// The 'About' item on the menu bar. Gives the user information about the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displays a message with information telling the user what this program will do.
            String message = "This program is used to track bugs in code.";
            String caption = "About this program";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

        }

        /// <summary>
        /// The 'Exit' menu item. Closes the program when requested by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displays a message asking for confirmation to close the program.
            String message = "Exit the program?";
            String caption = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            //If yes then close the program.
            if(result == DialogResult.Yes)
            {
                //Closes the program.
                Application.Exit();
            }
        }

        /// <summary>
        /// The 'Open' tool on the menu bar. Allows the user to open a piece of code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the file cannot be opened, the program will watch the error.
            try
            {

                //Allows the user to selected a file.
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {

                    //Reads the files and save is to a string.
                    string sourceCode = File.ReadAllText(file.FileName);

                    //Colourizes the text so it looks like c# code.
                    string colorizedSourceCode = new CodeColorizer().Colorize(sourceCode, Languages.CSharp);

                    //Saves the code coloured text to the web browser and allows it to be editable.
                    webBrowser1.DocumentText = "<HTML><BODY contentEditable='true'></BODY></HTML>" + colorizedSourceCode;

                    //Saves the editable text in a string.
                    code = colorizedSourceCode;
                    fileName = file.SafeFileName;

                    //Displays the 'Log Bug' menu item now a piece of code is open.
                    logBugToolStripMenuItem.Visible = true;
                }
            }
            //Exception for input/output errors with files.
            catch  (IOException h)
            {
                //Message saying that the file format chosen was usuitable for the program to open..
                String message = "Cannot open this specific file.";
                String caption = "Unable to open.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
            }

        }

        /// <summary>
        /// Allows the user to save what is in the web browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens the save dialog.
            webBrowser1.ShowSaveAsDialog();
         
        }

        /// <summary>
        /// Menu item that will take the user to the 'Log Bug' page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens the 'Log Bug' form.
            Form2 form2 = new Form2();
            form2.Show();
        }

        /// <summary>
        /// Mneu item that will take users to the 'Open Log' form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens the 'Open Log' form.
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
