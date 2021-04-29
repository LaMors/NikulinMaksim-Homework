
using ParaserEntities.Abstract;
using System.Collections.Generic;

namespace ParaserEntities
{
    public class Text : BaseFile
    {
        public string Content { get; set; }

        public override List<string> GetInformation()
        {
            return new List<string> { Name, "   Extension: " + Extension, "   Size: " + Size, "   Content: " + Content };
        }
    }
}
