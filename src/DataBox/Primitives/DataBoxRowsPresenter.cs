﻿using System;
using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;
using DataBox.Controls;

namespace DataBox.Primitives;

public class DataBoxRowsPresenter : TemplatedControl, IStyleable
{
    public static readonly DirectProperty<DataBoxRowsPresenter, IList?> ItemsProperty =
        AvaloniaProperty.RegisterDirect<DataBoxRowsPresenter, IList?>(nameof(Items), o => o.Items, (o, v) => o.Items = v);

    public static readonly DirectProperty<DataBoxRowsPresenter, IScrollable?> ScrollProperty =
        AvaloniaProperty.RegisterDirect<DataBoxRowsPresenter, IScrollable?>(nameof(Scroll), o => o.Scroll);

    internal DataBox? _root;
    private IList? _items;
    private IScrollable? _scroll;

    public IList? Items
    {
        get { return _items; }
        set { SetAndRaise(ItemsProperty, ref _items, value); }
    }

    public IScrollable? Scroll
    {
        get { return _scroll; }
        private set { SetAndRaise(ScrollProperty, ref _scroll, value); }
    }

    Type IStyleable.StyleKey => typeof(DataBoxRowsPresenter);

    /*
    protected override IItemContainerGenerator CreateItemContainerGenerator()
    {
        var generator = new ItemContainerGenerator<DataBoxRow>(
            this,
            ContentControl.ContentProperty,
            ContentControl.ContentTemplateProperty);

        generator.Materialized += (_, args) =>
        {
            foreach (var container in args.Containers)
            {
                if (container.ContainerControl is DataBoxRow row)
                {
                    row._root = _root;
                }
            }
        };
        generator.Dematerialized += (_, args) =>
        {
            foreach (var container in args.Containers)
            {
                if (container.ContainerControl is DataBoxRow row)
                {
                    row._root = null;
                }
            }
        };

        generator.Recycled += (_, args) =>
        {
            foreach (var container in args.Containers)
            {
                if (container.ContainerControl is DataBoxRow row)
                {
                    row._root = _root;
                }
            }
        };

        return generator;
    }
    //*/

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        Scroll = e.NameScope.Find<IScrollable>("PART_ScrollViewer");
    }
}
