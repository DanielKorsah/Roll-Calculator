using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //lazy dirty globals
        //the complete string to print to box initialised as empty  
        StringBuilder outputString = new StringBuilder();
        //the complete formatted string of all items printed to the output box
        StringBuilder permanentLog = new StringBuilder();
        //the number of rolls made since startup for formatting the permanent log
        int rollCount;

        public Form1()
        {
            InitializeComponent();
        }

        //Top level UI button clicks
        //----------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            clearOutput(); //clear box on new roll
            takeInputs(); //also cals the method for generating roll resluts
            outputBox.Text = outputString.ToString();
            rollCount++;
            permanentLog.Append("Roll " + rollCount + ":\r\n" + outputString.ToString() + "--------------- \r\n");
        }

        private void dumpLog_Click(object sender, EventArgs e)
        {
            outputBox.Text = permanentLog.ToString(); 
        }

        void clearAll_Click(object sender, EventArgs e)
        {
            clearOutput();
            resetInputFields();
        }
        //-----------------------------------------------------------------------------------


        
        void takeInputs()
        {
            //list of input fields
            List<TextBox> inputField = new List<TextBox>() { input1, input2, input5, input3, input4, input6,input7, input8 };

            //perform calculation method on each input field
            for (int index = 0; index<8; index++)
            {
                string inputValue = inputField[index].Text;

                if (inputValue == "" || inputValue == null)
                {
                    inputValue = "0";
                }

                if(inputValue.Length > 7)
                {
                    MessageBox.Show("ERROR! - Input too large. Must be less than or equal to 7 charcters long.", "Invalid input! Too long to parse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                //parse string input to for use as number of rolls per die, throw error if text in a box
                int numRolls;
                bool result = Int32.TryParse(inputValue, out numRolls); 
                if (result == false)
                {
                    MessageBox.Show("Invalid input! Use only numbers.", "ERROR! - Nonnumerical input.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                calculateRolls(ref index, ref numRolls);
                
                
            }

            if(checkBox1.Checked == false)
            resetInputFields();// reset all the input fields to 0 after using them
            
        }


        //generate random numbers
        //------------------------------------------------------------
        void calculateRolls(ref int index, ref int numRolls)
        {
            
            Random rnd = new Random();
            if (index == 0) //roll d2s
            {
                while (numRolls > 0)
                {
                    int d2Roll = rnd.Next(1, 3);
                    outputString.Append("d2: " + d2Roll + "\r\n");

                    //output = "d2: " + d2Roll + "\r\n"; a wee test of dynamic printing
                    //outputBox.Text += output;
                    numRolls--;
                }
            }


            if (index == 1) //roll d4s
            {
                while (numRolls > 0)
                {
                    int d4Roll = rnd.Next(1, 5);
                    outputString.Append("d4: " + d4Roll + "\r\n");
                    numRolls--;
                }
            }

            if (index == 2) //roll d6s
            {
                while (numRolls > 0)
                {
                    int d6Roll = rnd.Next(1, 7);
                    outputString.Append("d6: " + d6Roll + "\r\n");
                    numRolls--;
                }
            }


            if (index == 3) //roll d8s
            {
                while (numRolls > 0)
                {
                    int d8Roll = rnd.Next(1, 9);
                    outputString.Append("d8: " + d8Roll + "\r\n");
                    numRolls--;
                }
            }

            if (index == 4) //roll d10s
            {
                while (numRolls > 0)
                {
                    int d10Roll = rnd.Next(1, 11);
                    outputString.Append("d10: " + d10Roll + "\r\n");
                    numRolls--;
                }
            }

            if (index == 5) //roll d12s
            {
                while (numRolls > 0)
                {
                    int d12Roll = rnd.Next(1, 13);
                    outputString.Append("d12: " + d12Roll + "\r\n");
                    numRolls--;
                }

            }

            if (index == 6) //roll d12s
            {
                while (numRolls > 0)
                {
                    int d20Roll = rnd.Next(1, 13);
                    outputString.Append("d20: " + d20Roll + "\r\n");
                    numRolls--;
                }

            }

            if (index == 7) //roll d100s
            {
                while (numRolls > 0)
                {
                    int d100Roll = rnd.Next(1, 101);
                    outputString.Append("d100: " + d100Roll + "\r\n");
                    numRolls--;
                }

            }

        }
        //------------------------------------------------------------


        void resetInputFields()
        {
            List<TextBox> inputField = new List<TextBox>() { input1, input2, input5, input3, input4, input6, input7, input8 };
            for (int i = 0; i <8; i++)
            {
                inputField[i].Text = "0";
            }
        }

        void clearOutput()
        {
            outputBox.Text = "";
            outputString.Clear();
        }

        private void nukeButton_Click(object sender, EventArgs e)
        {
            permanentLog.Clear();
            clearOutput();
        }
    }
}

