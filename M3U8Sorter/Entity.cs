using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Sorter
{
    class Entity : IEquatable<Entity>
    {
        private int nIndex;
        private string strName;
        private string strUrl;
        private string[] arrData;

        public Entity(string strName, int nIndex)
        {
            this.strName = strName;
            this.nIndex = nIndex;
        }

        public Entity(string strName, int nIndex, string[] arrData) : this(strName, nIndex)
        {
            this.arrData = arrData;
        }

        public Entity(string strName, int nIndex, string strUrl, string[] arrData) : this(strName, nIndex)
        {
            this.strUrl = strUrl;
            this.arrData = arrData;
        }

        public void Render(StreamWriter sw)
        {
            foreach(var strLine in arrData)
            {
                sw.WriteLine(strLine);
            }
        }

        public bool Equals(Entity other)
        {
            if (other == null) return false;
            return this.strUrl.Equals(other.strUrl);
        }
    }
}
