namespace CommunityToolkit.Maui.Core;

/// <summary>Event args containing all contextual information related to range slider upper value changed event.</summary>
/// <param name="value">The new range slider upper value.</param>
public class RangeSliderUpperValueChangedEventArgs(double value) : EventArgs
{
	/// <summary>Gets the value for the range slider upper value changed event.</summary>
	public double Value { get; } = value;
}
