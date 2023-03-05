using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Core
{
    public class clsListsItem
    {
        private long ID;
        private string Name;
        private string LName;
        public clsListsItem(long val1, string val2, string val3)
        {
            this.ID = val1;
            this.Name = val2;
            this.LName = val3;
        }

        public long getID()
        {
            return this.ID;
        }

        public string getName()
        {
            return this.Name;
        }

        public string getLName()
        {
            return this.LName;
        }
    }
}
