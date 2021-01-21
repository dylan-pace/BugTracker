using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace bugTracker
{
    /// <summary>
    /// Winform class to log bugs.
    /// </summary>
    public partial class Form2 : Form
    {
        //Components of the form.
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox loggerNameText;
        private RichTextBox descriptionText;
        private Label label4;
        private DateTimePicker dateText;
        private Button button1;
        private Label label5;
        private TextBox classText;
        private Label label6;
        private TextBox methodText;
        private Label label7;
        private NumericUpDown startInt;
        private Label label8;
        private NumericUpDown endInt;
        private MenuStrip menuStrip1;

        //Constructor to set up components.
        public Form2()
        {
            //Maufactured code.
            InitializeComponent();
            //Saves the loggers name to the textbox.
            String logName = Form4.name;
            loggerNameText.AppendText(logName);
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loggerNameText = new System.Windows.Forms.TextBox();
            this.descriptionText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateText = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.classText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.methodText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startInt = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.endInt = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endInt)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(468, 24);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bug Logger";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name of Logger:";
            // 
            // loggerNameText
            // 
            this.loggerNameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loggerNameText.Location = new System.Drawing.Point(18, 153);
            this.loggerNameText.Name = "loggerNameText";
            this.loggerNameText.ReadOnly = true;
            this.loggerNameText.Size = new System.Drawing.Size(246, 20);
            this.loggerNameText.TabIndex = 5;
            // 
            // descriptionText
            // 
            this.descriptionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionText.CausesValidation = false;
            this.descriptionText.Location = new System.Drawing.Point(18, 80);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(246, 54);
            this.descriptionText.TabIndex = 6;
            this.descriptionText.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date Logged";
            // 
            // dateText
            // 
            this.dateText.Location = new System.Drawing.Point(18, 193);
            this.dateText.MaxDate = new System.DateTime(2028, 10, 27, 0, 0, 0, 0);
            this.dateText.MinDate = new System.DateTime(2018, 10, 26, 0, 0, 0, 0);
            this.dateText.Name = "dateText";
            this.dateText.Size = new System.Drawing.Size(200, 20);
            this.dateText.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Class Name";
            // 
            // classText
            // 
            this.classText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classText.Location = new System.Drawing.Point(18, 237);
            this.classText.Name = "classText";
            this.classText.Size = new System.Drawing.Size(246, 20);
            this.classText.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Method Name";
            // 
            // methodText
            // 
            this.methodText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.methodText.Location = new System.Drawing.Point(18, 281);
            this.methodText.Name = "methodText";
            this.methodText.Size = new System.Drawing.Size(246, 20);
            this.methodText.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Line Start";
            // 
            // startInt
            // 
            this.startInt.Location = new System.Drawing.Point(21, 324);
            this.startInt.Name = "startInt";
            this.startInt.Size = new System.Drawing.Size(49, 20);
            this.startInt.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Line End";
            // 
            // endInt
            // 
            this.endInt.Location = new System.Drawing.Point(169, 324);
            this.endInt.Name = "endInt";
            this.endInt.Size = new System.Drawing.Size(53, 20);
            this.endInt.TabIndex = 17;
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(468, 409);
            this.Controls.Add(this.endInt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.startInt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.methodText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.classText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.loggerNameText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Bug Logger";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// On click the info in the text boxes will be logged in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            //Save the name of the opened file.
            String file = Form1.fileName;
            String logName = Form4.name;

            //Saves the information from the text boxes to strings and ints.
            String des = descriptionText.Text;
            String name = logName;
            String date = dateText.Text;
            String className = classText.Text;
            String methodName = methodText.Text;
            decimal start = startInt.Value;
            int startLine = Convert.ToInt32(start);
            decimal end = endInt.Value;
            int endLine = Convert.ToInt32(end);

            //Sets up a database connection.
            SqlConnection mySqlConnection;
            mySqlConnection =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dylan\Documents\Visual Studio 2017\bugTracker\bugTracker\bugTrack.mdf;Integrated Security=True;Connect Timeout=30");

            //SQL code to insert information into database.
            String insertcmd = "INSERT INTO bugTable " + "(Description, Logger_Name, Date_Logged, Class_Name, Method_Name, Line_Start, Line_End, File_Name) " + "VALUES(@Description, @Logger_Name, @Date_Logged, @Class_Name, @Method_Name, @Line_Start, @Line_End, @File_Name) SELECT SCOPE_IDENTITY()";

            //Sets up command for insertion.
            SqlCommand mySqlCommand = new SqlCommand(insertcmd, mySqlConnection);

            //Opens the connection to the database.
            mySqlConnection.Open();

            //Create the parameters.
            mySqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.Text);
            mySqlCommand.Parameters.Add("@Logger_Name", System.Data.SqlDbType.Text);
            mySqlCommand.Parameters.Add("@Date_Logged", System.Data.SqlDbType.Text);
            mySqlCommand.Parameters.Add("@Class_Name", System.Data.SqlDbType.Text);
            mySqlCommand.Parameters.Add("@Method_Name", System.Data.SqlDbType.Text);
            mySqlCommand.Parameters.Add("@Line_Start", System.Data.SqlDbType.Int);
            mySqlCommand.Parameters.Add("@Line_End", System.Data.SqlDbType.Int);
            mySqlCommand.Parameters.Add("@File_Name", System.Data.SqlDbType.Text);

            //Set values to parameters from textboxes.
            mySqlCommand.Parameters["@Description"].Value = des;
            mySqlCommand.Parameters["@Logger_Name"].Value = name;
            mySqlCommand.Parameters["@Date_Logged"].Value = date;
            mySqlCommand.Parameters["@Class_Name"].Value = className;
            mySqlCommand.Parameters["@Method_Name"].Value = methodName;
            mySqlCommand.Parameters["@Line_Start"].Value = startLine;
            mySqlCommand.Parameters["@Line_End"].Value = endLine;
            mySqlCommand.Parameters["@File_Name"].Value = file;

            //Values that increments with validation errors.
            int i = 0;

            //Validation check to make sure the end line of the bug isn't less than the start line
            if (endLine < startLine)
            {
                //Displays an error message.
                String lineValue = "The start line of the bug was greater than the end line." +
                    " Consider swapping the values.";
                String lineCaption = "Start line > End line";
                MessageBoxButtons lineButton = MessageBoxButtons.OK;
                DialogResult lineResult;
                lineResult = MessageBox.Show(lineValue, lineCaption, lineButton);

                //Increments the value.
                i++;

            }

            //Validation check to make sure there are no null values.
            if (des == "" || name == "" || date == "" || className == "" || methodName == "")
            {
                //Displays an error message is a null values is caught. 
                String nullValue = "Values cannot be null.";
                String nullCaption = "Null values";
                MessageBoxButtons nullButton = MessageBoxButtons.OK;
                DialogResult nullResult;
                nullResult = MessageBox.Show(nullValue, nullCaption, nullButton);

                //Increments the value.
                i++;
            }

            //Checks to see if there are any validation errors.
            if (i == 0) { 

                //Executes the query is no validation errors were found.
                int RowsAffected = mySqlCommand.ExecuteNonQuery();

                //Allows the user to save the bug data.
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "bugData.txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //Sets up the writer so info can be written to a file.
                    StreamWriter writer = new StreamWriter(save.FileName);

                    //Writes the bug data to a file.
                    writer.WriteLine("Description: " + des);
                    writer.WriteLine("Name of Logger: " + name);
                    writer.WriteLine("Date Logged: " + date);
                    writer.WriteLine("Class where bug can be found: " + className);
                    writer.WriteLine("Method where bug can be found " + methodName);
                    writer.WriteLine("Line where bug starts " + startLine);
                    writer.WriteLine("Line where bug ends: " + endLine);

                    //Closes the writer.
                    writer.Dispose();
                    writer.Close();

                }

                //Version control.
                Process process = new Process();
                process.StartInfo.FileName = @"C:\Windows\SYSTEM32\cmd.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine(@"cd C:\Users\dylan\source\repos\bugtrackdata");
                process.StandardInput.WriteLine("git add --all");
                process.StandardInput.WriteLine("git commit -m '" + des + "'");
                process.StandardInput.WriteLine("git push");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.Read();
                //Version Control - bug data code goes here.

                //Message to tell the user the bug has been logged.
                String message = "Bug report logged.";
                String caption = "Logged";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        /// <summary>
        /// 'Exit' menu item to stop the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //Asks whether they want ot close the program.
            String message = "Exit the program?";
            String caption = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            //Checks for user confirmation.
            if (result == DialogResult.Yes)
            {
                //Closes the program.
                Application.Exit();
            }
        }

        /// <summary>
        /// 'About' menu item to give the user some information about the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display the information message.
            String message = "This program is used to track bugs in code.";
            String caption = "About this program";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }
    }
}