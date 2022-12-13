using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
        GravityPoint point6; // добавил поле под вторую точку
        AntiGravityPoint point3;


        DeathGravityPoint point4;
        List<DeathGravityPoint> objects = new List<DeathGravityPoint>();


        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.White),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 4,
            };
            emitters.Add(this.emitter);

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 250,
                Y = picDisplay.Height - 100,
                NewFromColor = Color.FromArgb(255, Color.Green),
                NewToColor = Color.FromArgb(255, Color.GreenYellow)
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 275,
                Y = picDisplay.Height -100,
                NewFromColor = Color.FromArgb(255, Color.CadetBlue),
                NewToColor = Color.FromArgb(255, Color.Blue)
            };
            point5 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 200,
                Y = picDisplay.Height - 100,
                NewFromColor = Color.FromArgb(255, Color.Red),
                NewToColor = Color.FromArgb(255, Color.Snow)
            };
            point6 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 275,
                Y = picDisplay.Height - 100,
                NewFromColor = Color.FromArgb(255, Color.CadetBlue),
                NewToColor = Color.FromArgb(255, Color.Blue)
            };
            point3 = new AntiGravityPoint
            {
                X = picDisplay.Width/2,
                Y = picDisplay.Height -100,
                NewFromColor = Color.FromArgb(255, Color.White),
                NewToColor = Color.FromArgb(255, Color.Gray)
            };

            //point4 = new DeathGravityPoint
            //{
            //    X = picDisplay.Width / 2 + 100,
            //    Y = picDisplay.Height / 3,
            //};
            emitter.impactPoints.Add(point6);
            emitter.impactPoints.Add(point5);
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            emitter.impactPoints.Add(point3);


        }

        // функция рендеринга

        private void timer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // А ЕЩЕ ЧЕРНЫЙ ФОН СДЕЛАЮ
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

            // а тут передаем положение мыши, в положение гравитона
            //point2.X = e.X;
            //point2.Y = e.Y;
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
            
            point4.Power = tbGraviton4.Value;
            
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

        
    }
}