﻿using System.Windows;
using System.Windows.Controls;
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

        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T? FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;
            T? foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                if (child is not T)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);
                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    FrameworkElement? frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T?)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T?)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
