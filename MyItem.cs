using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    class MySorter
    {
        public ulong myCounter = 0;
        public int zipcode = 0; 
    }
    // This class represents Boxes on the Conveyor belt.
    class MyQueue : IComparable<MyQueue>
    {

        public ulong trigger { get; set; }
        public string ID { get; set; }
        public string zipcode { get; set; }
        public int lane { get; set; }

        public int CompareTo(MyQueue other)
        {
            if (this.trigger < other.trigger) return -1;
            else if (this.trigger > other.trigger) return 1;
            else return 0;
        

        }

    }
}