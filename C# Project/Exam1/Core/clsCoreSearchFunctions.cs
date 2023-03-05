using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Core
{
    public class clsCoreSearchFunctions
    {
        private long[] data;
        private string[] sdata;

        public clsCoreSearchFunctions(long[] value)
        {
            this.data = value;
        }

        public clsCoreSearchFunctions(string[] value)
        {
            this.sdata = value;
        }

        public void setData(long[] value)
        {
            this.data = value;
        }

        public long[] getData()
        {
            return this.data;
        }

        public void setDataList(List<long> value)
        {
            this.data = value.ToArray();
        }

        public List<long> getDataList()
        {
            return this.data.ToList<long>();
        }

        //this function is overloaded
        public long BinarySearch(long searchkey) //without recursive
        {
            long min = 0;
            long max = this.data.Length - 1;
            long position = -1; //this function will return -1 if element is not found.
            while (min <= max)
            {
                long mid = (min + max) / 2;
                if (searchkey == this.data[mid])
                {
                    position = ++mid;
                    break;
                }
                else if (searchkey < this.data[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return position;
        }

        public long BinarySearch(long searchkey, long min, long max) //using recursive
        {
            long position = -1;
            if (min > max)
            {
                return position; //this function will return -1 if element is not found.
            }
            else
            {
                long mid = (min + max) / 2;
                if (searchkey == this.data[mid])
                {
                    return ++mid;
                }
                else if (searchkey < this.data[mid])
                {
                    return BinarySearch(searchkey, min, mid - 1);
                }
                else
                {
                    return BinarySearch(searchkey, mid + 1, max);
                }
            }
        }

        public long LinerSearch(string searchkey) {
            long l = this.sdata.Length;
            long pos = -1;
            
            for(long i = 0; i <l; i++)
            {
                if (this.sdata[i] == searchkey)
                {
                    pos = i;
                    break; //to stop for when item is found.
                }
            }
            return pos;
        }
    }
}
