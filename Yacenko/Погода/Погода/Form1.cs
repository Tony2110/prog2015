using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Xml.Serialization;


namespace Погода
{
    public partial class Form1 : Form
    {
        public List<City> CL { get; set; }
        public System.Speech.Synthesis.SpeechSynthesizer Voice { get; set; }
        public class Weather
        {
            public string temp { get; set; }
            public string Os { get; set; }
            public string pressure { get; set; }
            public string humidity { get; set; }
            public string call { get; set; }
            public string speed { get; set; }
            public string wind { get; set; }

            public override string ToString()
            {
                return string.Format("Погода в {4}. Температура воздуха {0} цельсия,ветер {5} {6} метра в секунду, атмосферное давление {1} миллиметров ртутного столба. Влажность {3}. На улице {2}.", temp, pressure, Os, humidity, call, wind, speed);
            }
        }
        public Weather W { get; set; }
        public Form1()
        {
            CL = new List<City>();
            var converter = new XmlSerializer(typeof(List<City>));
            var file = File.OpenText(".\\Cityes");
            CL = (List<City>)converter.Deserialize(file);
            file.Close();
            W = new Weather();
            button1 = new Button();
            InitializeComponent();
            Voice = new System.Speech.Synthesis.SpeechSynthesizer();
            this.Voice.SpeakCompleted += new System.EventHandler<System.Speech.Synthesis.SpeakCompletedEventArgs>(Comp);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (W.temp != null)
            {
                button1.Enabled = false;
                Voice.SpeakAsync(W.ToString());
            }
            else
            {
                System.Console.Beep();
                Voice.SpeakAsync("Отсутствуют данные для озвучивания!");
            }
            
        }
        private void Comp(object sender, System.EventArgs e)
        {
            button1.Enabled = true;
        }
        private void Speak()
        {
            bool e = button1.Enabled;
            button1.Enabled = false;
            W = new Weather();
            HttpWebRequest WR;
            HttpWebResponse WResp;
            StreamReader SR;
            try
            {
                WR = (HttpWebRequest)WebRequest.Create("http://export.yandex.ru/weather-ng/forecasts/" + CL[listBox1.SelectedIndex].ID + ".xml");
                WResp = (HttpWebResponse)WR.GetResponse();
                SR = new StreamReader(WResp.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            }
            catch
            {
                System.Console.Beep();
                System.Console.Beep();
                System.Console.Beep();
                Voice.SpeakAsync("Произошла ошибка при получении данных!");
                return;
            }
            
            var S = SR.ReadToEnd();
            SR.Close();
            W.call = CL[listBox1.SelectedIndex].Call;
            try
            {
                W.temp = Regex.Split(S, "(?:.*)<temperature color=\"(?:.*)\" plate=\"(?:.*)\">(.*)</temperature>(?:.*)")[1];
                W.Os = Regex.Split(S, "(?:.*)<weather_type>(.*)</weather_type>(?:.*)")[1];
                W.pressure = Regex.Split(S, "(?:.*)<pressure units=\"(?:.*)\">(.*)</pressure>(?:.*)")[1];
                W.humidity = Regex.Split(S, "(?:.*)<humidity>(.*)</humidity>(?:.*)")[1];
                var stmp = Regex.Split(S, "(?:.*)<wind_direction>(.*)</wind_direction>(?:.*)")[1];
                switch (stmp)
                {
                    case "w": { W.wind = "западный"; } break;
                    case "n": { W.wind = "северный"; }; break;
                    case "s": { W.wind = "южный"; }; break;
                    case "e": { W.wind = "восточный"; }; break;
                    case "sw": { W.wind = "юго-западный"; }; break;
                    case "ws": { W.wind = "юго-западный"; }; break;
                    case "nw": { W.wind = "северо-западный"; }; break;
                    case "wn": { W.wind = "северо-западный"; }; break;
                    case "se": { W.wind = "юго-восточный"; }; break;
                    case "es": { W.wind = "юго-восточный"; }; break;
                    case "en": { W.wind = "северо-восточный"; }; break;
                    case "ne": { W.wind = "северо-восточный"; }; break;
                }
                W.speed = Regex.Split(S, "(?:.*)<wind_speed>(.*)</wind_speed>(?:.*)")[1];
            }
            catch
            {
                System.Console.Beep();
                System.Console.Beep();
                Voice.SpeakAsync("Произошла ошибка при переводе данных!");
                return;
            }
            W.temp += '°';
            W.humidity += '%';
            Voice.SpeakAsync(W.ToString());
        }//Обновление и произношение
        private void button2_Click(object sender, EventArgs e)
        {
            Speak();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in CL)
            {
                listBox1.Items.Add(item);
            }
            listBox1.SelectedIndex = 0;
            button1.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var AddForm = new AddForm();
            AddForm.ShowDialog();
            if (AddForm.DialogResult != DialogResult.OK)
                return;
            CL.Add(new City() { Name = AddForm.NameBox.Text, Call = AddForm.callBox.Text, ID = AddForm.IDBox.Text });
            listBox1.Items.Add(new City() { Name = AddForm.NameBox.Text, Call = AddForm.callBox.Text, ID = AddForm.IDBox.Text });
            var file = File.Open(".\\Cityes", FileMode.Truncate, FileAccess.Write, FileShare.None);
            var converter = new XmlSerializer(typeof(List<City>));
            converter.Serialize(file, CL);
            file.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 1)
            {
                CL.Remove(CL[listBox1.SelectedIndex]);
                listBox1.Items.Clear();
                foreach (var item in CL)
                {
                    listBox1.Items.Add(item);
                }
                var file = File.Open(".\\Cityes", FileMode.Truncate, FileAccess.Write, FileShare.None);
                var converter = new XmlSerializer(typeof(List<City>));
                converter.Serialize(file, CL);
                file.Close();
		listBox1.SelectedIndex = 0;
            }
        }
    }
}