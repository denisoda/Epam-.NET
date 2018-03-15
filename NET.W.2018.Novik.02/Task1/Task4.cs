using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Task4
    {
        public static List<int> FilterDigit(IEnumerable<int> list, int digit)
        {
            if (list == null)
            {
                throw new ArgumentNullException($"{nameof(list)} must be not null");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException($"{nameof(digit)} must be positive number");
            }

            List<int> result = new List<int>();
            string strDigit = Convert.ToString(digit);

            foreach (var item in list)
            {
                string str = Convert.ToString(item);
                if (str.Contains(strDigit))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
