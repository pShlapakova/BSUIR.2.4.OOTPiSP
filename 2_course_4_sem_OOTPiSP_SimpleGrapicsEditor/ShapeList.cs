using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    class ShapeList
    {
        private List<Shape> shapeList = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapeList.Add(shape);
        }

        public void DrawAll(Control control)
        {
            foreach (Shape shape in shapeList)
            {
                DrawingTools.Draw(shape, control);
            }
        }
    }
}
