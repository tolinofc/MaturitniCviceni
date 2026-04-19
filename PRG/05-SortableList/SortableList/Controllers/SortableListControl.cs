using static System.Net.Mime.MediaTypeNames;

namespace SortableList.Controllers
{
    public class SortableListControl<T> : Control
    {
        private class ItemRegion
        {
            public T Item { get; set; }
            public RectangleF Bounds { get; set; }
        }

        private List<ItemRegion> regions = new List<ItemRegion>();
        public List<T> DataSource;
        private PointF draggedPoint;
        private ItemRegion draggedItem;

        public SortableListControl(List<T> data)
        {
            DataSource = data;
            DoubleBuffered = true;
        }

        public Func<T, bool> IsSelected { get; set; }

        public Func<T, string> ShowableText { get; set; }

        public event EventHandler<T> ItemSelectionChanged;

        public event Action<T, int> ItemOrderChanged;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            regions.Clear();

            const float leftPadding = 20;
            const float itemHeight = 40;

            float leftY = 20;
            float rightY = 20;
            float itemWidth = Width / 2 - 40;

            foreach (T item in DataSource)
            {
                if (draggedItem != null && item.Equals(draggedItem.Item))
                {
                    if (IsSelected(item))
                    {
                        rightY += itemHeight;
                    }
                    else
                    {
                        leftY += itemHeight;
                    }
                    continue;
                }

                string text = ShowableText(item);
                SizeF textSize = g.MeasureString(text, DefaultFont);
                PointF textPosition;

                RectangleF rect;
                if (IsSelected(item))
                {
                    rect = new RectangleF(Width / 2 + leftPadding, rightY, itemWidth, itemHeight);
                    textPosition = new PointF(leftPadding + Width / 2 + itemWidth / 2 - textSize.Width / 2, rightY + itemHeight / 2 - textSize.Height / 2);
                    rightY += itemHeight;
                }
                else
                {
                    rect = new RectangleF(leftPadding, leftY, itemWidth, itemHeight);
                    textPosition = new PointF(leftPadding + itemWidth / 2 - textSize.Width / 2, leftY + itemHeight / 2 - textSize.Height / 2);
                    leftY += itemHeight;
                }

                g.FillRectangle(Brushes.Aqua, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(text, DefaultFont, Brushes.Black, textPosition);

                regions.Add(new ItemRegion() { Item = item, Bounds = rect });
            }

            if (draggedItem != null)
            {
                string text = ShowableText(draggedItem.Item);
                SizeF textSize = g.MeasureString(text, DefaultFont);
                PointF textPosition = new PointF(draggedItem.Bounds.X + (itemWidth / 2) - (textSize.Width / 2), draggedItem.Bounds.Y + (itemHeight / 2) - (textSize.Height / 2));

                g.FillRectangle(Brushes.Aqua, draggedItem.Bounds);
                g.DrawRectangle(Pens.Black, draggedItem.Bounds);
                g.DrawString(text, DefaultFont, Brushes.Black, textPosition);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointF selectedPoint = e.Location;

                foreach (ItemRegion region in regions)
                {
                    if (region.Bounds.Contains(selectedPoint))
                    {
                        draggedPoint = new PointF(e.X - region.Bounds.X, e.Y - region.Bounds.Y);
                        draggedItem = region;
                        break;
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (draggedItem != null)
            {
                float deltaY = e.Y - draggedPoint.Y;

                draggedItem.Bounds = new RectangleF(e.X - draggedPoint.X, e.Y - draggedPoint.Y, draggedItem.Bounds.Width, draggedItem.Bounds.Height);

                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (draggedItem != null)
            {
                int newIndex = (e.Y - 20) / 40;

                if (e.X < Width / 2 && IsSelected(draggedItem.Item))
                {
                    ItemSelectionChanged?.Invoke(this, draggedItem.Item);
                }
                else if (e.X > Width / 2 && !IsSelected(draggedItem.Item))
                {
                    ItemSelectionChanged?.Invoke(this, draggedItem.Item);
                }

                if (newIndex < 0)
                {
                    newIndex = 0;
                }

                ItemOrderChanged.Invoke(draggedItem.Item, newIndex);

                this.draggedItem = null;
                Invalidate();
            }
        }
    }
}
