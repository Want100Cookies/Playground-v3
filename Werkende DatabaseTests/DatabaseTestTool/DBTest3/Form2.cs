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
using System.Xml;

namespace DBTest3
{
    public partial class Form2 : Form
    {
        private Dictionary<string, string> databaseConnections;
        private string xmlConfigPath = "";
        private string providerName;

        public Form2()
        {
            InitializeComponent();
            setUpTapControl();

            var task = Task.Factory.StartNew(() =>
            {
                using (FileStream file = File.Open("DBTest3.exe", FileMode.Open))
                {
                    xmlConfigPath = file.Name;

                }


            });


        }

        private void setUpTapControl()
        {
            tabControl1.Dock = DockStyle.Fill;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string xmlFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><configuration><configSections></configSections><connectionStrings>";

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                xmlFile += string.Format("\n<add name=\"{0}\" connectionString=\"", tabControl1.TabPages[i].Name);

                List<Label> labels = new List<Label>();
                List<TextBox> textboxes = new List<TextBox>();

                foreach (var control in tabControl1.TabPages[i].Controls)
                {
                    if (control is Label)
                    {
                        labels.Add(control as Label);
                    }
                    if (control is TextBox)
                    {
                        textboxes.Add(control as TextBox);
                    }
                }

                for (int y = 0; y < labels.Count; y++)
                {
                    string item = "";
                    item += labels[y].Text + "=" + textboxes[y].Text + ";";
                    xmlFile += string.Format("{0}", item);
                }

                xmlFile += string.Format("\" providerName=\"{0}\" />", providerName);
            }

            xmlFile += "</connectionStrings><startup><supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5\" /></startup></configuration>";

            using (TextWriter writer = new StreamWriter(xmlConfigPath))
            {
                writer.WriteLine(xmlFile);
            }

            MessageBox.Show("Config file successfully saved.");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Clear();

            //xmlConfigPath = Environment.CurrentDirectory + "/DBTest3.exe";

            //openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Title = "Search for the configuration file";
            //openFileDialog1.Filter = "xml config files (*.config)|*.config";
            //DialogResult dialogResult = openFileDialog1.ShowDialog();

            //if (dialogResult == System.Windows.Forms.DialogResult.OK)
            //{
            //    databaseConnections = new Dictionary<string, string>();

            //    xmlConfigPath = Environment.CurrentDirectory + "/DBTest3.exe";

            var doc = new XmlDocument();
            doc.Load(xmlConfigPath);

            foreach (XmlNode node in doc.SelectNodes("//add"))
            {
                string connectionName = node.Attributes["name"].Value;
                string connectionString = node.Attributes["connectionString"].Value;
                providerName = node.Attributes["providerName"].Value;

                if (!databaseConnections.ContainsKey(connectionName))
                {
                    databaseConnections.Add(connectionName, connectionString);
                }

                TabPage tabPage = new TabPage();
                tabPage.Name = connectionName;
                tabPage.Text = connectionName;

                string[] connectionStringItems = connectionString.Split(';');

                int currentX = 120;
                int currentY = 0;

                foreach (string item in connectionStringItems)
                {
                    string key = "";
                    string value = "";

                    try
                    {
                        key = item.Split('=')[0];
                        value = item.Split('=')[1];
                    }
                    catch
                    {
                        key = "";
                        value = "";
                    }

                    if (key.Length > 0)
                    {
                        Label label1 = new Label();
                        label1.Text = key;
                        label1.Location = new Point(0, currentY);
                        tabPage.Controls.Add(label1);
                    }

                    if (value.Length > 0)
                    {
                        TextBox textBox1 = new TextBox();
                        Size size = TextRenderer.MeasureText(item, textBox1.Font);
                        textBox1.Width = size.Width;
                        textBox1.Text = value;
                        textBox1.Location = new Point(currentX, currentY);
                        tabPage.Controls.Add(textBox1);
                    }

                    currentX += 0;
                    currentY += 30;

                }

                tabControl1.Controls.Add(tabPage);
            }
        }
    }
}
