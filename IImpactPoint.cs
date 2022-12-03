using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public abstract class IImpactPoint:Emitter
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;
        public Action<IImpactPoint> onDeath;
        //public Action<Particle> OnEmitterOverlap;
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

        /////////////////////////////////////////////////////////////////////

        
        public class DeathGravityPoint : IImpactPoint
        {
            public int Power = 100;
            public int Counter = 0;

            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                //particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
                //particle.SpeedY -= gY * Power / r2; // и тут
            }
            //public override GraphicsPath GetGraphicsPath()
            //{
            //    var path = base.GetGraphicsPath();
            //    path.AddEllipse(X - Power / 2,
            //           Y - Power / 2,
            //           Power,
            //           Power);
            //    return path;
            //}
            //public override void Overlap(Emitter obj)
            //{
            //    base.Overlap(obj);
            //    if (obj is Emitter)
            //    {
            //        onDeath(this);
            //        //OnEmitterOverlap(obj as Emitter);
            //    }

            //}
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
                    $"Я уничтожаю шары\n{Counter}",
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
