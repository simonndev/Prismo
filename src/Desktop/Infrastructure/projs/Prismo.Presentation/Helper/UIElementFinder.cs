using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace Prismo.Presentation.Helper
{
    public static class UIElementFinder
    {
        public static TElement? FindChildElementByName<TElement>(FrameworkElement container, string definedChildElementName)
            where TElement : FrameworkElement
        {
            TElement? lookingForElement = null;

            var nChildCount = VisualTreeHelper.GetChildrenCount(container);
            for (int i = 0; i < nChildCount; i++)
            {
                if (VisualTreeHelper.GetChild(container, i) is not FrameworkElement listingChildElement)
                    continue;

                if (listingChildElement is TElement childElement && listingChildElement.Name.Equals(definedChildElementName))
                {
                    // found it! Let's return.
                    lookingForElement = childElement;
                    break;
                }

                childElement = FindChildElementByName<TElement>(listingChildElement, definedChildElementName);

                if (childElement != null)
                    break;
            }

            return lookingForElement;
        }

        public static TElement? FindVisualChild<TElement>(DependencyObject obj)
            where TElement : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child is null) continue;
                else
                {
                    if (child is TElement) return (TElement)child;
                    else
                    {
                        TElement? childOfChild = FindVisualChild<TElement>(child);
                        if (childOfChild != null) return childOfChild;
                    }
                }
            }

            return null;
        }
    }
}
