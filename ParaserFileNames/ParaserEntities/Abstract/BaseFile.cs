using System.Collections.Generic;

namespace ParaserEntities.Abstract
{
    public abstract class BaseFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }

        public abstract List<string> GetInformation();
    }
}
