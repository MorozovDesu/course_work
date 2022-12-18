using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static course_work.IImpactPoint;
using static course_work.Particle;


namespace course_work
{
    public partial class Form1 : Form
    {

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера
        GravityPoint point1; // добавил поле под первую точку
        GravityPoint point2; // добавил поле под вторую точку
        GravityPoint point5; // добавил поле под вторую точку
        GravityPoint point6;
        GravityPoint point11;// добавил поле под вторую точку
        AntiGravityPoint point3;
        AntiGravityPoint point7;
        AntiGravityPoint point8;
        AntiGravityPoint point9;
        AntiGravityPoint point10;


        DeathGravityPoint point4;
        List<DeathGravityPoint> objects = new List<DeathGravityPoint>();


        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 360,
                SpeedMin = 3,
                SpeedMax = 5,
                ColorFrom = Color.HotPink,
                ColorTo = Color.FromArgb(0, Color.White),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height-100,
            };
            emitters.Add(this.emitter);
            point3 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 + 250,
                Y = picDisplay.Height - 50,
                NewFromColor = Color.FromArgb(255, Color.Azure),
                NewToColor = Color.FromArgb(255, Color.Azure)
            };
            point7 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 - 275,
                Y = picDisplay.Height - 50,
                NewFromColor = Color.FromArgb(255, Color.White),
                NewToColor = Color.FromArgb(255, Color.Gray)
            };
            point8 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 - 150,
                Y = picDisplay.Height - 50,
                NewFromColor = Color.FromArgb(255, Color.Cornsilk),
                NewToColor = Color.FromArgb(255, Color.Cornsilk)
            };
            point9 = new AntiGravityPoint
            {
                X = picDisplay.Width - 200,
                Y = picDisplay.Height - 50,
                NewFromColor = Color.FromArgb(255, Color.Crimson),
                NewToColor = Color.FromArgb(255, Color.Crimson)
            };
            point10 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height - 50,
                NewFromColor = Color.FromArgb(255, Color.DarkSeaGreen),
                NewToColor = Color.FromArgb(255, Color.DarkSeaGreen)
            };
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 250,
                Y = picDisplay.Height - 250,
                NewFromColor = Color.FromArgb(255, Color.Green),
                NewToColor = Color.FromArgb(255, Color.GreenYellow)
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 275,
                Y = picDisplay.Height -250,
                NewFromColor = Color.FromArgb(255, Color.CadetBlue),
                NewToColor = Color.FromArgb(255, Color.Blue)
            };
            point5 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 150,
                Y = picDisplay.Height - 250,
                NewFromColor = Color.FromArgb(255, Color.Red),
                NewToColor = Color.FromArgb(255, Color.DarkRed)
            };
            point6 = new GravityPoint
            {
                X = picDisplay.Width  - 200,
                Y = picDisplay.Height - 250,
                NewFromColor = Color.FromArgb(255, Color.Gainsboro),
                NewToColor = Color.FromArgb(255, Color.LightSlateGray)
            };
            point11 = new GravityPoint
            {
                X = picDisplay.Width  /2,
                Y = picDisplay.Height - 250,
                NewFromColor = Color.FromArgb(255, Color.Indigo),
                NewToColor = Color.FromArgb(255, Color.MediumVioletRed)
            };

           
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            emitter.impactPoints.Add(point3);// анти
            emitter.impactPoints.Add(point5);
            emitter.impactPoints.Add(point6);
            emitter.impactPoints.Add(point7);//анти
            emitter.impactPoints.Add(point8);//анти
            emitter.impactPoints.Add(point9);//анти
            emitter.impactPoints.Add(point10);//анти
            emitter.impactPoints.Add(point11);


        }

        // функция рендеринга

        private void timer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); 
                emitter.Render(g);
            }

            label1.Text = string.Empty;//добавил вывод кол-ва частиц
            label1.BackColor= Color.Black;
            label1.ForeColor = Color.White;
            label1.Text = string.Format("Количество частиц: ") + emitter.Score ;

            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // это не трогаем
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }
        }
        private void tbDirection_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)//скорость частиц
        {
            emitter.Spreading = tbGraviton1.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)//кол-во частиц вза тик
        {
            emitter.ParticlesPerTick = tbGraviton2.Value;
        }


        private void tbGraviton3_Scroll_1(object sender, EventArgs e)//Скорость частиц
        {
           emitter.SpeedMax = tbGraviton3.Value+3;
            if(emitter.SpeedMax <= emitter.SpeedMin)
            {
                emitter.SpeedMax +=10;
            }
        }

        private void tbGraviton4_Scroll_1(object sender, EventArgs e)//Размер шара
        {
            if (point4 != null)
            {
                point4.Power = tbGraviton4.Value;
            }


        }


        private void picDisplay_MouseClick(object sender, MouseEventArgs e)// передаю новому шару аргументы
        {
            if (e.Button == MouseButtons.Left)
            {
                point4 = new DeathGravityPoint();//передвю новому эммитору поля
                objects.Add(point4);
                point4.X = e.X;
                point4.Y = e.Y;
                point4.Power = 100;
                point4.Counter = 0;
                point4.Score = 0;
                point4.Red = 0;
                emitter.impactPoints.Add(point4);
            }
            
            if (e.Button == MouseButtons.Right)
            {
                emitter.X = e.X;
                emitter.Y = e.Y;
            }
        }
        private void picDisplay_Paint(object sender, PaintEventArgs e)// для создания шаров
        {
            var g = e.Graphics;
            foreach(var obj in objects) 
            {
                obj.Render(g);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            emitter.SpeedVector =(checkBox1.Checked);
        }

        
    }
}