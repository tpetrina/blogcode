#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using LinqToVisualTree;
using Microsoft.Phone.Controls;

#endregion

namespace OrientationLayouts
{
    public class GridOrientationLayout : Behavior<Grid>
    {
        public static readonly DependencyProperty PortraitRowDefinitionsProperty =
            DependencyProperty.Register("PortraitRowDefinitions", typeof(string), typeof(GridOrientationLayout),
                                        new PropertyMetadata(default(string)));

        public string PortraitRowDefinitions
        {
            get { return (string)GetValue(PortraitRowDefinitionsProperty); }
            set { SetValue(PortraitRowDefinitionsProperty, value); }
        }

        public static readonly DependencyProperty LandscapeRowDefinitionsProperty =
            DependencyProperty.Register("LandscapeRowDefinitions", typeof(string), typeof(GridOrientationLayout),
                                        new PropertyMetadata(default(string)));

        public string LandscapeRowDefinitions
        {
            get { return (string)GetValue(LandscapeRowDefinitionsProperty); }
            set { SetValue(LandscapeRowDefinitionsProperty, value); }
        }

        public static readonly DependencyProperty PortraitColumnDefinitionsProperty =
            DependencyProperty.Register("PortraitColumnDefinitions", typeof(string), typeof(GridOrientationLayout),
                                        new PropertyMetadata(default(string)));

        public string PortraitColumnDefinitions
        {
            get { return (string)GetValue(PortraitColumnDefinitionsProperty); }
            set { SetValue(PortraitColumnDefinitionsProperty, value); }
        }

        public static readonly DependencyProperty LandscapeColumnDefinitionsProperty =
            DependencyProperty.Register("LandscapeColumnDefinitions", typeof(string), typeof(GridOrientationLayout),
                                        new PropertyMetadata(default(string)));

        public string LandscapeColumnDefinitions
        {
            get { return (string)GetValue(LandscapeColumnDefinitionsProperty); }
            set { SetValue(LandscapeColumnDefinitionsProperty, value); }
        }





        public static string GetGridRow(DependencyObject obj)
        {
            return (string)obj.GetValue(GridRowProperty);
        }

        public static void SetGridRow(DependencyObject obj, string value)
        {
            obj.SetValue(GridRowProperty, value);
        }

        // Using a DependencyProperty as the backing store for GridRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridRowProperty =
            DependencyProperty.RegisterAttached("GridRow", typeof(string), typeof(GridOrientationLayout),
                                                new PropertyMetadata(null));

        public static string GetGridColumn(DependencyObject obj)
        {
            return (string)obj.GetValue(GridColumnProperty);
        }

        public static void SetGridColumn(DependencyObject obj, string value)
        {
            obj.SetValue(GridColumnProperty, value);
        }

        // Using a DependencyProperty as the backing store for GridColumn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridColumnProperty =
            DependencyProperty.RegisterAttached("GridColumn", typeof(string), typeof(GridOrientationLayout),
                                                new PropertyMetadata(null));

        public static bool GetIsSupported(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSupportedProperty);
        }

        public static void SetIsSupported(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSupportedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsSupported.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSupportedProperty =
            DependencyProperty.RegisterAttached("IsSupported", typeof(bool), typeof(GridOrientationLayout), new PropertyMetadata(false));






        private PhoneApplicationPage _page;


        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            base.OnAttached();
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = AssociatedObject.Parent;
            while (parent != null)
            {
                if (parent is PhoneApplicationPage)
                {
                    _page = (PhoneApplicationPage)parent;
                    break;
                }

                parent = ((FrameworkElement)parent).Parent;
            }

            if (_page != null)
            {
                _page.OrientationChanged += PageOnOrientationChanged;
            }
        }

        private void PageOnOrientationChanged(object sender, OrientationChangedEventArgs orientationChangedEventArgs)
        {
            if (_page == null)
                return;

            var orientation = _page.Orientation;
            switch (orientation)
            {
                case PageOrientation.Portrait:
                case PageOrientation.PortraitUp:
                case PageOrientation.PortraitDown:
                    {
                        var rowdef = PortraitRowDefinitions;
                        if (rowdef == null)
                            AssociatedObject.RowDefinitions.Clear();
                        else
                            RowDefinitionsFromString(rowdef);

                        var coldef = PortraitColumnDefinitions;
                        if (coldef == null)
                            AssociatedObject.ColumnDefinitions.Clear();
                        else
                            ColumnDefinitionsFromString(coldef);

                        break;
                    }
                case PageOrientation.Landscape:
                case PageOrientation.LandscapeLeft:
                case PageOrientation.LandscapeRight:
                    {
                        var rowdef = LandscapeRowDefinitions;
                        if (rowdef == null)
                            AssociatedObject.RowDefinitions.Clear();
                        else
                            RowDefinitionsFromString(rowdef);

                        var coldef = LandscapeColumnDefinitions;
                        if (coldef == null)
                            AssociatedObject.ColumnDefinitions.Clear();
                        else
                            ColumnDefinitionsFromString(coldef);

                        break;
                    }
            }

            foreach (FrameworkElement fe in _page.Descendants<FrameworkElement>())
            {
                if (GetIsSupported(fe))
                {
                    var row = GetGridRow(fe);
                    if (row != null)
                    {
                        var values = row.Split(new[] { ',' });
                        if (orientation == PageOrientation.PortraitUp)
                            Grid.SetRow(fe, int.Parse(values[0]));
                        else
                            Grid.SetRow(fe, int.Parse(values[1]));
                    }
                    else
                    {
                        Grid.SetRow(fe, 0);
                    }

                    var column = GetGridColumn(fe);
                    if (column != null)
                    {
                        var values = column.Split(new[] { ',' });
                        if (orientation == PageOrientation.PortraitUp)
                            Grid.SetColumn(fe, int.Parse(values[0]));
                        else
                            Grid.SetColumn(fe, int.Parse(values[1]));
                    }
                    else
                    {
                        Grid.SetColumn(fe, 0);
                    }
                }
            }
        }

        private void RowDefinitionsFromString(string format)
        {
            var definitions = AssociatedObject.RowDefinitions;
            var values = format.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
            {
                if (value == "Auto")
                    definitions.Add(new RowDefinition
                        {
                            Height = new GridLength(1, GridUnitType.Auto)
                        });
                else if (value == "*")
                    definitions.Add(new RowDefinition
                    {
                        Height = new GridLength(1, GridUnitType.Star)
                    });
            }
        }

        private void ColumnDefinitionsFromString(string format)
        {
            var definitions = AssociatedObject.ColumnDefinitions;
            var values = format.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
            {
                if (value == "Auto")
                    definitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Auto)
                    });
                else if (value == "*")
                    definitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Star)
                    });
            }
        }
    }
}