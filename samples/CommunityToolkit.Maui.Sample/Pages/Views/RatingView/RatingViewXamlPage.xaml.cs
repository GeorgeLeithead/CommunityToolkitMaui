using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Sample.ViewModels.Views;
using CommunityToolkit.Maui.Views;

namespace CommunityToolkit.Maui.Sample.Pages.Views;

public partial class RatingViewXamlPage : BasePage<RatingViewXamlViewModel>
{
	public RatingViewXamlPage(RatingViewXamlViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}

	static async void StepperMaximumRating_RatingChanged(object? sender, RatingChangedEventArgs e)
	{
		if (sender is RatingView ratingView)
		{
			// This is the weak event raised when the rating is changed.  The developer can then perform further actions (such as save to DB).
			await Toast.Make($"New Rating: {ratingView.Rating:F2}").Show(CancellationToken.None);
		}
	}

	void RatingViewShapePaddingBottom_ValueChanged(object? sender, ValueChangedEventArgs e) => BindingContext.RatingViewShapePaddingBottom = e.NewValue;

	void RatingViewShapePaddingLeft_ValueChanged(object? sender, ValueChangedEventArgs e) => BindingContext.RatingViewShapePaddingLeft = e.NewValue;

	void RatingViewShapePaddingRight_ValueChanged(object? sender, ValueChangedEventArgs e) => BindingContext.RatingViewShapePaddingRight = e.NewValue;

	void RatingViewShapePaddingTop_ValueChanged(object? sender, ValueChangedEventArgs e) => BindingContext.RatingViewShapePaddingTop = e.NewValue;
}