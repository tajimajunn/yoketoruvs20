﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace yoketoruvs20
{
    public partial class Form1 : Form
    {
        enum State
        {
            None = -1,  // 無効
            Title,      // タイトル
            Game,       // ゲーム
            Gameover,   // ゲームオーバー
            Clear       // クリア
        }
        State currentState = State.None;
        State nextState = State.Title;

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nextState != State.None)
            {
                initProc();
            }
            if (is Debug)
            {
                if (GetAsyncKeyState((int)Keys.O) < 0)
                {
                    nextState = State.Gameover;
                }
                else if (GetAsyncKeyState((int)Keys.C) < 0)
                {
                    nextState = State.Clear;
                }
            }

            void initProc()
            {
                currentState = nextState;
                nextState = State.None;

                switch (currentState)
                {
                    case State.Title:
                        titleLabel.Visible = true;
                        startButton.Visible = true;
                        copyrightLabel.Visible = true;
                        hiLabel.Visible = true;
                        gameOverLabel.Visible = false;
                        titleButton.Visible = false;
                        clearLabel.Visible = false;
                        break;

                    case State.Game:
                        titleLabel.Visible = false;
                        startButton.Visible = false;
                        copyrightLabel.Visible = false;
                        hiLabel.Visible = false;
                        break;
                    case State.Gameover:
                        gameOverLabel.Visible = true;
                        titleButton.Visible = true;
                        break;
                    case State.Clear:
                        clearLabel.Visible = true;
                        hiLabel.Visible = true;
                        titleButton.Visible = true;
                        break;
                }
            }
            
        }
    }
}
