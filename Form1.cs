using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        AntiGravityPoint point3;
        DeathGravityPoint point4;
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
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            emitters.Add(this.emitter);

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };
            point3 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 - 200,
                Y = picDisplay.Height / 2,
            };
            point4 = new DeathGravityPoint
            {
                X = picDisplay.Width / 2 + 200,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            emitter.impactPoints.Add(point3);
            emitter.impactPoints.Add(point4);

            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = picDisplay.Width / 2 + 100,
            //    Y = picDisplay.Height / 2,
            //});

            //// добавил второй гравитон
            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = picDisplay.Width / 2 - 100,
            //    Y = picDisplay.Height / 2,
            //});
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
            point2.X = e.X;
            point2.Y = e.Y;
        }
        private void tbDirection_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton1.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }
        
        
        private void tbGraviton3_Scroll_1(object sender, EventArgs e)
        {
            point3.Power = tbGraviton3.Value;
        }

        private void tbGraviton4_Scroll_1(object sender, EventArgs e)
        {
            point4.Power = tbGraviton4.Value;
        }
    }
}