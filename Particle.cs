using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public class Particle
    {
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве
        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y
        public float Life; // запас здоровья частицы
        // добавили генератор случайных чисел
        public static Random rand = new Random();



        //public Action<Particle, Particle> OnOverlap;
        //public Matrix GetTransform()
        //{
        //    var matrix = new Matrix();
        //    matrix.Translate(X, Y);
        //    matrix.Rotate(0);
        //    return matrix;
        //}
        //public virtual GraphicsPath GetGraphicsPath()
        //{
        //    return new GraphicsPath();
        //}

        //public virtual bool Overlaps(Particle obj, Graphics g)
        //{
        //    var path1 = this.GetGraphicsPath();
        //    var path2 = obj.GetGraphicsPath();


        //    path1.Transform(this.GetTransform());
        //    path2.Transform(obj.GetTransform());


        //    var region = new Region(path1);
        //    region.Intersect(path2);
        //    // пересекаем формы
        //    return !region.IsEmpty(g); // если полученная форма не пуста то значит было пересечение
        //}
        //public virtual void Overlap(Particle obj)
        //{
        //    if (this.OnOverlap != null)
        //    {
        //        this.OnOverlap(this, obj);
        //    }
        //}

        /// /////////////////////////////////////////////////////

        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // генерируем произвольное направление и скорость
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            // рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            // а это не трогаем
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }
        public virtual void Draw(Graphics g)
        {
            // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);
            // рассчитываем значение альфа канала в шкале от 0 до 255
            // по аналогии с RGB, он используется для задания прозрачности
            int alpha = (int)(k * 255);

            // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            // остальное все так же
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
        // новый класс для цветных частиц
        public class ParticleColorful : Particle
        {
            // два новых поля под цвет начальный и конечный
            public Color FromColor;
            public Color ToColor;

            // для смеси цветов
            public static Color MixColor(Color color1, Color color2, float k)
            {
                return Color.FromArgb(
                    (int)(color2.A * k + color1.A * (1 - k)),
                    (int)(color2.R * k + color1.R * (1 - k)),
                    (int)(color2.G * k + color1.G * (1 - k)),
                    (int)(color2.B * k + color1.B * (1 - k))
                );
            }

            // ну и отрисовку перепишем
            public override void Draw(Graphics g)
            {
                float k = Math.Min(1f, Life / 100);

                // так как k уменьшается от 1 до 0, то порядок цветов обратный
                var color = MixColor(ToColor, FromColor, k);
                var b = new SolidBrush(color);

                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

                b.Dispose();
            }
            
        }
        
    }

}
