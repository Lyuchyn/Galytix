namespace GalytixAssessment.Dtos
{
    public class GwpOutputDto
    {
        /// <summary>
        /// Gets or sets the dictionary with LOBs as keys and their average GWP as values.
        /// </summary>
        public Dictionary<string, double> AvrgGwpByLob { get; set; } = [];
    }
}
