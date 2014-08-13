﻿namespace WindowsPhoneDriver.InnerDriver.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;

    internal static class FrameworkElementExtensions
    {
        #region Methods

        internal static Point GetCoordinates(this FrameworkElement element, UIElement visualRoot)
        {
            var point = element.TransformToVisual(visualRoot).Transform(new Point(0, 0));
            var center = new Point(point.X + (int)(element.ActualWidth / 2), point.Y + (int)(element.ActualHeight / 2));
            return center;
        }

        internal static string GetText(this FrameworkElement element)
        {
            var propertyNames = new List<string> { "Text", "Content" };

            foreach (var textProperty in from propertyName in propertyNames
                                         select element.GetType().GetProperty(propertyName)
                                         into textProperty
                                         where textProperty != null
                                         let value = textProperty.GetValue(element)
                                         where value is string
                                         select textProperty)
            {
                return textProperty.GetValue(element).ToString();
            }

            return string.Empty;
        }

        internal static bool IsUserVisible(this FrameworkElement element, UIElement visualRoot)
        {
            var zero = new Point(0, 0);
            var elementSize = new Size(element.ActualWidth, element.ActualHeight);

            // Check if element is of zero size
            if (!(elementSize.Width > 0 && elementSize.Height > 0))
            {
                return false;
            }

            var rect = new Rect(zero, elementSize);
            var bound = element.TransformToVisual(visualRoot).TransformBounds(rect);
            var rootRect = new Rect(zero, visualRoot.RenderSize);
            rootRect.Intersect(bound);

            // Check if element is offscreen
            if (rootRect.IsEmpty)
            {
                return false;
            }

            while (true)
            {
                if (element.Visibility != Visibility.Visible || !element.IsHitTestVisible || !(element.Opacity > 0))
                {
                    return false;
                }

                var container = VisualTreeHelper.GetParent(element) as FrameworkElement;
                if (container == null)
                {
                    return true;
                }

                element = container;
            }
        }

        #endregion
    }
}
