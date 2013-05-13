using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

using ClassRoom.Enum;
using ClassRoom.View;


namespace ClassRoom.DrawCanvas
{
    public class MoveThumb : Thumb
    {
        private RotateTransform rotateTransform;
        private ContentControl designerItem;

        public MoveThumb()
        {
            DragStarted += new DragStartedEventHandler(this.MoveThumb_DragStarted);
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        private void MoveThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.designerItem = DataContext as ContentControl;

            Selector.SetIsSelected(designerItem, true);
            if (this.designerItem != null)
            {
                this.rotateTransform = this.designerItem.RenderTransform as RotateTransform;
            }
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (this.designerItem != null)
            {
                Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);

                if (this.rotateTransform != null)
                {
                    dragDelta = this.rotateTransform.Transform(dragDelta);
                }

                Canvas.SetLeft(this.designerItem, Canvas.GetLeft(this.designerItem) + dragDelta.X);
                Canvas.SetTop(this.designerItem, Canvas.GetTop(this.designerItem) + dragDelta.Y);

                NoteView note = this.designerItem.Tag as NoteView;
                note.DataStatus = DataStatusEnum.Updated;
                note.X = Canvas.GetLeft(this.designerItem);
                note.Y = Canvas.GetTop(this.designerItem);
            }
        }
    }
}
