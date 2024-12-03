using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleNotepad.Models
{
    public class NumericStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            
                string prefixX = x.Split('(')[1].Split(')')[0];
                string prefixY = y.Split('(')[1].Split(')')[0];


                int index1 = int.Parse(prefixX);
                int index2 = int.Parse(prefixY);

                return index1 > index2 ? 1 : index1 == index2 ? 0 : -1;
        }
    }
}
