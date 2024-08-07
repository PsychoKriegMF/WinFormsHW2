using System.Windows.Forms;
using System.Xml;

namespace WinFormsHW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "FB2 Files (*.fb2)|*.fb2|All Files (*.*)|*.*";

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                try
                {                    
                    string filePath = ofg.FileName;

                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("���� �� ����������.");
                        return;
                    }

                    string fileContent = File.ReadAllText(filePath);

                    ParseFB2File(fileContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� ������ �����: " + ex.Message);
                }
            }
        }

        private void ParseFB2File(string fileContent)
        {
            try
            {
                // ������� XmlDocument � ��������� ����
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(fileContent);

                // �������� ��� ��������� ������ �� ����� FB2
                XmlNodeList paragraphs = doc.GetElementsByTagName("p");

                // ������� ListBox ����� ����������� ����� ���������
                lstBox.Items.Clear();

                // ��������� ������ �������� � ListBox
                foreach (XmlNode paragraph in paragraphs)
                {
                    lstBox.Items.Add(paragraph.InnerText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������ �����: " + ex.Message);
            }
        }

    }
}
