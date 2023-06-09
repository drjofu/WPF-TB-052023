﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace VerkehrsControls
{
  /// <summary>
  /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
  ///
  /// Step 1a) Using this custom control in a XAML file that exists in the current project.
  /// Add this XmlNamespace attribute to the root element of the markup file where it is 
  /// to be used:
  ///
  ///     xmlns:MyNamespace="clr-namespace:VerkehrsControls"
  ///
  ///
  /// Step 1b) Using this custom control in a XAML file that exists in a different project.
  /// Add this XmlNamespace attribute to the root element of the markup file where it is 
  /// to be used:
  ///
  ///     xmlns:MyNamespace="clr-namespace:VerkehrsControls;assembly=VerkehrsControls"
  ///
  /// You will also need to add a project reference from the project where the XAML file lives
  /// to this project and Rebuild to avoid compilation errors:
  ///
  ///     Right click on the target project in the Solution Explorer and
  ///     "Add Reference"->"Projects"->[Select this project]
  ///
  ///
  /// Step 2)
  /// Go ahead and use your control in the XAML file.
  ///
  ///     <MyNamespace:CustomControl1/>
  ///
  /// </summary>
  //[DefaultProperty(nameof(IstRot))]
  [TemplatePart(Name = "PART_LampeRot", Type = typeof(Shape))]
  [TemplatePart(Name = "PART_LampeGrün", Type = typeof(Shape))]
  public class Ampel : Control
  {
    static Ampel()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(Ampel), new FrameworkPropertyMetadata(typeof(Ampel)));
    }

    private Shape lampeRot;
    private Shape lampeGrün;

    [Category("Verkehr")]
    [Description("Schaltet um zwischen Rot und Grün")]
    public bool IstRot
    {
      get { return (bool)GetValue(IstRotProperty); }
      set { SetValue(IstRotProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IstRot.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IstRotProperty =
        DependencyProperty.Register(nameof(IstRot), typeof(bool), typeof(Ampel),
          new FrameworkPropertyMetadata(true,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnIstRotChanged));

    private static void OnIstRotChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Ampel ampel = (Ampel)d;
      ampel.Schalten();
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      lampeRot = (Shape)this.GetTemplateChild("PART_LampeRot");
      lampeGrün = (Shape)GetTemplateChild("PART_LampeGrün");
      Schalten();
    }

    private void Schalten()
    {
      // Template gesetzt?
      if (lampeRot == null) return;

      if (IstRot)
      {
        lampeRot.Opacity = 1;
        lampeGrün.Opacity = 0.2;
      }
      else
      {
        lampeGrün.Opacity = 1;
        lampeRot.Opacity = 0.2;
      }
    }
  }
}
