using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretMail
{
    public partial class SecretMailForm : Form
    {
        public SecretMailForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                String hostname = HostnameTextBox.Text;

                //using (TcpClient client = new TcpClient(new IPEndPoint(IPAddress.Any, 110)))
                using (TcpClient client = new TcpClient(hostname, 110))
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    //client.Connect(hostname, 110);   
                    int data = client.Available;
                    MessageBox.Show(reader.ReadLine());
                    
                    while (client.Connected)
                    {
                        while(reader.Read() > 0)
                        {
                            writer.WriteLine("USER " + UsernameTextBox.Text);
                            writer.Flush();
                            writer.WriteLine("PASS " + PasswordTextBox.Text);
                            writer.Flush();
                            MessageBox.Show(reader.Read().ToString());// Readed Data Size
                            MessageBox.Show(reader.ReadLine());
                            MessageBox.Show(data.ToString());
                            MessageBox.Show(reader.ReadLine());
                            MessageBox.Show(data.ToString());
                        }
                        
                        //writer.WriteLine("LIST");
                        //writer.Flush();
                        //MessageBox.Show("Connected Successfully.");
                        using (EmailsForm emailsForm = new EmailsForm())
                        {
                            //emailsForm.ShowDialog();
                        }
                    }
                    //MessageBox.Show(client.Connected.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
