using System;
using System.Windows;
using System.Windows.Controls;

namespace OrientationLayouts
{
    public static class DefinitionsExtensions
    {
        /// <summary>
        /// Fills or clears row definitions based on the specified format.
        /// If the format is null or whitespace, the row definition collection
        /// is cleared. Otherwise, it is parsed and definitions are added.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="format">Comma separated row definitions.</param>
        /// <example>This sample shows you how to call <see cref="ParseAndFill"/> method.
        /// <code>
        /// grid.RowDefinitions.ParseAndFill("Auto,*,2*,10");</code></example>
        /// <exception cref="System.NullReferenceException">If @this is null.</exception>
        public static void ParseAndFill(this RowDefinitionCollection @this, string format)
        {
            if (@this == null)
                throw new NullReferenceException("@this must not be null");

            // this is still valid, simply clear the definition
            if (string.IsNullOrWhiteSpace(format))
            {
                @this.Clear();
                return;
            }

            var values = format.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
            {
                if (value.Equals("Auto", StringComparison.CurrentCultureIgnoreCase))
                {
                    Add(@this, GridUnitType.Auto);
                }
                else if (value.Equals("*"))
                {
                    Add(@this, GridUnitType.Star);
                }
                else if (value.EndsWith("*"))
                {
                    double d;
                    if (double.TryParse(value.Substring(0, value.Length - 1), out d))
                        Add(@this, GridUnitType.Star, d);
                }
                else
                {
                    double d;
                    if (double.TryParse(value, out d))
                        Add(@this, GridUnitType.Pixel, d);
                }
            }
        }

        /// <summary>
        /// Fills or clears column definitions based on the specified format.
        /// If the format is null or whitespace, the column definition collection
        /// is cleared. Otherwise, it is parsed and definitions are added.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="format">Comma separated row definitions.</param>
        /// <example>This sample shows you how to call <see cref="ParseAndFill"/> method.
        /// <code>
        /// grid.ColumnDefinitions.ParseAndFill("Auto,*,2*,10");</code></example>
        /// <exception cref="System.NullReferenceException">If @this is null.</exception>
        public static void ParseAndFill(this ColumnDefinitionCollection @this, string format)
        {
            if (@this == null)
                throw new NullReferenceException("@this must not be null");

            // this is still valid, simply clear the definition
            if (string.IsNullOrWhiteSpace(format))
            {
                @this.Clear();
                return;
            }

            var values = format.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
            {
                if (value.Equals("Auto", StringComparison.CurrentCultureIgnoreCase))
                {
                    Add(@this, GridUnitType.Auto);
                }
                else if (value.Equals("*"))
                {
                    Add(@this, GridUnitType.Star);
                }
                else if (value.EndsWith("*"))
                {
                    double d;
                    if (double.TryParse(value.Substring(0, value.Length - 1), out d))
                        Add(@this, GridUnitType.Star, d);
                }
                else
                {
                    double d;
                    if (double.TryParse(value, out d))
                        Add(@this, GridUnitType.Pixel, d);
                }
            }
        }

        private static void Add(this RowDefinitionCollection @this, GridUnitType type, double length = 1)
        {
            if (@this == null)
                throw new NullReferenceException("@this must not be null");

            @this.Add(new RowDefinition
                {
                    Height = new GridLength(length, type)
                });
        }

        private static void Add(this ColumnDefinitionCollection @this, GridUnitType type, double length = 1)
        {
            if (@this == null)
                throw new NullReferenceException("@this must not be null");

            @this.Add(new ColumnDefinition
            {
                Width = new GridLength(length, type)
            });
        }
    }
}
