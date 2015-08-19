using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Recipe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "Рецепт|*.rcp" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var pd = new ProductData()
            {
                description = textBox1.Text,
            };

            foreach (IngrData ed in listBox1.Items)
            {
                pd.Spisok.Add(ed);
            }

            var xs = new XmlSerializer(typeof(ProductData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, pd);
            file.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new Ingredient();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Spisok);
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deletebutton.Enabled = true;
        }

        private void loadbutton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "Рецепт|*.rcp" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(ProductData));
            var file = File.OpenRead(ofd.FileName);
            ProductData pd = (ProductData)xs.Deserialize(file);
            file.Close();

            textBox1.Text = pd.description;
         
            foreach (IngrData ed in pd.Spisok)
            {
                listBox1.Items.Add(ed);
            }
        }


        public ProductData WORK()
        {
            var a = new ProductData();
            a.description = textBox1.Text;
            foreach (IngrData ed in listBox1.Items)
            {
               a.Spisok.Add(ed);
            }
            return a;
        }
    }
}
