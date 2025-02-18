namespace CommunityToolkit.Maui.Core;

/// <summary>Event args containing all contextual information related to range slider lower value changed event.</summary>
/// <param name="value">The new range slider lower value.</param>
public class RangeSliderLowerValueChangedEventArgs(double value) : EventArgs
{
	/// <summary>Gets the value for the range slider lower value changed event.</summary>
	public double Value { get; } = value;
}
