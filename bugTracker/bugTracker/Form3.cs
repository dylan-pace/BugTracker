using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bugTracker
{
    /// <summary>
    /// Opens the bug log to see the logged bugs from the database.
    /// </summary>
    public partial class Form3 : Form
    {
        //Components added to the form.
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        //Database connection.
        SqlConnection mySqlConnection;

        /// <summary>
        /// Form that sets up the open log to see previous bugs.
        /// </summary>
        public Form3()
        {
            String file = Form1.fileName;
            String[] myData = new String[100];
            //Manufactured code method.
            InitializeComponent();

            //Sets up a connection to the database. 
            mySqlConnection =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dylan\Documents\Visual Studio 2017\bugTracker\bugTracker\bugTrack.mdf;Integrated Security=True;Connect Timeout=30");

            //SQL statement to select all previous logs from the database.
            SqlCommand cmd;
            SqlDataReader mySqlDataReader;

            //Checks whether a file is open.
            if (file == null || file == "")
            {
                //Command that will retrieve all data from the database in order to display it.
                cmd = new SqlCommand("SELECT * FROM bugTable;", mySqlConnection);

                //Opens the connection.
                mySqlConnection.Open();

                //Executes the code.
                mySqlDataReader = cmd.ExecuteReader();
            }

            else
            {
                //Checks whether a file is open. If so then find the bub logs related to that file.
                cmd = new SqlCommand("SELECT * FROM bugTable WHERE File_Name LIKE @file;", mySqlConnection);
                cmd.Parameters.AddWithValue("@file", file);

                //Opens the connection.
                mySqlConnection.Open();

                //Executes the code.
                mySqlDataReader = cmd.ExecuteReader();
            }
            
            int i = 0;
            //Reads all the information from the database.
            while (mySqlDataReader.Read())
            {
                int id = (int)mySqlDataReader["Bug_ID"];
                //Saves the information to the text box.
                richTextBox1.AppendText("Bug ID: " + id);
                richTextBox1.AppendText("\n");
                String Des = (String)mySqlDataReader["Description"];
                richTextBox1.AppendText("Description: " + Des);
                richTextBox1.AppendText("\n");
                String logName = (String)mySqlDataReader["Logger_Name"];
                richTextBox1.AppendText("Name of Logger: " + logName);
                richTextBox1.AppendText("\n");
                String dateLogged = (String)mySqlDataReader["Date_Logged"];
                richTextBox1.AppendText("Date Logged: " + dateLogged);
                richTextBox1.AppendText("\n");
                String fileName = (String)mySqlDataReader["File_Name"];
                richTextBox1.AppendText("File where bug was found: " + fileName);
                richTextBox1.AppendText("\n");
                String className = (String)mySqlDataReader["Class_Name"];
                richTextBox1.AppendText("Class where bug was found: " + className);
                richTextBox1.AppendText("\n");
                String methodName = (String)mySqlDataReader["Method_Name"];
                richTextBox1.AppendText("Method where bug was found: " + methodName);
                richTextBox1.AppendText("\n");
                int lineStart = (int)mySqlDataReader["Line_Start"];
                richTextBox1.AppendText("Line where bug starts: " + lineStart);
                richTextBox1.AppendText("\n");
                int lineEnd = (int)mySqlDataReader["Line_End"];
                richTextBox1.AppendText("Line where bug ends: " + lineEnd);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("--------------------------");
                richTextBox1.AppendText("\n");
                //Save the data in an array.
                myData[i++] = (String)mySqlDataReader["Description"]; 
                myData[i++] = (String)mySqlDataReader["Logger_Name"];
                myData[i++] = (String)mySqlDataReader["Date_Logged"];
                myData[i++] = (String)mySqlDataReader["Class_Name"];
                myData[i++] = (String)mySqlDataReader["Method_Name"];
                string startLine = Convert.ToString(lineStart);
                string endLine = Convert.ToString(lineEnd);
                myData[i++] = startLine;
                myData[i++] = endLine;

            }

            for (int j = 0; j < i; j++) 
            {
                //Displays information to the console too.
                Console.WriteLine("***" + myData[j] + "***");

            }
        }

        /// <summary>
        /// Manufactured code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(343, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(318, 355);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Form3
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(343, 404);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "Bug Log";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 'About' menu item to give the user some infomration about the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //Displays an informative message.
            String message = "This program is used to track bugs in code.";
            String caption = "About this program";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }

        /// <summary>
        /// 'Exit' menu item to allow the user to quit the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //Asks whether they want to quits.
            String message = "Exit the program?";
            String caption = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                //Quits the program is the yes button is pressed.
                Application.Exit();
            }
        }
    }
}