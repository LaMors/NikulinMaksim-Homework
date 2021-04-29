using ParaserEntities.Abstract;
using System.Collections.Generic;

namespace ParaserEntities
{
    public class Image: BaseFile
    {
        public string Resolution { get; set; }

        public override List<string> GetInformation()
        {
            return new List<string> { Name, "   Extension: " + Extension, "   Size: " + Size, "   Resolution: " + Resolution };
        }
    }
}
