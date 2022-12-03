using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static course_work.IImpactPoint;
using static course_work.Particle;


namespace course_work
{
    public class Emitter
    {
        
        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // <<< ТАК ВОТ
        //
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 1; // пусть гравитация будет силой один пиксель за такт, нам хватит
        //
        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы
        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц


        ////////////////////////////////////////////////////////////////////////
        public Action<Emitter, Emitter> OnOverlap;
        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(0);
            return matrix;
        }
        public virtual GraphicsPath GetGraphicsPath()
        {
            return new GraphicsPath();
        }

        public virtual bool Overlaps(Emitter obj, Graphics g)
        {
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();


            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());


            var region = new Region(path1);
            region.Intersect(path2);
            // пересекаем формы
            return !region.IsEmpty(g); // если полученная форма не пуста то значит было пересечение
        }
        public virtual void Overlap(Emitter obj)
        {
            if (this.OnOverlap != null)
            {
                this.OnOverlap(this, obj);
            }
        }

        ////////////////////////////////////////////////////////////////////////

        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик
            foreach (var particle in particles)
            {
                if (particle.Life <= 0) // если частицы умерла
                {
                    /* 
                     * то проверяем надо ли создать частицу
                     */
                    if (particlesToCreate > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    // каждая точка по-своему воздействует на вектор скорости
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // это не трогаем
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            // второй цикл меняем на while, 
            // этот новый цикл также будет срабатывать только в самом начале работы эмиттера
            // собственно пока не накопится критическая масса частиц
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        public int ParticlesCount = 500;
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public void Render(Graphics g)
        {
            // ну тут так и быть уж сам впишу...
            // это то же самое что на форме в методе Render
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints) // тут теперь  impactPoints
            {
                point.Render(g); // это добавили
            }
        }
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
    }
}
