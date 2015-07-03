using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Inf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int group_id = int.Parse(textBox3.Text);
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                group_id += 1;
                listBox1.Items.Add(group_id.ToString());
                listBox1.Update();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string url = @"https://api.vk.com/method/groups.getById?group_id=" + listBox1.Items[i].ToString() + "&fields=screen_name";
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string outer = sr.ReadToEnd();
                outer = outer.Replace("[", "");
                outer = outer.Replace("]", "");
                var json2 = JObject.Parse(outer);
               if (json2["response"]["is_closed"].ToString() == "0")
                {
                    string url1 = @"https://api.vk.com/method/groups.getMembers?group_id=" + listBox1.Items[i].ToString() + "&count=1";
                    req = WebRequest.Create(url1);
                     resp = req.GetResponse();
                    stream = resp.GetResponseStream();
                     sr = new StreamReader(stream);
                   outer = sr.ReadToEnd();
                   // outer = outer.Replace("[", "");
                  //  outer = outer.Replace("]", "");
                    var json1 = JObject.Parse(outer);
                   // textBox4.AppendText(json1.ToString());
                   // textBox4.Update();
                    if (int.Parse(json1["response"]["count"].ToString()) > int.Parse(textBox4.Text))
                    {
                        listBox2.Items.Add(json2["response"]["name"].ToString() + "     vk.com/" + json2["response"]["screen_name"].ToString());
                        listBox2.Update();
                    }
                   
                }
             //  textBox1.AppendText("Ready!" + json2["response"].ToString());    
               label5.Text = i.ToString();
               label5.Update();               
            }

            textBox1.AppendText("Ready!"+"\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            using (StreamWriter sw = new StreamWriter("groups.txt"))
            {
                // Первой строкой записываем в файл число строк в нашем списке
                sw.WriteLine(listBox2.Items.Count.ToString());
                // В цикле записываем все строки в файл. 
                // Первая строка в списке имеет индекс 0
                // Count - число строк в списке
                for (int j = 0; j < listBox2.Items.Count; j++)
                    sw.WriteLine(listBox2.Items[j]);
            }
            textBox1.AppendText("Saved!" + "\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {Random r = new Random();
            for (int i = 1624; i < 1630; i++)
            {
                string token = "e95d74866c70a92feccc654efe6c28c41bdd9a4d3c76970";
                string time = DateTime.Now.ToString("HH:mm:ss");
                string url = @"https://api.vk.com/method/messages.send?user_id=240716221&&message="+time+"&attachment=wall70232735_" + i.ToString() + "&access_token=" + token;
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string outer = sr.ReadToEnd();
               // log.AppendText(outer);

                Thread.Sleep(r.Next(3000, 15000));
            }
         //   log.AppendText("Ready!");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://multi-cheats.com/members/mdgagj.1224/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://multi-cheats.com");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://multi-cheats.com/members/ogonjok.3214/");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            for (int i = 1; i < 23480;i++ )
            {
                try
                {
                    string url = "https://api.vk.com/method/groups.getMembers?group_id=70232735&offset=" + i.ToString() + "&fields=can_write_private_message&count=1";
                    WebRequest req = WebRequest.Create(url);
                    WebResponse resp = req.GetResponse();
                    Stream stream = resp.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string outer = sr.ReadToEnd();
                    outer = outer.Replace("[" + "\n" + "      ", "");
                    outer = outer.Replace("\n" + "    ]", "");
                    var json1 = JObject.Parse(outer);
                    //  if (json1["response"]["users"]["can_write_private_message"].ToString() =="1")
                    //  {
                    listBox1.Items.Add(json1["response"]["users"].ToString());
                    listBox1.Update();
                    try
                    {
                        if (listBox1.Items[i - 1].ToString().Contains("\"can_write_private_message\": 1"))
                        {
                            listBox2.Items.Add("vk.com/id" + listBox1.Items[i - 1].ToString().Remove(0, 19).Split(',')[0].ToString());
                            listBox2.Update();
                        }
                    }
                    catch (Exception l)
                    {
                        listBox2.Items.Add(l.Message);
                        listBox2.Update();
                    }
                }
                catch (Exception k)
                {
                    listBox2.Items.Add(k.Message);
                    listBox2.Update();
                }
             //   }
            }
            MessageBox.Show("Finished");
        }
    }
}
