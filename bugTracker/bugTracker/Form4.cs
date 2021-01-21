using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace bugTracker
{
    /// <summary>
    /// Winform class for the login page.
    /// </summary>
    public partial class Form4 : Form
    {
        //Components added to the form.
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button loginButton;
        private Button registerButton;
        SqlConnection mySqlConnection;
        public static String name;

        /// <summary>
        /// Constructor that sets up the form. 
        /// </summary>
        public Form4()
        {
            //manufactured code that sets up the form.
            InitializeComponent();
        }

        /// <summary>
        /// Manufactured code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(17, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(23, 198);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(145, 197);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 6;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form4
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form4";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Button that sends the user to the registration form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Closes the login page.
            this.Hide();
            //Sends the user to the registration page.
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();

        }

        /// <summary>
        /// This login button takes the information entered into the text boxes and validates them
        /// against the information in the database to see if the user has the right data to login with.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Saves the info in the text boxes.
            String usr = textBox1.Text;
            String pwd = textBox2.Text;

            //Connects to the database.
            mySqlConnection =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dylan\Documents\Visual Studio 2017\bugTracker\bugTracker\bugTrack.mdf;Integrated Security=True;Connect Timeout=30");

            //Query to validate the text box information with that in the database.
            SqlCommand cmd = new SqlCommand("select * from userTable where Username like @username and Password like @password;");
            cmd.Parameters.AddWithValue("@username", usr);
            cmd.Parameters.AddWithValue("@password", pwd);
            //Opens the connection
            cmd.Connection = mySqlConnection;
            mySqlConnection.Open();

                //Saves the data in a DataSet for validation.
                DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            //Compares the info.
            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            //If true then the login was a success.
            if (loginSuccessful)
            {

                //Gets the values for the users name from the database.
                SqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    name = (String)mySqlDataReader["Full_Name"];

                }
                //Closes the connection to the database.
                mySqlConnection.Close();

                //Displays a success message.
                String message = "You have logged In.";
                String caption = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.OK)
                {
                    //Sends the user to the main bug tracker page.
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    //Closes the login page.
                    this.Close();

                }
            }
            else
            {
                //Displays a message if the login was unsuccessful.
                String message = "Invalid username or password.";
                String caption = "Not logged in.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
            }

            //Connection closes.
            mySqlConnection.Close();
        }

    }
}