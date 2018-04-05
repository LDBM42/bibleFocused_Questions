﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Media;

using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class P_focusedBibles : Form
    {
        public P_focusedBibles()
        {
            InitializeComponent();
        }

        SoundPlayer sonido;
        int[] noRepetir;
        int numeroPrueba;
        int i = 0;
        int countUp = 0;
        int countDownTimer = 2;
        int score_1 = 0;
        int lifes_1 = 3;
        int score_2 = 0;
        int lifes_2 = 3;
        int turno = 1;
        int enumerate = 1; // para ponerle número a las preguntas
        string[] comodin50_1 = new string[] { "0", "+1", "+2", "+3" };
        string[] comodin50_2 = new string[] { "0", "+1", "+2", "+3" };
        char[] desaparecer50 = new char[] { 'a', 'b', 'c', 'd' };
        int countDownComodin_1 = 2;
        int countDownComodin_2 = 2;
        E_focusedBible objEntidad = new E_focusedBible();
        N_focusedBible objNego = new N_focusedBible();

        private void P_focusedBibles_Load(object sender, EventArgs e)
        {
            noRepetir = new int[objNego.N_NumFilas()]; // el tamaño es el tamaño del numero de filas
            listarFocusedBible(objEntidad);
            
            focoRbtn();
        }

        void focoRbtn() //para tener el foco en las respuestas
        {
            if (rbtn_a.Visible == true)
            {
                rbtn_a.Focus();
                rbtn_a.Checked = false;
            }
            else
                if (rbtn_b.Visible == true)
            {
                rbtn_b.Focus();
                rbtn_b.Checked = false;
            }
            else
                if (rbtn_c.Visible == true)
            {
                rbtn_c.Focus();
                rbtn_c.Checked = false;
            }
            else
                if (rbtn_d.Visible == true)
            {
                rbtn_d.Focus();
                rbtn_d.Checked = false;
            }
        }

        void listarFocusedBible(E_focusedBible preg)
        {
            randomQuestions();

            DataTable dt = objNego.N_listado(preg);
            lab_Pregunta.Text = Convert.ToString(enumerate) + ". " + dt.Rows[0]["preg"].ToString();
            rbtn_a.Text = "a)   " + dt.Rows[0]["a"].ToString();
            rbtn_b.Text = "b)   " + dt.Rows[0]["b"].ToString();
            rbtn_c.Text = "c)   " + dt.Rows[0]["c"].ToString();
            rbtn_d.Text = "d)   " + dt.Rows[0]["d"].ToString();
            preg.resp = Convert.ToChar(dt.Rows[0]["resp"].ToString());

            enumerate++;
        }

        void randomQuestions()
        {
            Random random = new Random();

            if (countUp == noRepetir.Length)
            {
                DialogResult respuesta = MessageBox.Show("The Game has Finished!\nDo you want to Play Again!", "Game Over", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    i = 0;
                    countUp = 0;
                    Array.Clear(noRepetir, 0, noRepetir.Length); // vaciar arreglo
                }
                else
                {
                    Application.Exit();
                }
            }

            while (true)
            {
                // numeros aleatorios desde el 1 hasta el tamaño del arreglo
                numeroPrueba = random.Next(1, noRepetir.Length + 1);
                // si existe el código dentro del arreglo se agrega al arreglo, si no existe se crea el random
                if (Array.Exists(noRepetir, codPreg => codPreg == numeroPrueba))
                {
                    if (countUp == noRepetir.Length)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else //si el código no eiste en el arreglo
                {
                    noRepetir[i] = numeroPrueba; //agregar código al arreglo para que nunca se repitan
                    objEntidad.codPreg = numeroPrueba; // numeros aleatorios del 1 al numero de filas
                    i++;
                    countUp++;
                    break;
                }
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (rbtn_a.Checked == true)
            {
                if (objEntidad.resp == 'a')
                {
                    correctAnswer();
                    correctAnswerSound();
                    lab_Anuncios.Text = "Correct Answer";
                    cambioDeTurno(turno, true);
                }
                else
                {
                    correctAnswer();
                    reproducirSonido("retro-lose.wav", false);
                    lab_Anuncios.Text = "Wrong Answer";
                    cambioDeTurno(turno, false);
                }
            } else
                if (rbtn_b.Checked == true)
            {
                if (objEntidad.resp == 'b')
                {
                    correctAnswer();
                    correctAnswerSound();
                    lab_Anuncios.Text = "Correct Answer";
                    cambioDeTurno(turno, true);
                }
                else
                {
                    correctAnswer();
                    reproducirSonido("retro-lose.wav", false);
                    lab_Anuncios.Text = "Wrong Answer";
                    cambioDeTurno(turno, false);
                }
            }
            else
                if (rbtn_c.Checked == true)
            {
                if (objEntidad.resp == 'c')
                {
                    correctAnswer();
                    correctAnswerSound();
                    lab_Anuncios.Text = "Correct Answer";
                    cambioDeTurno(turno, true);
                }
                else
                {
                    correctAnswer();
                    reproducirSonido("retro-lose.wav", false);
                    lab_Anuncios.Text = "Wrong Answer";
                    cambioDeTurno(turno, false);
                }
            }
            else
                if (rbtn_d.Checked == true)
            {
                if (objEntidad.resp == 'd')
                {
                    correctAnswer();
                    correctAnswerSound();
                    lab_Anuncios.Text = "Correct Answer";
                    cambioDeTurno(turno, true);
                }
                else
                {
                    correctAnswer();
                    reproducirSonido("retro-lose.wav", false);
                    lab_Anuncios.Text = "Wrong Answer";
                    cambioDeTurno(turno, false);
                }
            }

            // Cambio de Jugador
            if (turno == 1)
            {
                countDown.Start();
                activarComidin(2);
                PlayerFocus(2);
                turno = 2; //Player 2
                focoRbtn();
            }
            else
            {
                countDown.Start();
                activarComidin(1);
                PlayerFocus(1);
                turno = 1; //Player 1
                focoRbtn();
            }

            listarFocusedBible(objEntidad);
            uncheckRbtn_and_makeVisible();
            answerOriginalSizeandColor();
        }

        private void reproducirSonido(string nombreArchivo, bool loop)
        {
            if (sonido != null)
            {
                sonido.Stop();
            }
            //SystemSounds.Hand.Play(); // Sonido de windows
            try
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\son\" + nombreArchivo);
                if (loop == true)
                {
                    sonido.PlayLooping();
                }
                else
                {
                    sonido.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        void correctAnswerSound()
        {
            reproducirSonido("correctAnswer3.wav", false);
            Thread.Sleep(400);
            reproducirSonido("cheering-and-clapping2.wav", false);
        }

        void PlayerFocus(int turno)
        {
            if (turno == 1)
            {
                //para poder cambiar el tamaño de la fuente hay que instanciarla y pasarle los parametros siguientes.
                lab_Player1.Font = new Font(lab_Player1.Font.Name, 20, lab_Player1.Font.Style, lab_Player1.Font.Unit);
                //para cambiar el color a gris
                lab_Player1.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Player2.Font = new Font(lab_Player2.Font.Name, 10, lab_Player2.Font.Style, lab_Player2.Font.Unit);
                //para cambiar el color a orange
                lab_Player2.ForeColor = Color.FromArgb(237, 237, 237);


                cambiarColoryJugador(turno);

            }
            else // si el turno es 2
            {
                lab_Player2.Font = new Font(lab_Player2.Font.Name, 20, lab_Player2.Font.Style, lab_Player2.Font.Unit);
                lab_Player2.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Player1.Font = new Font(lab_Player1.Font.Name, 10, lab_Player1.Font.Style, lab_Player1.Font.Unit);
                lab_Player1.ForeColor = Color.FromArgb(237, 237, 237);

                cambiarColoryJugador(turno);
            }
        }

        void cambiarColoryJugador(int turno)
        {
            if (turno == 1)
            {
                lab_Lifes.ForeColor = Color.FromArgb(135, 135, 135);
                lab_LifesNum.ForeColor = Color.Brown;
                lab_Score.ForeColor = Color.FromArgb(135, 135, 135);
                lab_ScoreNum.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Lifes2.ForeColor = Color.FromArgb(237, 237, 237);
                lab_LifesNum2.ForeColor = Color.FromArgb(237, 237, 237);
                lab_Score2.ForeColor = Color.FromArgb(237, 237, 237);
                lab_ScoreNum2.ForeColor = Color.FromArgb(237, 237, 237);
            }
            else // si el turno es 2
            {
                lab_Lifes2.ForeColor = Color.FromArgb(135, 135, 135);
                lab_LifesNum2.ForeColor = Color.Brown;
                lab_Score2.ForeColor = Color.FromArgb(135, 135, 135);
                lab_ScoreNum2.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Lifes.ForeColor = Color.FromArgb(237, 237, 237);
                lab_LifesNum.ForeColor = Color.FromArgb(237, 237, 237);
                lab_Score.ForeColor = Color.FromArgb(237, 237, 237);
                lab_ScoreNum.ForeColor = Color.FromArgb(237, 237, 237);
            }
        }

        void cambioDeTurno(int turno, bool answerCorrect) // si el turno es uno y la respuesta fue correcta
        {
            if (turno == 1)
            {
                if (answerCorrect == true)
                {
                    score_1++;
                    lab_ScoreNum.Text = Convert.ToString(score_1);
                }
                else
                {
                    lifes_1--;
                    lab_LifesNum.Text = Convert.ToString(lifes_1);
                    perder_Ganar();
                }
            }
            else
            {
                if (answerCorrect == true)
                {
                    score_2++;
                    lab_ScoreNum2.Text = Convert.ToString(score_2);
                }
                else
                {
                    lifes_2--;
                    lab_LifesNum2.Text = Convert.ToString(lifes_2);
                    perder_Ganar();
                }
            }
        }

        void perder_Ganar()
        {
            //condicion para perder
            if (lifes_1 == 0 || lifes_2 == 0)
            {
                //condicion para saber quien perdió
                if (turno == 1)
                {
                    MessageBox.Show(lab_Player1.Text + " Lose!\n\n" + lab_Player2.Text + " Wins\nLifes: " + lifes_2 + "\nScore: " + score_2);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(lab_Player2.Text + " Lose!\n\n" + lab_Player1.Text + " Wins\nLifes: " + lifes_1 + "\nScore: " + score_1);
                    Application.Exit();
                }
            }
        }

        void uncheckRbtn_and_makeVisible()
        {
            rbtn_a.Checked = false;
            rbtn_b.Checked = false;
            rbtn_c.Checked = false;
            rbtn_d.Checked = false;

            rbtn_a.Visible = true;
            rbtn_a.Enabled = true;
            rbtn_b.Visible = true;
            rbtn_b.Enabled = true;
            rbtn_c.Visible = true;
            rbtn_c.Enabled = true;
            rbtn_d.Visible = true;
        }

        void correctAnswer()
        {
            if ('a' == objEntidad.resp)
            {
                rbtn_a.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_b.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_c.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_d.ForeColor = Color.FromArgb(225, 225, 225);
            }
            else
                if ('b' == objEntidad.resp)
            {
                rbtn_b.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_a.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_c.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_d.ForeColor = Color.FromArgb(225, 225, 225);
            }
            else
                if ('c' == objEntidad.resp)
            {
                rbtn_c.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_a.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_b.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_d.ForeColor = Color.FromArgb(225, 225, 225);
            }
            else
                if ('d' == objEntidad.resp)
            {
                rbtn_d.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_a.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_c.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_b.ForeColor = Color.FromArgb(225, 225, 225);
            }
        }

        void answerOriginalSizeandColor()
        {
            rbtn_a.ForeColor = Color.FromArgb(135, 135, 135);
            rbtn_b.ForeColor = Color.FromArgb(135, 135, 135);
            rbtn_c.ForeColor = Color.FromArgb(135, 135, 135);
            rbtn_d.ForeColor = Color.FromArgb(135, 135, 135);
        }



        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void pbx_50_MouseEnter(object sender, EventArgs e)
        {
            pbx_50_1.Image = Properties.Resources._50_percent_MouseOn;
        }

        private void pbx_50_MouseLeave(object sender, EventArgs e)
        {
            pbx_50_1.Image = Properties.Resources._50_percent;
        }

        private void pbx_50_Click(object sender, EventArgs e)
        {
            if (lab_50_1.Text != "0")
            {

                lab_50_1.Text = comodin50_1[countDownComodin_1];
                countDownComodin_1--;
                random50();
                focoRbtn();
            }
        }



        private void pbx_50_2_MouseEnter(object sender, EventArgs e)
        {
            pbx_50_2.Image = Properties.Resources._50_percent_MouseOn;
        }

        private void pbx_50_2_MouseLeave(object sender, EventArgs e)
        {
            pbx_50_2.Image = Properties.Resources._50_percent;
        }

        private void pbx_50_2_Click(object sender, EventArgs e)
        {
            if (lab_50_2.Text != "0")
            {
                lab_50_2.Text = comodin50_2[countDownComodin_2];
                countDownComodin_2--;
                random50();
                focoRbtn();
            }
        }


        void activarComidin(int turno)
        {
            if (turno == 1)
            {
                pbx_50_2.Visible = false;
                lab_50_2.Visible = false;
                pbx_50_1.Visible = true;
                lab_50_1.Visible = true;
            }
            else
            {
                pbx_50_1.Visible = false;
                lab_50_1.Visible = false;
                pbx_50_2.Visible = true;
                lab_50_2.Visible = true;
            }
        }

        void random50()
        {
            Random random = new Random();
            int i = 0;
            int indice;

            while(i != 2)
            {
                indice = random.Next(0, 3);
                if (objEntidad.resp != desaparecer50[indice])
                {
                    if(desaparecer50[indice] == 'a')
                    {
                        if(rbtn_a.Visible == true) // condicion para saber si ya se ha vuelto invisible,
                                                    //para que no lo cuente denuevo
                        {
                            rbtn_a.Enabled = false;
                            rbtn_a.Visible = false;
                            i++;
                        }
                    }
                    else
                        if (desaparecer50[indice] == 'b')
                    {
                        if (rbtn_b.Visible == true)
                        {
                            rbtn_b.Enabled = false;
                            rbtn_b.Visible = false;
                            i++;
                        }
                    }
                    else
                        if (desaparecer50[indice] == 'c')
                    {
                        if (rbtn_c.Visible == true)
                        {
                            rbtn_c.Enabled = false;
                            rbtn_c.Visible = false;
                            i++;
                        }
                    }
                    else
                        if (desaparecer50[indice] == 'd')
                    {
                        if (rbtn_d.Visible == true)
                        {
                            rbtn_d.Enabled = false;
                            rbtn_d.Visible = false;
                            i++;
                        }
                    }
                }
            }
        }

        private void countDown_Tick(object sender, EventArgs e)
        {
            if(countDownTimer != 0)
            {
                countDownTimer--;
            }
            else
            {
                countDownTimer = 2;
                countDown.Stop();
                lab_Anuncios.Text = "";
            }
        }



        //eventos para seleccionar a travez del teclado
        private void rbtn_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }

        private void rbtn_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }

        private void rbtn_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }

        private void rbtn_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }

        void selectAnswer(KeyPressEventArgs e)
        {
            // 'e' almacena la tecla presionada
            if (e.KeyChar == (char)13) //si la tecla pesionada es igual a ENTER (13)
            {
                e.Handled = true; //.Handled significa que nosotros nos haremos cargo del codigo
                                  //al ser true, evita que apareca la tecla presionada
                btn_Submit.PerformClick();
            }
            else
                if (e.KeyChar == (char)49 || e.KeyChar == (char)97 || e.KeyChar == (char)65)
            {
                rbtn_a.Checked = true;
            }
            else
                if (e.KeyChar == (char)50 || e.KeyChar == (char)98 || e.KeyChar == (char)66)
            {
                rbtn_b.Checked = true;
            }
            else
                if (e.KeyChar == (char)51 || e.KeyChar == (char)99 || e.KeyChar == (char)67)
            {
                rbtn_c.Checked = true;
            }
            else
                if (e.KeyChar == (char)52 || e.KeyChar == (char)100 || e.KeyChar == (char)68)
            {
                rbtn_d.Checked = true;
            }
        }

    }
}
