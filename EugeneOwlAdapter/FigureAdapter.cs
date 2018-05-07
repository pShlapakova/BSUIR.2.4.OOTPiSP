namespace EugeneOwlAdapter
{
    using EugeneOwlFigure;

    using ShapePluginBase;

    public abstract class FigureAdapter : AbstractShape
    {
        protected Figure figure;

        public abstract override string ToString();

        public abstract override object Clone();

        public abstract AbstractShape GetAbstractShape();
    }
}
