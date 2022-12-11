using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;
       
        
        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать

        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
        public class GravityPoint : IImpactPoint
        {
            public int Power = 100; // сила притяжения

            // а сюда по сути скопировали с минимальными правками то что было в UpdateState
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
            public override void Render(Graphics g)
            {
                // буду рисовать окружность с диаметром равным Power
                g.DrawEllipse(
                       new Pen(Color.Red),
                       X - Power / 2,
                       Y - Power / 2,
                       Power,
                       Power
                   );
                var stringFormat = new StringFormat(); // создаем экземпляр класса
                stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
                stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

                g.DrawString(
                    $"Я гравитон\nc силой {Power}",
                    new Font("Verdana", 10),
                    new SolidBrush(Color.White),
                    X,
                    Y,
                    stringFormat // передаем инфу о выравнивании
                );

            }
        }
        public class AntiGravityPoint : IImpactPoint
        {
            public int Power = 100; // сила отторжения
            
            // а сюда по сути скопировали с минимальными правками то что было в UpdateState
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
                particle.SpeedY -= gY * Power / r2; // и тут
            }
            public override void Render(Graphics g)
            {
                // буду рисовать окружность с диаметром равным Power
                g.DrawEllipse(
                       new Pen(Color.Red),
                       X - Power / 2,
                       Y - Power / 2,
                       Power,
                       Power
                   );
                var stringFormat = new StringFormat(); // создаем экземпляр класса
                stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
                stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

                g.DrawString(
                    $"Я антигравитон\nc силой {Power}",
                    new Font("Verdana", 10),
                    new SolidBrush(Color.White),
                    X,
                    Y,
                    stringFormat // передаем инфу о выравнивании
                );
                
            }
            }
        public class DeathGravityPoint : IImpactPoint//шар уничтожающий эмиттеры
        {
           
            public Action<IImpactPoint> onDeath;
            public int Power = 100;
            public int Counter = 0;//счёт для насыщенности цвета
            public int Score = 0;//счет уничтоженных шаров

            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;

                double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
                
                if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
                {
                    particle.Life = 0;
                    if(particle.Life <= 0)
                    {
                        Counter++;
                        Score++;
                        Red++;
                        if (Red >= 255)
                        {
                            Red = 255;
                            Green += 1;
                            if (Green >= 255)
                            {
                                Green = 255;
                                Blue += 1;
                                if (Blue >= 100)
                                {
                                    Red = 0;
                                    Blue = 0;
                                    Green = 0;
                                }
                            }
                        }
                    }
                }
            }
            public int Red, Green, Blue;//для изменения цвета
            public override void Render(Graphics g)
            {
                
                if (Counter >= 235)
                {
                    Counter = 255;
                }
                
                
                Color red = Color.FromArgb(Red, Green, Blue);//для изменения цвета
                Color my = Color.FromArgb(Counter, red);
                g.FillEllipse(new SolidBrush(my), X-Power/2,Y- Power / 2, Power, Power);
                g.DrawString(
            $"", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
            new Font("Verdana", 10), // шрифт и его размер
            new SolidBrush(Color.White), // цвет шрифта
            X, // расположение в пространстве
            Y
            );
                var stringFormat = new StringFormat(); // создаем экземпляр класса
                stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
                stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали
                
                g.DrawString(
                    $"Я уничтожаю шары\n{Score}",
                    new Font("Verdana", 10),
                    new SolidBrush(Color.White),
                    X,
                    Y,
                    stringFormat // передаем инфу о выравнивании
                );
            }
        }
        

    }
}
