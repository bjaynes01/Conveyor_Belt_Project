using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySorter MySort = new MySorter();
        //Random numer generator
        Random MyRandom = new Random();
        // Queue of boxes.
        MyQueue MyQue = new MyQueue();
        //List for storying Que objects.
        List<MyQueue> MyArrList = new List<MyQueue>();

        int lane1 = 0;
        int lane2 = 0;
        int lane3 = 0;
        int lane4 = 0;
        int lane5 = 0;
        int lane6 = 0;
        int lane7 = 0;
        int lane8 = 0;
        int lane9 = 0;
        int lane10 = 0;



        private void timer1_Tick(object sender, EventArgs e)
        {
            //Do this on every tenth tick of the timer.
            if (MySort.myCounter % 10 == 0)
            {
                reset_gates();
                // Generate zip between 1 and 10
                MySort.zipcode = MyRandom.Next(1, 11);
                // Append zipcode to coutner to calculate arival time to gate ona conveyer belt.
                MyQue.trigger = MySort.myCounter + (ulong)MySort.zipcode * 10;
                if (MySort.zipcode == 10)
                {
                    //Set zipcode for 10 as it being a double digit number it needs to be handled differentlty when generating zip codes.
                    MyQue.zipcode = "02000";
                }
                else
                {
                    //store zipcode as 5 digit number as zip codes are 5 digit numbers.
                    MyQue.zipcode = string.Concat(MySort.zipcode.ToString() + "0000");
                }
                MyArrList.Add(new MyQueue()
                {
                    lane = MySort.zipcode,
                    trigger = MyQue.trigger,
                    zipcode = MyQue.zipcode,
                    ID = MySort.myCounter.ToString()
                });
                MyArrList.Sort();
                copy_array_listbox();
            }
            //Reset gates.
            reset_gates();
            // figure out next gate to fire.
            calc_lane();
            //increment counter
            MySort.myCounter++;
            //Increment conter on form.
            label1.Text = MySort.myCounter.ToString();
        }
        //this method simulates the opening of a gate on the conveyor belt.
        public void fire_gate(int my_arm)
        {
            switch (my_arm)
            {
                case 1:
                    lane1++;
                    textBox2.Text = lane1.ToString();
                    textBox2.BackColor = Color.Green;
                    break;
                case 2:
                    lane2++;
                    textBox3.Text = lane2.ToString();
                    textBox3.BackColor = Color.Green;
                    break;
                case 3:
                    lane3++;
                    textBox4.Text = lane3.ToString();
                    textBox4.BackColor = Color.Green;
                    break;
                case 4:
                    lane4++;
                    textBox5.Text = lane4.ToString();
                    textBox5.BackColor = Color.Green;
                    break;
                case 5:
                    lane5++;
                    textBox6.Text = lane5.ToString();
                    textBox6.BackColor = Color.Green;
                    break;
                case 6:
                    lane6++;
                    textBox7.Text = lane6.ToString();
                    textBox7.BackColor = Color.Green;
                    break;
                case 7:
                    lane7++;
                    textBox8.Text = lane7.ToString();
                    textBox8.BackColor = Color.Green;
                    break;
                case 8:
                    lane8++;
                    textBox9.Text = lane8.ToString();
                    textBox9.BackColor = Color.Green;
                    break;
                case 9:
                    lane9++;
                    textBox10.Text = lane9.ToString();
                    textBox10.BackColor = Color.Green;
                    break;
                case 10:
                    lane10++;
                    textBox11.Text = lane10.ToString();
                    textBox11.BackColor = Color.Green;
                    break;

            }

        }
        // remove data from list when trigger is met.
        public void calc_lane()
        {
            if (!(MyArrList.Count == 0))
            {
                ulong my_trigger = MyArrList[0].trigger;
                while (MySort.myCounter == my_trigger)
                {
                    fire_gate(MyArrList[0].lane);
                    MyArrList.RemoveAt(0);
                    MyArrList.Sort();
                    copy_array_listbox();
                    my_trigger = MyArrList[0].trigger;

                }
            }
        }
        // Used to reset boxes whenever needed
        public void reset_gates()
        {
            textBox2.BackColor = Color.Yellow;
            textBox3.BackColor = Color.Yellow;
            textBox4.BackColor = Color.Yellow;
            textBox5.BackColor = Color.Yellow;
            textBox6.BackColor = Color.Yellow;
            textBox7.BackColor = Color.Yellow;
            textBox8.BackColor = Color.Yellow;
            textBox9.BackColor = Color.Yellow;
            textBox10.BackColor = Color.Yellow;
            textBox11.BackColor = Color.Yellow;


            textBox2.Text = lane1.ToString();
            textBox3.Text = lane2.ToString();
            textBox4.Text = lane3.ToString();
            textBox5.Text = lane4.ToString();
            textBox6.Text = lane5.ToString();
            textBox7.Text = lane6.ToString();
            textBox8.Text = lane7.ToString();
            textBox9.Text = lane8.ToString();
            textBox10.Text = lane9.ToString();
            textBox11.Text = lane10.ToString();

        }
        // This method is used to display the data for packages added to/and still on the conveyo
        void copy_array_listbox()
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            foreach (var myentry in MyArrList)
            {
                String myString = String.Concat(myentry.ID, "     ",
                    myentry.lane.ToString(), "       ",
                    myentry.trigger.ToString(), "         ",
                    myentry.zipcode);
                listBox1.Items.Add(myString);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //If stop button is pressed stop timer and change stop button to start button.
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "Start";
                button1.BackColor = Color.Yellow;
                button1.ForeColor = Color.Black;
                textBox2.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
                textBox4.BackColor = Color.Red;
                textBox5.BackColor = Color.Red;
                textBox6.BackColor = Color.Red;
                textBox7.BackColor = Color.Red;
                textBox8.BackColor = Color.Red;
                textBox9.BackColor = Color.Red;
                textBox10.BackColor = Color.Red;
                textBox11.BackColor = Color.Red;

            }
            //If start button is pressed start timer and change stop button to stop button.
            else
            {
                timer1.Enabled = true;
                button1.Text = "Stop";
                button1.BackColor = Color.Green;
                button1.ForeColor = Color.White;
                textBox2.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                textBox5.BackColor = Color.Yellow;
                textBox6.BackColor = Color.Yellow;
                textBox7.BackColor = Color.Yellow;
                textBox8.BackColor = Color.Yellow;
                textBox9.BackColor = Color.Yellow;
                textBox10.BackColor = Color.Yellow;
                textBox11.BackColor = Color.Yellow;
            }
        }
        // On Formload set some defaults.
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 250;
            button1.BackColor = Color.Yellow;
            button1.Text = "Start";
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.White;
            button2.Text = "Reset";
            label2.Text = "Counter:";
        }
        // This is the Reset Button Implentation.
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Text = "Start";
            button1.BackColor = Color.Yellow;
            button1.ForeColor = Color.Black;

            lane1 = 0;
            lane2 = 0;
            lane3 = 0;
            lane4 = 0;
            lane5 = 0;
            lane6 = 0;
            lane7 = 0;
            lane8 = 0;
            lane9 = 0;
            lane10 = 0;

            MySort.myCounter = 0;
            label1.Text = MySort.myCounter.ToString();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            MyArrList.Clear();
            reset_gates();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        // Each time the timer built into the form ticks this
    }
}
