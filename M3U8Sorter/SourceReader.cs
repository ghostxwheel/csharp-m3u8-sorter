using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Sorter
{
    class SourceReader
    {
        private Stream stream;

        public SourceReader(Stream stream)
        {
            this.stream = stream;
        }

        public EntityCollection Read()
        {
            string strProperties, strGroup, strUrl, strName;
            int nIndex, nCurrIndex;
            bool bFirst = true;
            EntityCollection arrEntities = new EntityCollection();

            StreamReader sr = new StreamReader(this.stream);

            nCurrIndex = 0;

            while (!sr.EndOfStream)
            {
                if (bFirst)
                {
                    bFirst = false;

                    sr.ReadLine();
                }

                strProperties = sr.ReadLine();
                strGroup = sr.ReadLine();
                strUrl = sr.ReadLine();

                strName = strProperties.Split(',')[1];
                nIndex = nCurrIndex;

                arrEntities.Add(new Entity(strName, nIndex, strUrl, new string[] { strProperties, strGroup, strUrl }));

                nCurrIndex++;
            }

            sr.Close();

            return arrEntities;
        }
    }
}
