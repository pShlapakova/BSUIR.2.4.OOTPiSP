namespace EugeneOwlAdapter
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;

    using EugeneOwlCross;

    using ShapePluginBase;

    public class CrossAdapter : FigureAdapter
    {
        public override string ToString()
        {
            return $"{nameof(Cross)}({((Cross)this.figure).xPosition},{((Cross)this.figure).yPosition})";
        }

        public override object Clone()
        {
            return new Cross(((Cross)this.figure).xPosition, ((Cross)this.figure).yPosition);
        }

        public override AbstractShape GetAbstractShape()
        {
            throw new System.NotImplementedException();
        }

        public int X { get; set; }
        public int Y { get; set; }

        public CrossAdapter()
        {

        }

        public CrossAdapter(int x, int y)
        {

        }

        //public override AbstractShape GetAbstractShape()
        //{
        //    this.GraphicsPath = this.figure.GetPath();
        //    this.Pen = new Pen(Color.Black, 1.0f);

        //    this.PenWidth = 1.0f;
        //    this.PenColor = Color.Black;
        //    this.PenDashStyle = DashStyle.Solid;

        //    this.X = ((Cross)this.figure).xPosition;
        //    this.Y = ((Cross)this.figure).yPosition;

        //    //return new AbstractShape(penWidth: 1.0f, penColor: Color.Black, penDashStyle: DashStyle.Solid);
        //}
    }
}
