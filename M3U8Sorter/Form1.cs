using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3U8Sorter
{
    public partial class Form1 : Form
    {
        private Stream sourceFileStream;
        private Stream targetFileStream;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*.m3u8|*.m3u8";
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.targetFileStream = fd.OpenFile();
                this.textBox1.Text = fd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*.m3u8|*.m3u8";
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.sourceFileStream = fd.OpenFile();
                this.textBox2.Text = fd.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream newTargetStream = null;
            EntityCollection targetCollection = null;
            EntityCollection sourceCollection = null;
            EntityCollection newTargetCollection = null;

            if (this.targetFileStream == null)
            {
                MessageBox.Show("Target file is missing");
            }
            else if (this.sourceFileStream == null)
            {
                MessageBox.Show("Source file is missing");
            }
            else
            {
                targetCollection = new TargetReader(this.targetFileStream).Read();
                sourceCollection = new SourceReader(this.sourceFileStream).Read();
                newTargetCollection = new EntityCollection();

                foreach(Entity source in sourceCollection)
                {
                    Entity target = targetCollection.Find(x => x.Equals(source));

                    if (target != null)
                    {
                        newTargetCollection.Add(target);
                    }
                }

                SaveFileDialog fd = new SaveFileDialog();
                fd.Filter = "*.m3u8|*.m3u8";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    newTargetStream = fd.OpenFile();
                    newTargetCollection.WriteToStream(newTargetStream);
                    
                    newTargetStream.Close();

                    MessageBox.Show("Success!!");
                }
            }
        }
    }
}
