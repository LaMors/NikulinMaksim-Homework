
using ParaserEntities.Abstract;
using System.Collections.Generic;

namespace ParaserEntities
{
    public class Movie: BaseFile
    {
        public string Resolution { get; set; }

        public string Length { get; set; }

        public override List<string> GetInformation()
        {
            return new List<string> { Name, "   Extension: " + Extension, "   Size: " + Size, "   Resolution: " + Resolution, "   Length: " + Length };
        }
    }
}
