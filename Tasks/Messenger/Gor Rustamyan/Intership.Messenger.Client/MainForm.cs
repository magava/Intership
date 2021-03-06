﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intership.Messenger.Client
{
    public partial class MainForm : Form
    {
        ServerConnection _serverConnection;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            _serverConnection = login.ServerConnection;

            _serverConnection.NewUserConnected += OnNewUserConnect;
            _serverConnection.MessageReceived += OnNewMessage;
        }

        private void OnNewMessage(Message message)
        {
            this.Invoke((Action)(() =>
            {
                var clientNickName = _serverConnection.ConnectedUsers.First(x => x.UserId == message.ClientId).UserNickname;

                lbMessages.Items.Add($"{clientNickName}: {message.MessageText}");
            }));
        }

        private void OnNewUserConnect(User user)
        {
            this.Invoke((Action)(() =>
            {
                lbConnectedUsers.Items.Add(user.UserNickname);
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;
            _serverConnection.SendMessage(txtMessage.Text);

            txtMessage.Clear();

        }
    }
}
