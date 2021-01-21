using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bugTracker
{
    /// <summary>
    /// Winform class that sets up the registraion page.
    /// </summary>
    public partial class Form5 : Form
    {
        /// <summary>
        /// Sets up the form components.
        /// </summary>
        public Form5()
        {
            //Method for the manufactured code.
            InitializeComponent();
        }

        /// <summary>
        /// Button sends the user to the login page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Opens login page.
            Form4 form4 = new Form4();
            form4.ShowDialog();
            //Closes registration page.
            this.Close();
        }

        /// <summary>
        /// This button allows the user to register an account assuming all the information added 
        /// was up to the programs validation tests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            //Saves the information from the text boxes as strings.
            String user = textBox1.Text;
            String pass = textBox2.Text;
            String rePass = textBox3.Text;
            String fullName = textBox4.Text;

            //If any validation errors occur, this value will increment and not allow for registration.
            int i = 0;

            //Validation to check whether the password and the repeated password are the same.
            if(pass != rePass)
            {
                //Displays a message if the two passwords are different.
                String passMatch = "The passwords don't match.";
                String passCaption = "Reapeat Password";
                MessageBoxButtons nullButton = MessageBoxButtons.OK;
                DialogResult passResult;
                passResult = MessageBox.Show(passMatch, passCaption, nullButton);

                //increments the variable.
                i++;
            }

            //Validation to check whether there were any null values added.
            if (user == "" || pass == "" || rePass == "" || fullName == "")
            {
                //Displays a message is null values were present.
                String nullValue = "Values cannot be null.";
                String nullCaption = "Null values";
                MessageBoxButtons nullButton = MessageBoxButtons.OK;
                DialogResult nullResult;
                nullResult = MessageBox.Show(nullValue, nullCaption, nullButton);

                //Increments the value.
                i++;
            }

            //Finds the length of the strings added in the text boxes.
            int userLength = user.Length;
            int passLength = pass.Length;
            int rePassLength = rePass.Length;

            //Validate to make sure the username was not too short.
            if(userLength < 6)
            {
                //Displays a message if the username is too short.
                String userValue = "Username must be longer than 6 characters.";
                String userCaption = "Username too short";
                MessageBoxButtons userButton = MessageBoxButtons.OK;
                DialogResult userResult;
                userResult = MessageBox.Show(userValue, userCaption, userButton);

                //Increments the value.
                i++;
            }

            //Validates to make sure the password is not too short.
            if(passLength < 6)
            {
                //Displays a message is the password is too short.
                String passValue = "Password must be longer than 6 characters.";
                String passCaption = "Password too short";
                MessageBoxButtons passButton = MessageBoxButtons.OK;
                DialogResult passResult;
                passResult = MessageBox.Show(passValue, passCaption, passButton);

                //Increments the value.
                i++;
            }

            //Makes sure no validation errors have occurred.
            if (i == 0)
            {

                //Sets up a connection to the database.
                SqlConnection mySqlConnection;
                mySqlConnection =
                new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dylan\Documents\Visual Studio 2017\bugTracker\bugTracker\bugTrack.mdf;Integrated Security=True;Connect Timeout=30");

                //Starts an insertion query for the users information to be added to the database.
                String insertcmd = "INSERT INTO userTable " + "(Username, Password, Full_Name) " + "VALUES(@username, @password, @fullname) SELECT SCOPE_IDENTITY()";

                //Sets up the command.
                SqlCommand mySqlCommand = new SqlCommand(insertcmd, mySqlConnection);

                //Opens a connection.
                mySqlConnection.Open();

                // create your parameters
                mySqlCommand.Parameters.Add("@username", System.Data.SqlDbType.Text);
                mySqlCommand.Parameters.Add("@password", System.Data.SqlDbType.Text);
                mySqlCommand.Parameters.Add("@fullname", System.Data.SqlDbType.Text);

                // set values to parameters from textboxes
                mySqlCommand.Parameters["@username"].Value = user;
                mySqlCommand.Parameters["@password"].Value = pass;
                mySqlCommand.Parameters["@fullname"].Value = fullName;

                //Executes the query.
                int RowsAffected = mySqlCommand.ExecuteNonQuery();

                //Displays a message for a successful registration.
                String message = "You have been registered. Please log in.";
                String caption = "Registered";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                //On closure of the pop up.
                if (result == DialogResult.OK)
                {
                    //Sends the user to now login.
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                    //Closes the registration page.
                    this.Close();
                }
            }
        }
    }
}
