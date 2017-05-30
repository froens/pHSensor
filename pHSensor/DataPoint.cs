namespace pHSensor
{
    using OxyPlot;

    /// <summary>
    /// The data point.
    /// </summary>
    public class DataPoint
    {
        /// <summary>
        /// Gets or sets the wave length.
        /// </summary>
        public double Signal { get; set; }

        /// <summary>
        /// Gets or sets the pH.
        /// </summary>
        public double pH { get; set; }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        public double X
        {
            get
            {
                return Signal;
            }
            set
            {
                Signal = value;
            }
        }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        public double Y
        {
            get
            {
                return pH;
            }
            set
            {
                pH = value;
            }
        }
    }
}
