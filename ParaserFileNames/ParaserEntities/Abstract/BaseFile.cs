using System;
using System.Collections.Generic;
using System.Linq;

namespace ParaserEntities.Abstract
{
    public abstract class BaseFile: IComparable<BaseFile>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }


        public abstract List<string> GetInformation();

        public virtual int CompareTo(BaseFile other)
        {
            var valueFromSize = new Dictionary<string, int>() {
                { "B", 1 } ,{ "KB", 2 },
                { "MB", 3 } ,{ "GB", 4 }
            };

            int value1;

            int.TryParse(string.Join("", this.Size.Where(c => char.IsDigit(c))), out value1);

            int value2;

            int.TryParse(string.Join("", other.Size.Where(c => char.IsDigit(c))), out value2);

            string type1 = new String(other.Size.Where(Char.IsLetter).ToArray()).ToUpper();

            string type2 = new String(this.Size.Where(Char.IsLetter).ToArray()).ToUpper();


            if (type1 != type2)
                return valueFromSize[type1] - valueFromSize[type2];

            else
                return value1 - value2;

        }
    }
}
