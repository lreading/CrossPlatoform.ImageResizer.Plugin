﻿using System.IO;
using System.Threading.Tasks;

namespace Plugin.ImageResizer.Abstractions
{
  /// <summary>
  /// Interface for ImageResizer
  /// </summary>
  public interface IImageResizer
    {
        /// <summary>
        /// The new height in pixels to be used for resizing the image
        /// </summary>
        int NewHeight { get; }

        /// <summary>
        /// The new width in pixels to be used for resizing the image
        /// </summary>
        int NewWidth { get; }

        /// <summary>
        /// The ratio used to calculate the new width/height
        /// </summary>
        double Ratio { get; }

        /// <summary>
        /// Resizes an image with the target width/height while maintaining aspect ratio.
        /// </summary>
        /// <param name="sourceImage">The source image</param>
        /// <param name="targetWidth">The target width in pixels</param>
        /// <param name="targetHeight">The target height in pixels</param>
        /// <returns>byte[] of resized image</returns>
        Task<byte[]> ResizeImageWithAspectRatioAsync(byte[] sourceImage, int targetWidth, int targetHeight);

        /// <summary>
        /// Resizes an image with the target width/height while maintaining aspect ratio.
        /// </summary>
        /// <param name="sourceImage">The source image</param>
        /// <param name="targetWidth">The target width in pixels</param>
        /// <param name="targetHeight">The target height in pixels</param>
        /// <returns>byte[] of resized image</returns>
        Task<byte[]> ResizeImageWithAspectRatioAsync(Stream sourceImage, int targetWidth, int targetHeight);

        /// <summary>
        /// Reads all bytes from a stream.
        /// </summary>
        /// <remarks>
        /// Borrowed from Jon Skeet's solution on Stack Overflow: http://stackoverflow.com/a/221941/3033053
        /// </remarks>
        /// <param name="input"></param>
        /// <returns>All bytes from the stream</returns>
        byte[] ReadBytesFully(Stream input);

        /// <summary>
        /// Calculates the new widths and heights to use based on the existing
        /// widths/heights and the target widths/heights
        /// </summary>
        /// <remarks>
        /// Populates Ratio, NewHeight and NewWidth properties
        /// </remarks>
        /// <param name="originalWidth"></param>
        /// <param name="targetWidth"></param>
        /// <param name="originalHeight"></param>
        /// <param name="targetHeight"></param>
        void CalculateNewWidthAndHeight(int originalWidth, int targetWidth, int originalHeight, int targetHeight);
    }
}
