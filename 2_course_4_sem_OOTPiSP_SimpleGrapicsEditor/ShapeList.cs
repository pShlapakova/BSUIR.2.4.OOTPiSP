using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System.Collections.Generic;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    class ShapeList
    {
        private List<Shape> shapeList = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapeList.Add(shape);
        }

        public void DrawAll()
        {
            foreach (Shape shape in shapeList)
            {
                shape.Draw();
            }
        }
    }
}
