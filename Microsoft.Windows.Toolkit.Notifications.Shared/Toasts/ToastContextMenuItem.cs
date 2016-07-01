﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Windows.Toolkit.Notifications
{
    public sealed class ToastContextMenuItem
    {
        /// <summary>
        /// Initializes a Toast context menu item with the required properties.
        /// </summary>
        /// <param name="content">The text to display on the menu item.</param>
        /// <param name="arguments">App-defined string of arguments that the app can later retrieve once it is activated when the user clicks the menu item.</param>
        public ToastContextMenuItem(string content, string arguments)
        {
            if (content == null)
                throw new ArgumentNullException("content");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            Content = content;
            Arguments = arguments;
        }

        /// <summary>
        /// Required. The text to display on the menu item.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Required. App-defined string of arguments that the app can later retrieve once it is activated when the user clicks the menu item.
        /// </summary>
        public string Arguments { get; private set; }

        /// <summary>
        /// Controls what type of activation this menu item will use when clicked. Defaults to Foreground.
        /// </summary>
        public ToastActivationType ActivationType { get; set; } = ToastActivationType.Foreground;

        internal Element_ToastAction ConvertToElement()
        {
            return new Element_ToastAction()
            {
                Content = Content,
                Arguments = Arguments,
                ActivationType = GetElementActivationType(),
                Placement = Element_ToastActionPlacement.ContextMenu
            };
        }

        private Element_ToastActivationType GetElementActivationType()
        {
            switch (ActivationType)
            {
                case ToastActivationType.Foreground:
                    return Element_ToastActivationType.Foreground;

                case ToastActivationType.Background:
                    return Element_ToastActivationType.Background;

                case ToastActivationType.Protocol:
                    return Element_ToastActivationType.Protocol;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
