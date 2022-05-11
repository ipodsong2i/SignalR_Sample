using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public HubConnection connection;
        public string ip, name;
        public Form1()
        {
            InitializeComponent();
            Form2 getInfoDlg = new Form2();
            getInfoDlg.Owner = this;
            
            if(getInfoDlg.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add("Connection Start!");
                Connection();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", name, textBox1.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void Connection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl($"http://{ip}/testhub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                // list에 message 추가
                if (this.listBox1.InvokeRequired)
                {
                    this.listBox1.Invoke((MethodInvoker)delegate
                    {
                        this.listBox1.Items.Add(user + " : " + message);
                    });
                }
            });

            try
            {
                await connection.StartAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
