using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Sorter
{
    class EntityCollection : List<Entity>
    {
        public void WriteToStream(Stream stream)
        {
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine("#EXTM3U");

            foreach(Entity entity in this)
            {
                entity.Render(sw);
            }

            sw.Flush();
            sw.Close();
        }
    }
}
