// Ignore Spelling: bindable, color

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls.Shapes;
using static System.Math;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace CommunityToolkit.Maui.Views;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>RangeSlider view control.</summary>
[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "<Pending>")]
public partial class RangeSlider : TemplatedView
{
	/// <summary>The backing store for the <see cref="IsReadOnly" /> bindable property.</summary>
	public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(nameof(IsReadOnly), typeof(bool), typeof(RatingView), defaultValue: RangeSliderDefaults.IsReadOnly);

	/// <summary>The backing store for the <see cref="MinimumValue" /> bindable property.</summary>
	public static readonly BindableProperty MinimumValueProperty = BindableProperty.Create(nameof(MinimumValue), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultMinimumValue, propertyChanged: OnMinimumMaximumValuePropertyChanged);

	/// <summary>The backing store for the <see cref="MaximumValue" /> bindable property.</summary>
	public static readonly BindableProperty MaximumValueProperty = BindableProperty.Create(nameof(MaximumValue), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultMaximumValue, propertyChanged: OnMinimumMaximumValuePropertyChanged);

	/// <summary>The backing store for the <see cref="StepValue" /> bindable property.</summary>
	public static readonly BindableProperty StepValueProperty = BindableProperty.Create(nameof(StepValue), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultStepValue, propertyChanged: OnMinimumMaximumValuePropertyChanged);

	/// <summary>The backing store for the <see cref="LowerValue" /> bindable property.</summary>
	public static readonly BindableProperty LowerValueProperty = BindableProperty.Create(nameof(LowerValue), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultLowerValue, BindingMode.TwoWay, propertyChanged: OnLowerUpperValuePropertyChanged, coerceValue: CoerceValue);

	/// <summary>The backing store for the <see cref="UpperValue" /> bindable property.</summary>
	public static readonly BindableProperty UpperValueProperty = BindableProperty.Create(nameof(UpperValue), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultUpperValue, BindingMode.TwoWay, propertyChanged: OnLowerUpperValuePropertyChanged, coerceValue: CoerceValue);

	/// <summary>The backing store for the <see cref="ThumbSize" /> bindable property.</summary>
	public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultThumbSize, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="LowerThumbSize" /> bindable property.</summary>
	public static readonly BindableProperty LowerThumbSizeProperty = BindableProperty.Create(nameof(LowerThumbSize), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultLowerThumbSize, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="UpperThumbSize" /> bindable property.</summary>
	public static readonly BindableProperty UpperThumbSizeProperty = BindableProperty.Create(nameof(UpperThumbSize), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultUpperThumbSize, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="TrackSize" /> bindable property.</summary>
	public static readonly BindableProperty TrackSizeProperty = BindableProperty.Create(nameof(TrackSize), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultTrackSize, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="ThumbColor" /> bindable property.</summary>
	public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultThumbColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="LowerThumbColor" /> bindable property.</summary>
	public static readonly BindableProperty LowerThumbColorProperty = BindableProperty.Create(nameof(LowerThumbColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultLowerThumbColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="UpperThumbColor" /> bindable property.</summary>
	public static readonly BindableProperty UpperThumbColorProperty = BindableProperty.Create(nameof(UpperThumbColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultUpperThumbColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="TrackColor" /> bindable property.</summary>
	public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultTrackColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="TrackHighlightColor" /> bindable property.</summary>
	public static readonly BindableProperty TrackHighlightColorProperty = BindableProperty.Create(nameof(TrackHighlightColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultTrackHighlightColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="ThumbBorderColor" /> bindable property.</summary>
	public static readonly BindableProperty ThumbBorderColorProperty = BindableProperty.Create(nameof(ThumbBorderColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultThumbBorderColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="LowerThumbBorderColor" /> bindable property.</summary>
	public static readonly BindableProperty LowerThumbBorderColorProperty = BindableProperty.Create(nameof(LowerThumbBorderColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultLowerThumbColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="UpperThumbBorderColor" /> bindable property.</summary>
	public static readonly BindableProperty UpperThumbBorderColorProperty = BindableProperty.Create(nameof(UpperThumbBorderColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultUpperThumbColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="TrackBorderColor" /> bindable property.</summary>
	public static readonly BindableProperty TrackBorderColorProperty = BindableProperty.Create(nameof(TrackBorderColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultTrackBorderColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="TrackHighlightBorderColor" /> bindable property.</summary>
	public static readonly BindableProperty TrackHighlightBorderColorProperty = BindableProperty.Create(nameof(TrackHighlightBorderColor), typeof(Color), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultTrackHighlightBorderColor, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="ValueLabelStyle" /> bindable property.</summary>
	public static readonly BindableProperty ValueLabelStyleProperty = BindableProperty.Create(nameof(ValueLabelStyle), typeof(Style), typeof(RangeSlider), defaultValue: default(Style), propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="LowerValueLabelStyle" /> bindable property.</summary>
	public static readonly BindableProperty LowerValueLabelStyleProperty = BindableProperty.Create(nameof(LowerValueLabelStyle), typeof(Style), typeof(RangeSlider), defaultValue: default(Style), propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="UpperValueLabelStyle" /> bindable property.</summary>
	public static readonly BindableProperty UpperValueLabelStyleProperty = BindableProperty.Create(nameof(UpperValueLabelStyle), typeof(Style), typeof(RangeSlider), defaultValue: default(Style), propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="ValueLabelStringFormat" /> bindable property.</summary>
	public static readonly BindableProperty ValueLabelStringFormatProperty = BindableProperty.Create(nameof(ValueLabelStringFormat), typeof(string), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultValueLabelStringFormat, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="LowerThumbView" /> bindable property.</summary>
	public static readonly BindableProperty LowerThumbViewProperty = BindableProperty.Create(nameof(LowerThumbView), typeof(View), typeof(RangeSlider), defaultValue: default(View), propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="UpperThumbView" /> bindable property.</summary>
	public static readonly BindableProperty UpperThumbViewProperty = BindableProperty.Create(nameof(UpperThumbView), typeof(View), typeof(RangeSlider), defaultValue: default(View), propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="ValueLabelSpacing" /> bindable property.</summary>
	public static readonly BindableProperty ValueLabelSpacingProperty = BindableProperty.Create(nameof(ValueLabelSpacing), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultValueLabelSpacing, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="ThumbRadius" /> bindable property.</summary>
	public static readonly BindableProperty ThumbRadiusProperty = BindableProperty.Create(nameof(ThumbRadius), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultThumbRadius, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="LowerThumbRadius" /> bindable property.</summary>
	public static readonly BindableProperty LowerThumbRadiusProperty = BindableProperty.Create(nameof(LowerThumbRadius), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultLowerThumbRadius, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="UpperThumbRadius" /> bindable property.</summary>
	public static readonly BindableProperty UpperThumbRadiusProperty = BindableProperty.Create(nameof(UpperThumbRadius), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultUpperThumbRadius, propertyChanged: OnLayoutPropertyChanged);

	/// <summary>The backing store for the <see cref="TrackRadius" /> bindable property.</summary>
	public static readonly BindableProperty TrackRadiusProperty = BindableProperty.Create(nameof(TrackRadius), typeof(double), typeof(RangeSlider), defaultValue: RangeSliderDefaults.DefaultTrackRadius, propertyChanged: OnLayoutPropertyChanged);

	readonly WeakEventManager weakEventManager = new();

	AbsoluteLayout? Control { get; set; }

	///<summary>Instantiates <see cref="RangeSlider"/>.</summary>
	public RangeSlider()
	{
		RangeSliderLayout.SetBinding<RangeSlider, object>(BindingContextProperty, static rangeSlider => rangeSlider.BindingContext, source: this);
		base.ControlTemplate = new ControlTemplate(() => RangeSliderLayout);
	}

	internal AbsoluteLayout RangeSliderLayout { get; } = [];

	/// <inheritdoc cref="ControlTemplate"/>
	public new ControlTemplate ControlTemplate => base.ControlTemplate; // Ensures the ControlTemplate is readonly, preventing users from breaking the AbsoluteLayout.

	/// <summary>Invoked when a child asset is added to this element.</summary>
	/// <param name="child">Child asset.</param>
	protected override void OnChildAdded(Element child)
	{
		if (Control is null && child is AbsoluteLayout control)
		{
			Control = control;
			control.Children.Add(Track);
			control.Children.Add(TrackHighlight);
			control.Children.Add(LowerThumb);
			control.Children.Add(UpperThumb);
			control.Children.Add(LowerValueLabel);
			control.Children.Add(UpperValueLabel);

			// TODO: Add a gesture recognizer to track changes for LowerThumb and UpperThumb
			// TODO: Add weak events for Track.SizeChanged, LowerThumb.SizeChanged, UpperThumb.SizeChanged, LowerValueLabel.SizeChanged, UpperValueLabel.SizeChanged
			OnIsReadOnlyChanged();
			OnLayoutPropertyChanged();
		}

		base.OnChildAdded(child);
	}

	///<summary>Gets or sets a value indicating if the user can interact with the <see cref="RangeSlider"/>.</summary>
	public bool IsReadOnly
	{
		get => (bool)GetValue(IsReadOnlyProperty);
		set => SetValue(IsReadOnlyProperty, value);
	}

	///<summary>Gets or sets a value indicating the minimum value of the <see cref="RangeSlider"/>.</summary>
	public double MinimumValue
	{
		get => (double)GetValue(MinimumValueProperty);
		set => SetValue(MinimumValueProperty, value);
	}

	///<summary>Gets or sets a value indicating the maximum value of the <see cref="RangeSlider"/>.</summary>
	public double MaximumValue
	{
		get => (double)GetValue(MaximumValueProperty);
		set => SetValue(MaximumValueProperty, value);
	}

	///<summary>Gets or sets a value indicating the step value.</summary>
	public double StepValue
	{
		get => (double)GetValue(StepValueProperty);
		set => SetValue(StepValueProperty, value);
	}

	///<summary>Gets or sets a value indicating the actual lower value of the <see cref="RangeSlider"/>.</summary>
	public double LowerValue
	{
		get => (double)GetValue(LowerValueProperty);
		set => SetValue(LowerValueProperty, value);
	}

	///<summary>Gets or sets a value indicating the actual upper value of the <see cref="RangeSlider"/>.</summary>
	public double UpperValue
	{
		get => (double)GetValue(UpperValueProperty);
		set => SetValue(UpperValueProperty, value);
	}

	///<summary>Gets or sets a value indicating the thumb size in points.</summary>
	public double ThumbSize
	{
		get => (double)GetValue(ThumbSizeProperty);
		set => SetValue(ThumbSizeProperty, value);
	}

	///<summary>Gets or sets a value indicating the lower thumb size in points.</summary>
	public double LowerThumbSize
	{
		get => (double)GetValue(LowerThumbSizeProperty);
		set => SetValue(LowerThumbSizeProperty, value);
	}

	///<summary>Gets or sets a value indicating the upper thumb size in points.</summary>
	public double UpperThumbSize
	{
		get => (double)GetValue(UpperThumbSizeProperty);
		set => SetValue(UpperThumbSizeProperty, value);
	}

	///<summary>Gets or sets a value indicating the track size in points.</summary>
	public double TrackSize
	{
		get => (double)GetValue(TrackSizeProperty);
		set => SetValue(TrackSizeProperty, value);
	}

	///<summary>Gets or sets a value indicating the thumb color.</summary>
	[AllowNull]
	public Color ThumbColor
	{
		get => (Color)GetValue(ThumbColorProperty);
		set => SetValue(ThumbColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the lower thumb color.</summary>
	[AllowNull]
	public Color LowerThumbColor
	{
		get => (Color)GetValue(LowerThumbColorProperty);
		set => SetValue(LowerThumbColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the upper thumb color.</summary>
	[AllowNull]
	public Color UpperThumbColor
	{
		get => (Color)GetValue(UpperThumbColorProperty);
		set => SetValue(UpperThumbColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the track color.</summary>
	[AllowNull]
	public Color TrackColor
	{
		get => (Color)GetValue(TrackColorProperty);
		set => SetValue(TrackColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the track highlight color.</summary>
	[AllowNull]
	public Color TrackHighlightColor
	{
		get => (Color)GetValue(TrackHighlightColorProperty);
		set => SetValue(TrackHighlightColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the thumb border color.</summary>
	[AllowNull]
	public Color ThumbBorderColor
	{
		get => (Color)GetValue(ThumbBorderColorProperty);
		set => SetValue(ThumbBorderColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the lower thumb border color.</summary>
	[AllowNull]
	public Color LowerThumbBorderColor
	{
		get => (Color)GetValue(LowerThumbBorderColorProperty);
		set => SetValue(LowerThumbBorderColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the upper thumb border color.</summary>
	[AllowNull]
	public Color UpperThumbBorderColor
	{
		get => (Color)GetValue(UpperThumbBorderColorProperty);
		set => SetValue(UpperThumbBorderColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the track color.</summary>
	[AllowNull]
	public Color TrackBorderColor
	{
		get => (Color)GetValue(TrackBorderColorProperty);
		set => SetValue(TrackBorderColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the track highlight color.</summary>
	[AllowNull]
	public Color TrackHighlightBorderColor
	{
		get => (Color)GetValue(TrackHighlightBorderColorProperty);
		set => SetValue(TrackHighlightBorderColorProperty, value);
	}

	///<summary>Gets or sets a value indicating the value label <see cref="Style" />.</summary>
	[AllowNull]
	public Style ValueLabelStyle
	{
		get => (Style)GetValue(ValueLabelStyleProperty);
		set => SetValue(ValueLabelStyleProperty, value);
	}

	///<summary>Gets or sets a value indicating the lower value label <see cref="Style"/>.</summary>
	[AllowNull]
	public Style LowerValueLabelStyle
	{
		get => (Style)GetValue(LowerValueLabelStyleProperty);
		set => SetValue(LowerValueLabelStyleProperty, value);
	}

	///<summary>Gets or sets a value indicating the upper value label <see cref="Style"/>.</summary>
	[AllowNull]
	public Style UpperValueLabelStyle
	{
		get => (Style)GetValue(UpperValueLabelStyleProperty);
		set => SetValue(UpperValueLabelStyleProperty, value);
	}

	///<summary>Gets or sets a value indicating the value label string format.</summary>
	public string ValueLabelStringFormat
	{
		get => (string)GetValue(ValueLabelStringFormatProperty);
		set => SetValue(ValueLabelStringFormatProperty, value);
	}

	///<summary>Gets or sets a value indicating the lower thumb <see cref="View"/>.</summary>
	[AllowNull]
	public View LowerThumbView
	{
		get => (View)GetValue(LowerThumbViewProperty);
		set => SetValue(LowerThumbViewProperty, value);
	}

	///<summary>Gets or sets a value indicating the upper thumb <see cref="View"/>.</summary>
	[AllowNull]
	public View UpperThumbView
	{
		get => (View)GetValue(UpperThumbViewProperty);
		set => SetValue(UpperThumbViewProperty, value);
	}

	///<summary>Gets or sets a value indicating the value label spacing.</summary>
	public double ValueLabelSpacing
	{
		get => (double)GetValue(ValueLabelSpacingProperty);
		set => SetValue(ValueLabelSpacingProperty, value);
	}

	///<summary>Gets or sets a value indicating the thumb radius in points.</summary>
	public double ThumbRadius
	{
		get => (double)GetValue(ThumbRadiusProperty);
		set => SetValue(ThumbRadiusProperty, value);
	}

	///<summary>Gets or sets a value indicating the lower thumb radius in points.</summary>
	public double LowerThumbRadius
	{
		get => (double)GetValue(LowerThumbRadiusProperty);
		set => SetValue(LowerThumbRadiusProperty, value);
	}

	///<summary>Gets or sets a value indicating the upper thumb radius in points.</summary>
	public double UpperThumbRadius
	{
		get => (double)GetValue(UpperThumbRadiusProperty);
		set => SetValue(UpperThumbRadiusProperty, value);
	}

	///<summary>Gets or sets a value indicating the track radius in points.</summary>
	public double TrackRadius
	{
		get => (double)GetValue(TrackRadiusProperty);
		set => SetValue(TrackRadiusProperty, value);
	}

	///// <summary>Method is called when any bound property is changed.</summary>
	///// <param name="propertyName">Bound property name.</param>
	//protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
	//{
	//	base.OnPropertyChanged(propertyName);
	//	switch (propertyName)
	//	{
	//		case nameof(IsReadOnly):
	//			OnIsReadOnlyChanged();
	//			break;
	//		case nameof(LowerValue):
	//			OnLowerValueChangedEvent(new RangeSliderLowerValueChangedEventArgs(LowerValue));
	//			break;
	//		case nameof(UpperValue):
	//			OnUpperValueChangedEvent(new RangeSliderUpperValueChangedEventArgs(UpperValue));
	//			break;
	//	}
	//}

	/// <summary>Fires when <see cref="LowerValue"/> is changed.</summary>
	public event EventHandler<RangeSliderLowerValueChangedEventArgs> LowerValueChanged
	{
		add => weakEventManager.AddEventHandler(value);
		remove => weakEventManager.RemoveEventHandler(value);
	}

	void OnLowerValueChangedEvent(RangeSliderLowerValueChangedEventArgs e)
	{
		weakEventManager.HandleEvent(this, e, nameof(LowerValueChanged));
	}

	/// <summary>Fires when <see cref="UpperValue"/> is changed.</summary>
	public event EventHandler<RangeSliderUpperValueChangedEventArgs> UpperValueChanged
	{
		add => weakEventManager.AddEventHandler(value);
		remove => weakEventManager.RemoveEventHandler(value);
	}

	void OnUpperValueChangedEvent(RangeSliderUpperValueChangedEventArgs e)
	{
		weakEventManager.HandleEvent(this, e, nameof(UpperValueChanged));
	}

	static object CoerceValue(BindableObject bindable, object value)
	{
		return ((RangeSlider)bindable).CoerceValue((double)value);
	}

	static void OnMinimumMaximumValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		((RangeSlider)bindable).OnMinimumMaximumValuePropertyChanged();
		((RangeSlider)bindable).OnLowerUpperValuePropertyChanged();
	}

	static void OnLowerUpperValuePropertyChanged(BindableObject bindable, object _, object __)
	{
		((RangeSlider)bindable).OnLowerUpperValuePropertyChanged();
	}

	double CoerceValue(double value)
	{
		if (StepValue > 0 && value < MaximumValue)
		{
			int stepIndex = (int)((value - MinimumValue) / StepValue);
			value = MinimumValue + (stepIndex * StepValue);
		}

		return Clamp(value, MinimumValue, MaximumValue);
	}

	void OnMinimumMaximumValuePropertyChanged()
	{
		LowerValue = CoerceValue(LowerValue);
		UpperValue = CoerceValue(UpperValue);
	}

	Border Track { get; } = new();

	Border TrackHighlight { get; } = new();

	Border LowerThumb { get; } = new();

	Border UpperThumb { get; } = new();

	double TrackWidth => Width - LowerThumb.Width - UpperThumb.Width;

	Size allocatedSize;

	readonly double labelMaxHeight;

	double lowerTranslation;

	double upperTranslation;

	readonly int dragCount;

	Label LowerValueLabel { get; } = new Label
	{
		HorizontalTextAlignment = TextAlignment.Center,
		VerticalTextAlignment = TextAlignment.Center,
		LineBreakMode = LineBreakMode.NoWrap
	};

	Label UpperValueLabel { get; } = new Label
	{
		HorizontalTextAlignment = TextAlignment.Center,
		VerticalTextAlignment = TextAlignment.Center,
		LineBreakMode = LineBreakMode.NoWrap
	};

	void OnLowerUpperValuePropertyChanged()
	{
		double rangeValue = MaximumValue - MinimumValue;
		double trackWidth = TrackWidth;

		lowerTranslation = (LowerValue - MinimumValue) / rangeValue * trackWidth;
		upperTranslation = ((UpperValue - MinimumValue) / rangeValue * trackWidth) + LowerThumb.Width;

		LowerThumb.TranslationX = lowerTranslation;
		UpperThumb.TranslationX = upperTranslation;
		OnValueLabelTranslationChanged();

		if (Control is null)
		{
			return;
		}

		Rect bounds = Control.GetLayoutBounds(TrackHighlight);
		Control.SetLayoutBounds(TrackHighlight, new Rect(lowerTranslation, bounds.Y, upperTranslation - lowerTranslation + UpperThumb.Width, bounds.Height));
	}

	/// <summary>Method called when control size is allocated.</summary>
	/// <param name="width">Control width.</param>
	/// <param name="height">Control height.</param>
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

		if (width.Equals(allocatedSize.Width) && height.Equals(allocatedSize.Height))
		{
			return;
		}

		allocatedSize = new Size(width, height);
		OnLayoutPropertyChanged();
	}

	void OnValueLabelTranslationChanged()
	{
		double lowerLabelTranslation = lowerTranslation + ((LowerThumb.Width - LowerValueLabel.Width) / 2);
		double upperLabelTranslation = upperTranslation + ((UpperThumb.Width - UpperValueLabel.Width) / 2);
		LowerValueLabel.TranslationX = Min(Max(lowerLabelTranslation, 0), Width - LowerValueLabel.Width - UpperValueLabel.Width - ValueLabelSpacing);
		UpperValueLabel.TranslationX = Min(Max(upperLabelTranslation, LowerValueLabel.TranslationX + LowerValueLabel.Width + ValueLabelSpacing), Width - UpperValueLabel.Width);
	}

	static void OnLayoutPropertyChanged(BindableObject bindable, object _, object __)
	{
		((RangeSlider)bindable).OnLayoutPropertyChanged();
	}

	void OnLayoutPropertyChanged()
	{
		if (Control is null)
		{
			return;
		}

		BatchBegin();
		Track.BatchBegin();
		TrackHighlight.BatchBegin();
		LowerThumb.BatchBegin();
		UpperThumb.BatchBegin();
		LowerValueLabel.BatchBegin();
		UpperValueLabel.BatchBegin();

		Color? lowerThumbColor = GetColorOrDefault(LowerThumbColor, ThumbColor);
		Color? upperThumbColor = GetColorOrDefault(UpperThumbColor, ThumbColor);
		Color? lowerThumbBorderColor = GetColorOrDefault(LowerThumbBorderColor, ThumbBorderColor);
		Color? upperThumbBorderColor = GetColorOrDefault(UpperThumbBorderColor, ThumbBorderColor);
		Color defaultThumbColor = Color.FromRgb(182, 182, 182);
		lowerThumbBorderColor = GetColorOrDefault(lowerThumbBorderColor, defaultThumbColor);
		upperThumbBorderColor = GetColorOrDefault(upperThumbBorderColor, defaultThumbColor);

		LowerThumb.Stroke = lowerThumbBorderColor;
		UpperThumb.Stroke = upperThumbBorderColor;
		LowerThumb.BackgroundColor = GetColorOrDefault(lowerThumbColor, Colors.White);
		UpperThumb.BackgroundColor = GetColorOrDefault(upperThumbColor, Colors.White);
		Track.BackgroundColor = GetColorOrDefault(TrackColor, Color.FromRgb(182, 182, 182));
		TrackHighlight.BackgroundColor = GetColorOrDefault(TrackHighlightColor, Color.FromRgb(46, 124, 246));
		Track.Stroke = GetColorOrDefault(TrackBorderColor, null);
		TrackHighlight.Stroke = GetColorOrDefault(TrackHighlightBorderColor, null);

		double trackSize = TrackSize;
		float trackRadius = (float)GetDoubleOrDefault(TrackRadius, trackSize / 2);
		double lowerThumbSize = GetDoubleOrDefault(LowerThumbSize, ThumbSize);
		double upperThumbSize = GetDoubleOrDefault(UpperThumbSize, ThumbSize);
		Track.StrokeShape = new RoundRectangle() { CornerRadius = trackRadius };
		TrackHighlight.StrokeShape = new RoundRectangle() { CornerRadius = trackRadius };
		LowerThumb.StrokeShape = new RoundRectangle() { CornerRadius = (float)GetDoubleOrDefault(GetDoubleOrDefault(LowerThumbRadius, ThumbRadius), lowerThumbSize / 2) };
		UpperThumb.StrokeShape = new RoundRectangle() { CornerRadius = (float)GetDoubleOrDefault(GetDoubleOrDefault(UpperThumbRadius, ThumbRadius), upperThumbSize / 2) };

		LowerThumb.Content = LowerThumbView;
		UpperThumb.Content = UpperThumbView;

		double labelWithSpacingHeight = Max(Max(LowerValueLabel.Height, UpperValueLabel.Height), 0);
		if (labelWithSpacingHeight > 0)
		{
			labelWithSpacingHeight += ValueLabelSpacing;
		}

		double trackThumbHeight = Max(Max(lowerThumbSize, upperThumbSize), trackSize);
		double trackVerticalPosition = labelWithSpacingHeight + ((trackThumbHeight - trackSize) / 2);
		double lowerThumbVerticalPosition = labelWithSpacingHeight + ((trackThumbHeight - lowerThumbSize) / 2);
		double upperThumbVerticalPosition = labelWithSpacingHeight + ((trackThumbHeight - upperThumbSize) / 2);

		Control.HeightRequest = labelWithSpacingHeight + trackThumbHeight;
		if (Control is null)
		{
			return;
		}

		Rect trackHighlightBounds = Control.GetLayoutBounds(TrackHighlight);
		Control.SetLayoutBounds(TrackHighlight, new Rect(trackHighlightBounds.X, trackVerticalPosition, trackHighlightBounds.Width, trackSize));
		Control.SetLayoutBounds(Track, new Rect(0, trackVerticalPosition, Width, trackSize));
		Control.SetLayoutBounds(LowerThumb, new Rect(0, lowerThumbVerticalPosition, lowerThumbSize, lowerThumbSize));
		Control.SetLayoutBounds(UpperThumb, new Rect(0, upperThumbVerticalPosition, upperThumbSize, upperThumbSize));
		Control.SetLayoutBounds(LowerValueLabel, new Rect(0, 0, -1, -1));
		Control.SetLayoutBounds(UpperValueLabel, new Rect(0, 0, -1, -1));
		SetValueLabelBinding(LowerValueLabel, LowerValueProperty);
		SetValueLabelBinding(UpperValueLabel, UpperValueProperty);
		LowerValueLabel.Style = LowerValueLabelStyle ?? ValueLabelStyle;
		UpperValueLabel.Style = UpperValueLabelStyle ?? ValueLabelStyle;

		OnLowerUpperValuePropertyChanged();

		Track.BatchCommit();
		TrackHighlight.BatchCommit();
		LowerThumb.BatchCommit();
		UpperThumb.BatchCommit();
		LowerValueLabel.BatchCommit();
		UpperValueLabel.BatchCommit();
		BatchCommit();
	}

	void SetValueLabelBinding(Label label, BindableProperty bindableProperty)
	{
		label.SetBinding(Label.TextProperty, new Binding
		{
			Source = this,
			Path = bindableProperty.PropertyName,
			StringFormat = ValueLabelStringFormat
		});
	}

	static double GetDoubleOrDefault(double value, double defaultSize)
	{
		return value < 0 ? defaultSize : value;
	}

	static Color? GetColorOrDefault(Color? color, Color? defaultColor)
	{
		return color ?? defaultColor;
	}

	void OnIsReadOnlyChanged()
	{
		if (Control is null)
		{
			return;
		}

		Control.IsEnabled = IsReadOnly;
	}
}
