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
                        MessageBox.Show("Файл не существует.");
                        return;
                    }

                    string fileContent = File.ReadAllText(filePath);

                    ParseFB2File(fileContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }

        private void ParseFB2File(string fileContent)
        {
            try
            {
                // Создаем XmlDocument и загружаем файл
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(fileContent);

                // Получаем все параграфы текста из файла FB2
                XmlNodeList paragraphs = doc.GetElementsByTagName("p");

                // Очищаем ListBox перед добавлением новых элементов
                lstBox.Items.Clear();

                // Добавляем каждый параграф в ListBox
                foreach (XmlNode paragraph in paragraphs)
                {
                    lstBox.Items.Add(paragraph.InnerText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
            }
        }

    }
}
