﻿using System.Collections.ObjectModel;

namespace CommunityToolkit.Maui.Core;

/// <summary>
/// The DrawingView allows you to draw one or multiple lines on a canvas
/// </summary>
public interface IDrawingView : IView
{
	/// <summary>
	/// The <see cref="Color"/> that is used by default to draw a line on the <see cref="IDrawingView"/>.
	/// </summary>
	Color LineColor { get; }

	/// <summary>
	/// The width that is used by default to draw a line on the <see cref="IDrawingView"/>.
	/// </summary>
	float LineWidth { get; }

	/// <summary>
	/// The collection of lines that are currently on the <see cref="IDrawingView"/>.
	/// </summary>
	ObservableCollection<IDrawingLine> Lines { get; }

	/// <summary>
	/// Toggles multi-line mode. When true, multiple lines can be drawn on the <see cref="IDrawingView"/> while the tap/click is released in-between lines.
	/// Note: when <see cref="ShouldClearOnFinish"/> is also enabled, the lines are cleared after the tap/click is released.
	/// Additionally, <see cref="OnDrawingLineCompleted"/> will be fired after each line that is drawn.
	/// </summary>
	bool IsMultiLineModeEnabled { get; }

	/// <summary>
	/// Indicates whether the <see cref="IDrawingView"/> is cleared after releasing the tap/click and a line is drawn.
	/// Note: when <see cref="IsMultiLineModeEnabled"/> is also enabled, this might cause unexpected behavior.
	/// </summary>
	bool ShouldClearOnFinish { get; }

	/// <summary>
	/// Allows drawing on the <see cref="IDrawingView"/>.
	/// </summary>
	Action<ICanvas, RectF>? DrawAction { get; }

	/// <summary>
	/// Retrieves a <see cref="Stream"/> containing an image of the <see cref="Lines"/> that are currently drawn on the <see cref="IDrawingView"/>.
	/// </summary>
	/// <param name="desiredWidth">Desired width of the image that is returned. The image will be resized proportionally.</param>
	/// <param name="desiredHeight">Desired height of the image that is returned. The image will be resized proportionally.</param>
	/// <param name="token"> <see cref="CancellationToken"/>.</param>
	/// <returns><see cref="Task{Stream}"/> containing the data of the requested image with data that's currently on the <see cref="IDrawingView"/>.</returns>
	ValueTask<Stream> GetImageStream(double desiredWidth, double desiredHeight, CancellationToken token = default) => GetImageStream(desiredWidth, desiredHeight, DrawingViewOutputOption.Lines, token);

	/// <summary>
	/// Retrieves a <see cref="Stream"/> containing an image of the <see cref="Lines"/> that are currently drawn on the <see cref="IDrawingView"/>.
	/// </summary>
	/// <param name="desiredWidth">Desired width of the image that is returned. The image will be resized proportionally.</param>
	/// <param name="desiredHeight">Desired height of the image that is returned. The image will be resized proportionally.</param>
	/// <param name="imageOutputOption">The <see cref="DrawingViewOutputOption"/> to determine the bounds and the contents of the resulting image.</param>
	/// <param name="token"> <see cref="CancellationToken"/>.</param>
	/// <returns><see cref="Task{Stream}"/> containing the data of the requested image with data that's currently on the <see cref="IDrawingView"/>.</returns>
	ValueTask<Stream> GetImageStream(double desiredWidth, double desiredHeight, DrawingViewOutputOption imageOutputOption, CancellationToken token = default);

	/// <summary>
	/// Clears the <see cref="Lines"/> that are currently drawn on the <see cref="IDrawingView"/>.
	/// </summary>
	void Clear();

	/// <summary>
	/// Event occurred when drawing line started
	/// </summary>
	/// <param name="point">Last drawing point</param>
	void OnDrawingLineStarted(PointF point);

	/// <summary>
	/// Event occurred when drawing line canceled
	/// </summary>
	void OnDrawingLineCancelled();

	/// <summary>
	/// Event occurred when point drawn
	/// </summary>
	/// <param name="point">Last drawing point</param>
	void OnPointDrawn(PointF point);

	/// <summary>
	/// Event occurred when drawing line completed
	/// </summary>
	/// <param name="lastDrawingLine">Last drawing line</param>
	void OnDrawingLineCompleted(IDrawingLine lastDrawingLine);
}