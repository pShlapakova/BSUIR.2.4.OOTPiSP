namespace EugeneOwlAdapter
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;
    using EugeneOwlCross;    
    using ShapePluginBase;

    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Cross")]
    public class CrossAdapter : AbstractShape
    {
        //[DataMember]
        //private Cross cross = new Cross();

        public CrossAdapter() : base()
        {
            
        }

        public CrossAdapter(int x, int y, float penWidth, Color penColor, DashStyle penDashStyle)
            : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;            
        }

        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }        

        public override void CreateShape()
        {
            //base.CreateShape();
            Cross cross = new Cross(this.X, this.Y);
            this.GraphicsPath = cross.GetPath();
        }

        public override string ToString()
        {
            return $"{nameof(Cross)}({this.X},{this.Y}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        public override object Clone()
        {
            return new CrossAdapter(this.X, this.Y, this.PenWidth, this.PenColor, this.PenDashStyle);
        }



        // FigureAdapter не делал, т.к. в нём нечего добавить (CreateShape(), ToString()
        // и Clone() окажутся пустыми; DataMember'ов общих нет, в конструкторах ничего спеифическое задавать не нужно).



        // Следующим способом не получается, т.к.:
        // 1) При десериализации получаем cross == null.
        // 2) Аналогично при десериализации, если указать полю private Cross cross атрибут DataMember.
        // 3) Это можно было бы решить, используя метод с атрибутом OnDeserializing.
        // 4) Однако этот метод должен быть в AbstractShape, т.к. это основной тип для JSON сериализации.
        // 5) А метод с атрибутом OnDeserializing нельзя сделать виртуальным.
        //[DataMember]
        //public int X
        //{            
        //    get => this.cross.xPosition;
        //    set => this.cross.xPosition = value;
        //}
        //[DataMember]
        //public int Y
        //{
        //    get => this.cross.yPosition;
        //    set => this.cross.yPosition = value;
        //}
    }
}
