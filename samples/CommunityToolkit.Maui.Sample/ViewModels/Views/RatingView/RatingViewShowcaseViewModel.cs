﻿// Ignore Spelling: csharp
namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class RatingViewShowcaseViewModel : BaseViewModel
{
	[ObservableProperty]
	double stepperValueMaximumRatings = 1;

	[ObservableProperty]
	Thickness ratingViewShapePadding = new(0);
}