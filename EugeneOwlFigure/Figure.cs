namespace EugeneOwlFigure
{
    using System.Drawing.Drawing2D;

    public abstract class Figure
    {
        public abstract GraphicsPath GetPath();

        public abstract void SetManualParameters(int[] values);
    }
}
