﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Common;

namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
            
        }


       

     
        private void Bienvenida_Load(object sender, EventArgs e)
        {
            labelUser.Text = UserCache.nombre + ", " + UserCache.apellido;
            this.Opacity = 0.0;
            //Inicializamos estas propiedades de la barra de progreso, mediante codigo.(Opcional)
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            //Iniciamos el temporizador 1.
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //Aumentamos la opacidad del formulario en 0.05.
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 4;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }
    }
}