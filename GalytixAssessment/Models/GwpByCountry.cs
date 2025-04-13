using System.Text.Json.Serialization;

namespace GalytixAssessment.Models
{
    public class GwpByCountry
    {
        public string Country { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string LineOfBusiness { get; set; }
        public double? Y2000 { get; set; }
        public double? Y2001 { get; set; }
        public double? Y2002 { get; set; }
        public double? Y2003 { get; set; }
        public double? Y2004 { get; set; }
        public double? Y2005 { get; set; }
        public double? Y2006 { get; set; }
        public double? Y2007 { get; set; }
        public double? Y2008 { get; set; }
        public double? Y2009 { get; set; }
        public double? Y2010 { get; set; }
        public double? Y2011 { get; set; }
        public double? Y2012 { get; set; }
        public double? Y2013 { get; set; }
        public double? Y2014 { get; set; }
        public double? Y2015 { get; set; }

        public double GetAvgGwpFrom2008To2015()
        {
            return ((Y2008 ?? 0) + (Y2009 ?? 0) + (Y2010 ?? 0) + (Y2011 ?? 0)
                + (Y2012 ?? 0) + (Y2013 ?? 0) + (Y2014 ?? 0) + (Y2015 ?? 0)) / 8;
        }
    }
}
